using Rix.Mediator.Abstractions;
namespace Rix.Mediator;

internal class RixMediator(IEnumerable<IRixValidator> validators, IEnumerable<IRixHandler> handlers) : IRixMediator
{
    private readonly IEnumerable<IRixValidator> _validators = validators;
    private readonly IEnumerable<IRixHandler> _handlers = handlers;

    public async Task<HandlerResponse<TResponse>> Send<TRequest, TResponse>(TRequest request, CancellationToken ct) where TRequest : IRixRequest
    {
        foreach (IRixValidator<TRequest> validator in _validators.OfType<IRixValidator<TRequest>>())
        {
            if (ct.IsCancellationRequested)
                return HandlerResponse<TResponse>.Error("Task cancelled");

            if (!await validator.IsValidAsync(request, out string error))
                return HandlerResponse<TResponse>.Error(error);
        }

        IRixHandler<TRequest, TResponse>? handler = _handlers.OfType<IRixHandler<TRequest, TResponse>>().FirstOrDefault();
        if (handler is null)
            return HandlerResponse<TResponse>.Error("Handler not found");

        if (ct.IsCancellationRequested)
            return HandlerResponse<TResponse>.Error("Task cancelled");

        return await handler.HandleAsync(request, ct);
    }
}