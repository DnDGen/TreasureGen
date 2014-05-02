using EquipmentGen.Bootstrap.Factories.Mappers;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Tables.Interfaces;
using Ninject;
using Ninject.Modules;

namespace EquipmentGen.Bootstrap.Modules
{
    public class MappersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPercentileMapper>().ToMethod(c => PercentileMapperFactory.CreateWith(c.Kernel.Get<IStreamLoader>()))
                .InSingletonScope();
            Bind<IAttributesMapper>().ToMethod(c => AttributesMapperFactory.CreateWith(c.Kernel.Get<IStreamLoader>()))
                .InSingletonScope();
        }
    }
}