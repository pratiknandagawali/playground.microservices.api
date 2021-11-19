namespace Playground.Microservices.API.Translators
{
    public interface ITranslate<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
