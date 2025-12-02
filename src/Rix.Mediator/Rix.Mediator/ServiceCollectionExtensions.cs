using Microsoft.Extensions.DependencyInjection;
using Rix.Mediator.Abstractions;

namespace Rix.Mediator;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds a singleton <see cref="IRixMediator"/> to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="T">The assembly to read request types from.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddMediator<T>(this IServiceCollection services)
    {
        Type[] types = typeof(T).Assembly.GetTypes();

        foreach (Type validator in types.Where(t => !t.IsInterface && !t.IsAbstract && typeof(IRixValidator).IsAssignableFrom(t)))
            services.AddTransient(_ => (IRixValidator)Activator.CreateInstance(validator)!);

        foreach (Type handler in types.Where(t => !t.IsInterface && !t.IsAbstract && typeof(IRixHandler).IsAssignableFrom(t)))
            services.AddTransient(_ => (IRixHandler)Activator.CreateInstance(handler)!);

        services.AddSingleton<IRixMediator, RixMediator>();
        return services;
    }
}