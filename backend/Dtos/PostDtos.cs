using System.ComponentModel.DataAnnotations;

public class CreatePostRequestDto
{
    public string? Content { get; set; }

    public string? ImageUrl { get; set; }
}

public class AddCommentRequestDto
{
    [Required]
    public string Content { get; set; } = string.Empty;
}

public class PostDto
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public UserDto User { get; set; } = new();
    public string Content { get; set; } = string.Empty;
    public List<string> Images { get; set; } = new();
    public List<string> Likes { get; set; } = new();
    public List<CommentDto> Comments { get; set; } = new();
    public int Shares { get; set; }
    public List<string> Hashtags { get; set; } = new();
    public string CreatedAt { get; set; } = string.Empty;
    public string UpdatedAt { get; set; } = string.Empty;
}

public class CommentDto
{
    public string Id { get; set; } = string.Empty;
    public string PostId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public UserDto User { get; set; } = new();
    public string Content { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
}
