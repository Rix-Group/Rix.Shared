using Microsoft.Extensions.DependencyInjection;
using Rix.AutoMapper.Mapper;
using Rix.AutoMapper.Profile;

namespace Rix.AutoMapper;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMapping(this IServiceCollection services, IEnumerable<IMappingProfile> profiles)
    {
        services.AddSingleton<IRixMapper>(_ => new RixMapper(profiles));
        return services;
    }
}