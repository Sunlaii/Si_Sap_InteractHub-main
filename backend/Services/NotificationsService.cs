using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class NotificationsService : INotificationsService
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;

    public NotificationsService(AppDbContext dbContext, UserManager<ApplicationUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<ServiceResponse> GetMineAsync(string? userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return ServiceResponse.Unauthorized();
        }

        var notifications = await _dbContext.Notifications
            .Include(x => x.User)
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.Id)
            .ToListAsync();

        return ServiceResponse.Ok(notifications.Select(MapNotification).ToList());
    }

    public async Task<ServiceResponse> CreateAsync(CreateNotificationDto request)
    {
        var targetUser = await _userManager.FindByIdAsync(request.UserId);
        if (targetUser is null)
        {
            return ServiceResponse.NotFound("Target user not found.");
        }

        var entity = new Notification
        {
            UserId = request.UserId,
            Content = request.Content,
            IsRead = false
        };

        _dbContext.Notifications.Add(entity);
        await _dbContext.SaveChangesAsync();

        var loaded = await _dbContext.Notifications.Include(x => x.User).FirstAsync(x => x.Id == entity.Id);
        return ServiceResponse.Ok(MapNotification(loaded));
    }

    public async Task<ServiceResponse> MarkReadAsync(string? userId, int id)
    {
        var notification = await _dbContext.Notifications.FirstOrDefaultAsync(x => x.Id == id);
        if (notification is null)
        {
            return ServiceResponse.NotFound();
        }

        if (notification.UserId != userId)
        {
            return ServiceResponse.Forbidden();
        }

        notification.IsRead = true;
        await _dbContext.SaveChangesAsync();
        return ServiceResponse.NoContent();
    }

    private static object MapNotification(Notification notification)
    {
        return new
        {
            id = notification.Id,
            content = notification.Content,
            isRead = notification.IsRead,
            userId = notification.UserId,
            user = new UserDto
            {
                Id = notification.User.Id,
                Username = notification.User.UserName ?? string.Empty,
                Email = notification.User.Email ?? string.Empty,
                FullName = notification.User.UserName ?? string.Empty,
                Avatar = notification.User.Avatar ?? string.Empty,
                Bio = notification.User.Bio ?? string.Empty,
                Followers = 0,
                Following = 0,
                IsAdmin = false,
                CreatedAt = DateTime.UtcNow.ToString("o")
            }
        };
    }
}
