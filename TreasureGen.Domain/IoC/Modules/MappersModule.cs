using Ninject.Modules;
using TreasureGen.Domain.IoC.Providers;
using TreasureGen.Domain.Mappers.Attributes;
using TreasureGen.Domain.Mappers.Percentile;

namespace TreasureGen.Domain.IoC.Modules
{
    internal class MappersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPercentileMapper>().ToProvider<PercentileMapperProvider>().InSingletonScope();
            Bind<IAttributesMapper>().ToProvider<AttributesMapperProvider>().InSingletonScope();
        }
    }
}