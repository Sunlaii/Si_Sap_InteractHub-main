public interface IUsersService
{
    Task<ServiceResponse> GetAllAsync();
    Task<ServiceResponse> GetByIdAsync(string id);
    Task<ServiceResponse> UpdateMeAsync(string? userId, UserDto request);
    Task<ServiceResponse> GetMyFriendsAsync(string? userId);
}
