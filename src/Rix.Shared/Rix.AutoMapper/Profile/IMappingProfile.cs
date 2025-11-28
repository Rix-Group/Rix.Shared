namespace Rix.AutoMapper.Profile;

public interface IMappingProfile;

public interface IMappingProfile<TSource, TDestination> : IMappingProfile
{
    public Func<TSource, TDestination> Mapping { get; }
}