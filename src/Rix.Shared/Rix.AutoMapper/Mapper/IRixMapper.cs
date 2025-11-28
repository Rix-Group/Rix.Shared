namespace Rix.AutoMapper.Mapper;

public interface IRixMapper
{
    public TDestination Map<TSource, TDestination>(TSource source);
}