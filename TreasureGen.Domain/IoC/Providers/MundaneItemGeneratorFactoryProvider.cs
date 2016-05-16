using Ninject;
using Ninject.Activation;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.IoC.Providers
{
    class MundaneItemGeneratorFactoryProvider : Provider<MundaneItemGeneratorFactory>
    {
        protected override MundaneItemGeneratorFactory CreateInstance(IContext context)
        {
            var armorGenerator = context.Kernel.Get<MundaneItemGenerator>(ItemTypeConstants.Armor);
            var weaponGenerator = context.Kernel.Get<MundaneItemGenerator>(ItemTypeConstants.Weapon);
            var toolGenerator = context.Kernel.Get<MundaneItemGenerator>(ItemTypeConstants.Tool);
            var alchemicalItemGenerator = context.Kernel.Get<MundaneItemGenerator>(ItemTypeConstants.AlchemicalItem);

            var factory = new MundaneItemGeneratorFactory(armorGenerator, weaponGenerator, toolGenerator, alchemicalItemGenerator);

            return factory;
        }
    }
}
