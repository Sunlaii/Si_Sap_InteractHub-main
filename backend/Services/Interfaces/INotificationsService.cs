public interface INotificationsService
{
    Task<ServiceResponse> GetMineAsync(string? userId);
    Task<ServiceResponse> CreateAsync(CreateNotificationDto request);
    Task<ServiceResponse> MarkReadAsync(string? userId, int id);
}
