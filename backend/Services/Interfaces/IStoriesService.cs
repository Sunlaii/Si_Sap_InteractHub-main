public interface IStoriesService
{
    Task<ServiceResponse> GetAllAsync();
    Task<ServiceResponse> CreateAsync(string? userId, CreateStoryDto request);
    Task<ServiceResponse> DeleteAsync(string? userId, int id);
}
