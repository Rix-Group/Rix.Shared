namespace Rix.AutoMapper.Profile;

/// <summary>
/// A profile that maps from one object to another.
/// </summary>
public interface IMappingProfile;

/// <summary>
/// A profile that maps from one object to another.
/// </summary>
/// <typeparam name="TSource">The source type.</typeparam>
/// <typeparam name="TDestination">The destination type.</typeparam>
public interface IMappingProfile<TSource, TDestination> : IMappingProfile
{
    /// <summary>
    /// The function to invoke when mapping from <see cref="TSource"/> to <see cref="TDestination"/>.
    /// </summary>
    public Func<TSource, TDestination> Mapping { get; }
}