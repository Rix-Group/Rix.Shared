namespace Rix.Mediator.Abstractions;

/// <summary>
/// A mediator to enable validation and handling requests
/// </summary>
public interface IRixMediator
{
    /// <summary>
    /// Sends a request and waits for a response
    /// </summary>
    /// <typeparam name="TRequest">Request type</typeparam>
    /// <typeparam name="TResponse">Response type</typeparam>
    /// <param name="request">The request to handle</param>
    /// <param name="ct">An optional cancellation token</param>
    /// <returns>A response wrapped in a handler response</returns>
    public Task<HandlerResponse<TResponse>> Send<TRequest, TResponse>(TRequest request, CancellationToken ct = default) where TRequest : IRixRequest;
}