using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class FriendsService : IFriendsService
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;

    public FriendsService(AppDbContext dbContext, UserManager<ApplicationUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<ServiceResponse> GetAllAsync(string? userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return ServiceResponse.Unauthorized();
        }

        var requests = await _dbContext.Friendships
            .Include(x => x.Sender)
            .Include(x => x.Receiver)
            .Where(x => x.SenderId == userId || x.ReceiverId == userId)
            .OrderByDescending(x => x.Id)
            .ToListAsync();

        return ServiceResponse.Ok(requests.Select(MapFriendship).ToList());
    }

    public async Task<ServiceResponse> SendRequestAsync(string? senderId, FriendRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(senderId))
        {
            return ServiceResponse.Unauthorized();
        }

        if (senderId == request.ReceiverId)
        {
            return ServiceResponse.BadRequest("Cannot send friend request to yourself.");
        }

        var receiver = await _userManager.FindByIdAsync(request.ReceiverId);
        if (receiver is null)
        {
            return ServiceResponse.NotFound("Receiver not found.");
        }

        var existing = await _dbContext.Friendships.FirstOrDefaultAsync(x =>
            (x.SenderId == senderId && x.ReceiverId == request.ReceiverId) ||
            (x.SenderId == request.ReceiverId && x.ReceiverId == senderId));

        if (existing is not null)
        {
            return ServiceResponse.BadRequest("Friend request already exists.");
        }

        var entity = new Friendship
        {
            SenderId = senderId,
            ReceiverId = request.ReceiverId,
            Status = "Pending"
        };

        _dbContext.Friendships.Add(entity);
        await _dbContext.SaveChangesAsync();

        return ServiceResponse.Ok(MapFriendship(await LoadFriendship(entity.Id)));
    }

    public async Task<ServiceResponse> UpdateStatusAsync(string? userId, int id, UpdateFriendRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return ServiceResponse.Unauthorized();
        }

        var normalizedStatus = request.Status.Trim();
        if (!string.Equals(normalizedStatus, "Accepted", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(normalizedStatus, "Rejected", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(normalizedStatus, "Pending", StringComparison.OrdinalIgnoreCase))
        {
            return ServiceResponse.BadRequest("Status must be one of: Pending, Accepted, Rejected.");
        }

        var entity = await _dbContext.Friendships.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null)
        {
            return ServiceResponse.NotFound();
        }

        if (entity.ReceiverId != userId && entity.SenderId != userId)
        {
            return ServiceResponse.Forbidden();
        }

        entity.Status = normalizedStatus;
        await _dbContext.SaveChangesAsync();

        return ServiceResponse.Ok(MapFriendship(await LoadFriendship(entity.Id)));
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var entity = await _dbContext.Friendships.FindAsync(id);
        if (entity is null)
        {
            return ServiceResponse.NotFound();
        }

        _dbContext.Friendships.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return ServiceResponse.NoContent();
    }

    private async Task<Friendship> LoadFriendship(int id)
    {
        return await _dbContext.Friendships
            .Include(x => x.Sender)
            .Include(x => x.Receiver)
            .FirstAsync(x => x.Id == id);
    }

    private static object MapFriendship(Friendship friendship)
    {
        return new
        {
            id = friendship.Id,
            senderId = friendship.SenderId,
            receiverId = friendship.ReceiverId,
            status = friendship.Status,
            sender = MapUser(friendship.Sender),
            receiver = MapUser(friendship.Receiver)
        };
    }

    private static UserDto MapUser(ApplicationUser user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
            FullName = user.UserName ?? string.Empty,
            Avatar = user.Avatar ?? string.Empty,
            Bio = user.Bio ?? string.Empty,
            Followers = 0,
            Following = 0,
            IsAdmin = false,
            CreatedAt = DateTime.UtcNow.ToString("o")
        };
    }
}
