using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class StoriesService : IStoriesService
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;

    public StoriesService(AppDbContext dbContext, UserManager<ApplicationUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<ServiceResponse> GetAllAsync()
    {
        var stories = await _dbContext.Stories
            .Include(x => x.User)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return ServiceResponse.Ok(stories.Select(MapStory).ToList());
    }

    public async Task<ServiceResponse> CreateAsync(string? userId, CreateStoryDto request)
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

        var story = new Story
        {
            ImageUrl = request.ImageUrl,
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            ExpiredAt = DateTime.UtcNow.AddHours(request.ExpireHours <= 0 ? 24 : request.ExpireHours)
        };

        _dbContext.Stories.Add(story);
        await _dbContext.SaveChangesAsync();

        var loaded = await _dbContext.Stories.Include(x => x.User).FirstAsync(x => x.Id == story.Id);
        return ServiceResponse.Ok(MapStory(loaded));
    }

    public async Task<ServiceResponse> DeleteAsync(string? userId, int id)
    {
        var story = await _dbContext.Stories.FirstOrDefaultAsync(x => x.Id == id);
        if (story is null)
        {
            return ServiceResponse.NotFound();
        }

        if (story.UserId != userId)
        {
            return ServiceResponse.Forbidden();
        }

        _dbContext.Stories.Remove(story);
        await _dbContext.SaveChangesAsync();
        return ServiceResponse.NoContent();
    }

    private static object MapStory(Story story)
    {
        return new
        {
            id = story.Id,
            imageUrl = story.ImageUrl,
            createdAt = story.CreatedAt,
            expiredAt = story.ExpiredAt,
            userId = story.UserId,
            user = new UserDto
            {
                Id = story.User.Id,
                Username = story.User.UserName ?? string.Empty,
                Email = story.User.Email ?? string.Empty,
                FullName = story.User.UserName ?? string.Empty,
                Avatar = story.User.Avatar ?? string.Empty,
                Bio = story.User.Bio ?? string.Empty,
                Followers = 0,
                Following = 0,
                IsAdmin = false,
                CreatedAt = DateTime.UtcNow.ToString("o")
            }
        };
    }
}
