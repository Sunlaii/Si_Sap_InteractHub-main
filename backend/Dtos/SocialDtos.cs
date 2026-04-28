using System.ComponentModel.DataAnnotations;

public class FriendRequestDto
{
    [Required]
    public string ReceiverId { get; set; } = string.Empty;
}

public class UpdateFriendRequestDto
{
    [Required]
    public string Status { get; set; } = string.Empty;
}

public class CreateStoryDto
{
    [Required]
    public string ImageUrl { get; set; } = string.Empty;

    public int ExpireHours { get; set; } = 24;
}

public class CreateNotificationDto
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;
}
