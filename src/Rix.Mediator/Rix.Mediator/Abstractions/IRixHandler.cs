namespace Rix.Mediator.Abstractions;

public interface IRixHandler;

public interface IRixHandler<TRequest, TResponse> : IRixHandler where TRequest : IRixRequest
{
    public Task<HandlerResponse<TResponse>> HandleAsync(TRequest request, CancellationToken ct);
}