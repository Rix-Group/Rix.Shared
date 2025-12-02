using Rix.Mediator.Abstractions;

namespace Rix.Mediator.Tests.Models;

internal class SimpleValidator : IRixValidator<SimpleRequest>
{
    public Task<bool> IsValidAsync(SimpleRequest request, out string error)
    {
        error = request.Valid ? string.Empty : "Invalid";
        return Task.FromResult(request.Valid);
    }
}