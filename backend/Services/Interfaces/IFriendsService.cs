public interface IFriendsService
{
    Task<ServiceResponse> GetAllAsync(string? userId);
    Task<ServiceResponse> SendRequestAsync(string? senderId, FriendRequestDto request);
    Task<ServiceResponse> UpdateStatusAsync(string? userId, int id, UpdateFriendRequestDto request);
    Task<ServiceResponse> DeleteAsync(int id);
}
