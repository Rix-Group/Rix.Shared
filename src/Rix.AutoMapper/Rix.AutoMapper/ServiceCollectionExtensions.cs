using Microsoft.Extensions.DependencyInjection;
using Rix.AutoMapper.Mapper;
using Rix.AutoMapper.Profile;

namespace Rix.AutoMapper;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds a singleton <see cref="IRixMapper"/> to the <see cref="IServiceCollection"/> with custom <see cref="IMappingProfile"/>s.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="profiles">Custom mapping profiles.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddMapping(this IServiceCollection services, params IEnumerable<IMappingProfile> profiles)
    {
        foreach (IMappingProfile profile in profiles)
            services.AddSingleton(profile);
        services.AddSingleton<IRixMapper, RixMapper>();
        return services;
    }
}