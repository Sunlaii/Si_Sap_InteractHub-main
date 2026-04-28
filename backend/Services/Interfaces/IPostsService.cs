public interface IPostsService
{
    Task<ServiceResponse> GetAllAsync();
    Task<ServiceResponse> CreateAsync(string? userId, CreatePostRequestDto request);
    Task<ServiceResponse> LikeAsync(string? userId, int postId);
    Task<ServiceResponse> UnlikeAsync(string? userId, int postId);
    Task<ServiceResponse> AddCommentAsync(string? userId, int postId, AddCommentRequestDto request);
}
