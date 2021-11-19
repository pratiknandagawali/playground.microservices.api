namespace Playground.Microservices.API.Translators
{
    using AutoMapper;
    public class Translate<TSource, TDestination> : ITranslate<TSource, TDestination>
    {
        private readonly IMapper autoMapper;

        public Translate()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            this.autoMapper = config.CreateMapper();
        }

        public TDestination Map(TSource source) =>
            this.autoMapper.Map<TDestination>(source);
    }
}
