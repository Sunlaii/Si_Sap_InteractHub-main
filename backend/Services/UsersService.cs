using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UsersService : IUsersService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AppDbContext _dbContext;

    public UsersService(UserManager<ApplicationUser> userManager, AppDbContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse> GetAllAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var mapped = new List<UserDto>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            mapped.Add(MapUser(user, roles.Contains("Admin")));
        }

        return ServiceResponse.Ok(mapped);
    }

    public async Task<ServiceResponse> GetByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            return ServiceResponse.NotFound();
        }

        var roles = await _userManager.GetRolesAsync(user);
        return ServiceResponse.Ok(MapUser(user, roles.Contains("Admin")));
    }

    public async Task<ServiceResponse> UpdateMeAsync(string? userId, UserDto request)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return ServiceResponse.Unauthorized();
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            return ServiceResponse.Unauthorized();
        }

        user.UserName = request.Username;
        user.Email = request.Email;
        user.Avatar = request.Avatar;
        user.Bio = request.Bio;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return ServiceResponse.BadRequest(string.Join("; ", result.Errors.Select(x => x.Description)));
        }

        var roles = await _userManager.GetRolesAsync(user);
        return ServiceResponse.Ok(MapUser(user, roles.Contains("Admin")));
    }

    public async Task<ServiceResponse> GetMyFriendsAsync(string? userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return ServiceResponse.Unauthorized();
        }

        var friendships = await _dbContext.Friendships
            .Include(x => x.Sender)
            .Include(x => x.Receiver)
            .Where(x => x.Status == "Accepted" && (x.SenderId == userId || x.ReceiverId == userId))
            .ToListAsync();

        var friends = friendships.Select(x => x.SenderId == userId ? x.Receiver : x.Sender)
            .Where(x => x is not null)
            .DistinctBy(x => x.Id)
            .Select(x => MapUser(x, false))
            .ToList();

        return ServiceResponse.Ok(friends);
    }

    private static UserDto MapUser(ApplicationUser user, bool isAdmin)
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
            IsAdmin = isAdmin,
            CreatedAt = DateTime.UtcNow.ToString("o")
        };
    }
}
