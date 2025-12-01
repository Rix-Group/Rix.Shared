using Rix.AutoMapper.Profile;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Rix.AutoMapper.Mapper;

public class RixMapper(params IEnumerable<IMappingProfile> profiles) : IRixMapper
{
    private readonly IMappingProfile[] _profiles = [.. profiles];
    private readonly JsonSerializerOptions _options = new()
    {
        TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers = { SerializerModifiers.IncludeInternalProperties }
        }
    };

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        if (_profiles.FirstOrDefault(p => p is IMappingProfile<TSource, TDestination>) is IMappingProfile<TSource, TDestination> profile)
            return profile.Mapping.Invoke(source);

        return JsonSerializer.Deserialize<TDestination>(JsonSerializer.SerializeToUtf8Bytes(source, _options), _options)
            ?? throw new Exception("Could not convert type");
    }
}