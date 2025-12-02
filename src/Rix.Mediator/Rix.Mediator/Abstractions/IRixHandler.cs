namespace Rix.Mediator.Abstractions;

/// <summary>
/// An interface for handlers - used for internals
/// </summary>
public interface IRixHandler;

/// <summary>
/// A class that handles requests
/// </summary>
/// <typeparam name="TRequest">Request type</typeparam>
/// <typeparam name="TResponse">Response type</typeparam>
public interface IRixHandler<TRequest, TResponse> : IRixHandler where TRequest : IRixRequest
{
    /// <summary>
    /// Handles requests
    /// </summary>
    /// <param name="request">The request to handle</param>
    /// <param name="ct">An optional cancellation token</param>
    /// <returns>A response wrapped in a handler response</returns>
    public Task<HandlerResponse<TResponse>> HandleAsync(TRequest request, CancellationToken ct = default);
}