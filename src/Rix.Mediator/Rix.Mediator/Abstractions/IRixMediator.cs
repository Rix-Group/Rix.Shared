namespace Rix.Mediator.Abstractions;

public interface IRixMediator
{
    public Task<HandlerResponse<TResponse>> Send<TRequest, TResponse>(TRequest request, CancellationToken ct) where TRequest : IRixRequest;
}