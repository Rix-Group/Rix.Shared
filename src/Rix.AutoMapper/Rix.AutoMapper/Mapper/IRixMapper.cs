using Rix.AutoMapper.Profile;

namespace Rix.AutoMapper.Mapper;

public interface IRixMapper
{
    /// <summary>
    /// Convert source object to destination using an <see cref="IMappingProfile"/> or serialization if there's no set profile.
    /// </summary>
    /// <typeparam name="TSource">The source type.</typeparam>
    /// <typeparam name="TDestination">The destination type.</typeparam>
    /// <param name="source">The source object.</param>
    /// <returns>The source object mapped to the destination type.</returns>
    public TDestination Map<TSource, TDestination>(TSource source);
}