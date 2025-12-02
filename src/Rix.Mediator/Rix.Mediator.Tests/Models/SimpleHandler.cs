using Rix.Mediator.Abstractions;

namespace Rix.Mediator.Tests.Models;

internal class SimpleHandler : IRixHandler<SimpleRequest, SimpleResponse>
{
    public async Task<HandlerResponse<SimpleResponse>> HandleAsync(SimpleRequest request, CancellationToken ct)
    {
        await Task.Delay(1000, ct);
        return HandlerResponse<SimpleResponse>.Success(new(true));
    }
}