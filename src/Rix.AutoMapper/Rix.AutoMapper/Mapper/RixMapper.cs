using Rix.AutoMapper.Profile;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Rix.AutoMapper.Mapper;

public class RixMapper(IList<IMappingProfile> profiles) : IRixMapper
{
    private readonly IList<IMappingProfile> _profiles = profiles;
    private readonly JsonSerializerOptions _options = new()
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers = { SerializerModifiers.IncludeInternalProperties }
        }
    };

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        if (_profiles.FirstOrDefault(p => p is IMappingProfile<TSource, TDestination>) is IMappingProfile<TSource, TDestination> profile)
            return profile.Map(source);

        return JsonSerializer.Deserialize<TDestination>(JsonSerializer.SerializeToUtf8Bytes(source, _options), _options)
            ?? throw new Exception("Could not convert type");
    }
}