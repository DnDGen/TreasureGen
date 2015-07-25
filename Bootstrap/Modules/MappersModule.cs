using Ninject.Modules;
using TreasureGen.Bootstrap.Factories.Mappers;
using TreasureGen.Mappers;

namespace TreasureGen.Bootstrap.Modules
{
    public class MappersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPercentileMapper>().ToMethod(c => PercentileMapperFactory.CreateWith(c.Kernel))
                .InSingletonScope();
            Bind<IAttributesMapper>().ToMethod(c => AttributesMapperFactory.CreateWith(c.Kernel))
                .InSingletonScope();
        }
    }
}