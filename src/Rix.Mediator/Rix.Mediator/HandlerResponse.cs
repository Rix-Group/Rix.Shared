namespace Rix.Mediator;

public class HandlerResponse<T>
{
    public bool IsSuccess { get; init; }
    public string ErrorMessage { get; init; } = string.Empty;
    public T? Value { get; init; }

    public static HandlerResponse<T> Success(T? value) => new()
    {
        IsSuccess = true,
        Value = value
    };

    public static HandlerResponse<T> Error(string message) => new()
    {
        IsSuccess = false,
        ErrorMessage = message
    };

    public static HandlerResponse<T> Error(Exception ex) => new()
    {
        IsSuccess = false,
        ErrorMessage = ex.Message
    };
}