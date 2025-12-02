namespace Rix.Mediator.Abstractions;

public interface IRixValidator;

public interface IRixValidator<TRequest> : IRixValidator where TRequest : IRixRequest
{
    public Task<bool> IsValidAsync(TRequest request, out string error);
}