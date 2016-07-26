using Ninject.Modules;
using TreasureGen.Domain.Mappers.Collections;
using TreasureGen.Domain.Mappers.Percentile;

namespace TreasureGen.Domain.IoC.Modules
{
    internal class MappersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPercentileMapper>().To<PercentileXmlMapper>().WhenInjectedInto<PercentileMapperCachingProxy>();
            Bind<IPercentileMapper>().To<PercentileMapperCachingProxy>().InSingletonScope();

            Bind<ICollectionsMapper>().To<AttributesXmlMapper>().WhenInjectedInto<AttributesMapperCachingProxy>();
            Bind<ICollectionsMapper>().To<AttributesMapperCachingProxy>().InSingletonScope();
        }
    }
}