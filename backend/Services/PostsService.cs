using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class PostsService : IPostsService
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;

    public PostsService(AppDbContext dbContext, UserManager<ApplicationUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<ServiceResponse> GetAllAsync()
    {
        var posts = await _dbContext.Posts
            .Include(p => p.User)
            .Include(p => p.Likes)
            .Include(p => p.Comments)
                .ThenInclude(c => c.User)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();

        return ServiceResponse.Ok(posts.Select(MapPost).ToList());
    }

    public async Task<ServiceResponse> CreateAsync(string? userId, CreatePostRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return ServiceResponse.Unauthorized();
        }

        // Validate that at least content or imageUrl is provided
        if (string.IsNullOrWhiteSpace(request.Content) && string.IsNullOrWhiteSpace(request.ImageUrl))
        {
            return ServiceResponse.BadRequest("Vui lòng nhập nội dung hoặc thêm hình ảnh");
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            return ServiceResponse.Unauthorized();
        }

        var post = new Post
        {
            Content = request.Content ?? string.Empty,
            ImageUrl = request.ImageUrl,
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync();

        var createdPost = await _dbContext.Posts
            .Include(p => p.User)
            .Include(p => p.Likes)
            .Include(p => p.Comments)
                .ThenInclude(c => c.User)
            .FirstAsync(p => p.Id == post.Id);

        return ServiceResponse.Created(MapPost(createdPost));
    }

    public async Task<ServiceResponse> LikeAsync(string? userId, int postId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return ServiceResponse.Unauthorized();
        }

        var postExists = await _dbContext.Posts.AnyAsync(x => x.Id == postId);
        if (!postExists)
        {
            return ServiceResponse.NotFound("Post not found.");
        }

        var exists = await _dbContext.Likes.AnyAsync(x => x.PostId == postId && x.UserId == userId);
        if (!exists)
        {
            _dbContext.Likes.Add(new Like { PostId = postId, UserId = userId });
            await _dbContext.SaveChangesAsync();
        }

        return ServiceResponse.NoContent();
    }

    public async Task<ServiceResponse> UnlikeAsync(string? userId, int postId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return ServiceResponse.Unauthorized();
        }

        var like = await _dbContext.Likes.FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId);
        if (like is not null)
        {
            _dbContext.Likes.Remove(like);
            await _dbContext.SaveChangesAsync();
        }

        return ServiceResponse.NoContent();
    }

    public async Task<ServiceResponse> AddCommentAsync(string? userId, int postId, AddCommentRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            return ServiceResponse.Unauthorized();
        }

        var postExists = await _dbContext.Posts.AnyAsync(x => x.Id == postId);
        if (!postExists)
        {
            return ServiceResponse.NotFound("Post not found.");
        }

        var comment = new Comment
        {
            PostId = postId,
            UserId = userId,
            Content = request.Content,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Comments.Add(comment);
        await _dbContext.SaveChangesAsync();

        var createdComment = await _dbContext.Comments
            .Include(c => c.User)
            .FirstAsync(c => c.Id == comment.Id);

        return ServiceResponse.Ok(MapComment(createdComment));
    }

    private static PostDto MapPost(Post post)
    {
        return new PostDto
        {
            Id = post.Id.ToString(),
            UserId = post.UserId,
            User = new UserDto
            {
                Id = post.User.Id,
                Username = post.User.UserName ?? string.Empty,
                Email = post.User.Email ?? string.Empty,
                FullName = post.User.UserName ?? string.Empty,
                Avatar = post.User.Avatar ?? string.Empty,
                Bio = post.User.Bio ?? string.Empty,
                Followers = 0,
                Following = 0,
                IsAdmin = false,
                CreatedAt = DateTime.UtcNow.ToString("o")
            },
            Content = post.Content,
            Images = string.IsNullOrWhiteSpace(post.ImageUrl) ? new List<string>() : new List<string> { post.ImageUrl },
            Likes = post.Likes.Select(x => x.UserId).ToList(),
            Comments = post.Comments.OrderBy(x => x.CreatedAt).Select(MapComment).ToList(),
            Shares = 0,
            Hashtags = ExtractHashtags(post.Content),
            CreatedAt = post.CreatedAt.ToString("o"),
            UpdatedAt = post.CreatedAt.ToString("o")
        };
    }

    private static CommentDto MapComment(Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id.ToString(),
            PostId = comment.PostId.ToString(),
            UserId = comment.UserId,
            User = new UserDto
            {
                Id = comment.User.Id,
                Username = comment.User.UserName ?? string.Empty,
                Email = comment.User.Email ?? string.Empty,
                FullName = comment.User.UserName ?? string.Empty,
                Avatar = comment.User.Avatar ?? string.Empty,
                Bio = comment.User.Bio ?? string.Empty,
                Followers = 0,
                Following = 0,
                IsAdmin = false,
                CreatedAt = DateTime.UtcNow.ToString("o")
            },
            Content = comment.Content,
            CreatedAt = comment.CreatedAt.ToString("o")
        };
    }

    private static List<string> ExtractHashtags(string content)
    {
        return content
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(x => x.StartsWith('#'))
            .Select(x => x.TrimStart('#'))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
    }
}
