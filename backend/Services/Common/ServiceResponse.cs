public class ServiceResponse
{
    public int StatusCode { get; init; }
    public object? Data { get; init; }
    public string? Error { get; init; }

    public static ServiceResponse Ok(object? data) => new() { StatusCode = 200, Data = data };
    public static ServiceResponse Created(object? data) => new() { StatusCode = 201, Data = data };
    public static ServiceResponse NoContent() => new() { StatusCode = 204 };
    public static ServiceResponse BadRequest(string error) => new() { StatusCode = 400, Error = error };
    public static ServiceResponse Unauthorized(string error = "Unauthorized") => new() { StatusCode = 401, Error = error };
    public static ServiceResponse Forbidden(string error = "Forbidden") => new() { StatusCode = 403, Error = error };
    public static ServiceResponse NotFound(string error = "Not found") => new() { StatusCode = 404, Error = error };
}
