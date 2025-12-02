using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rix.Mediator.Abstractions;
using Rix.Mediator.Tests.Models;

namespace Rix.Mediator.Tests.Features;

public class SimpleTests
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task TestValidator(bool valid)
    {
        // ARRANGE
        ServiceCollection services = new ServiceCollection();
        services.AddMediator<SimpleTests>();

        ServiceProvider provider = services.BuildServiceProvider();

        // ASSERT
        Assert.Single(provider.GetServices<IRixValidator>(), t => t is SimpleValidator);
        Assert.Single(provider.GetServices<IRixHandler>(), t => t is SimpleHandler);

        IRixMediator rixMediator = Assert.Single(provider.GetServices<IRixMediator>());

        // ACT
        HandlerResponse<SimpleResponse> response = await rixMediator.Send<SimpleRequest, SimpleResponse>(new(valid), CancellationToken.None);

        // ASSERT
        if (valid)
        {
            Assert.Empty(response.ErrorMessage);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Value);

            Assert.True(response.Value.ResponseValue);
        }
        else
        {
            Assert.Equal("Invalid", response.ErrorMessage);
            Assert.False(response.IsSuccess);
            Assert.Null(response.Value);
        }
    }

    [Fact]
    public async Task NoValidator()
    {
        // ARRANGE
        ServiceCollection services = new ServiceCollection();
        services.AddMediator<SimpleTests>();
        services.RemoveAll<IRixValidator>();

        ServiceProvider provider = services.BuildServiceProvider();

        // ASSERT
        Assert.Empty(provider.GetServices<IRixValidator>());
        Assert.Single(provider.GetServices<IRixHandler>(), t => t is SimpleHandler);

        IRixMediator rixMediator = Assert.Single(provider.GetServices<IRixMediator>());

        // ACT
        HandlerResponse<SimpleResponse> response = await rixMediator.Send<SimpleRequest, SimpleResponse>(new(false), CancellationToken.None);

        // ASSERT
        Assert.Empty(response.ErrorMessage);
        Assert.True(response.IsSuccess);
        Assert.NotNull(response.Value);

        Assert.True(response.Value.ResponseValue);
    }

    [Fact]
    public async Task TaskCancelled()
    {
        // ARRANGE
        ServiceCollection services = new ServiceCollection();
        services.AddMediator<SimpleTests>();

        ServiceProvider provider = services.BuildServiceProvider();

        using CancellationTokenSource cts = new();
        await cts.CancelAsync();

        // ASSERT
        IRixMediator rixMediator = Assert.Single(provider.GetServices<IRixMediator>());

        // ACT
        HandlerResponse<SimpleResponse> response = await rixMediator.Send<SimpleRequest, SimpleResponse>(new(false), cts.Token);

        // ASSERT
        Assert.Equal("Task cancelled", response.ErrorMessage);
        Assert.False(response.IsSuccess);
        Assert.Null(response.Value);
    }

    [Fact]
    public async Task NoHandlers()
    {
        // ARRANGE
        ServiceCollection services = new ServiceCollection();
        services.AddMediator<SimpleTests>();
        services.RemoveAll<IRixValidator>();
        services.RemoveAll<IRixHandler>();

        ServiceProvider provider = services.BuildServiceProvider();

        // ASSERT
        Assert.Empty(provider.GetServices<IRixValidator>());
        Assert.Empty(provider.GetServices<IRixHandler>());

        IRixMediator rixMediator = Assert.Single(provider.GetServices<IRixMediator>());

        // ACT
        HandlerResponse<SimpleResponse> response = await rixMediator.Send<SimpleRequest, SimpleResponse>(new(false), CancellationToken.None);

        // ASSERT
        Assert.Equal("Handler not found", response.ErrorMessage);
        Assert.False(response.IsSuccess);
        Assert.Null(response.Value);
    }
}