using Ninject;
using Ninject.Activation;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.IoC.Providers
{
    class MagicalItemGeneratorFactoryProvider : Provider<MagicalItemGeneratorRuntimeFactory>
    {
        protected override MagicalItemGeneratorRuntimeFactory CreateInstance(IContext context)
        {
            var armorGenerator = context.Kernel.Get<MagicalItemGenerator>(ItemTypeConstants.Armor);
            var weaponGenerator = context.Kernel.Get<MagicalItemGenerator>(ItemTypeConstants.Weapon);
            var potionGenerator = context.Kernel.Get<MagicalItemGenerator>(ItemTypeConstants.Potion);
            var ringGenerator = context.Kernel.Get<MagicalItemGenerator>(ItemTypeConstants.Ring);
            var rodGenerator = context.Kernel.Get<MagicalItemGenerator>(ItemTypeConstants.Rod);
            var scrollGenerator = context.Kernel.Get<MagicalItemGenerator>(ItemTypeConstants.Scroll);
            var staffGenerator = context.Kernel.Get<MagicalItemGenerator>(ItemTypeConstants.Staff);
            var wandGenerator = context.Kernel.Get<MagicalItemGenerator>(ItemTypeConstants.Wand);
            var wondrousItemGenerator = context.Kernel.Get<MagicalItemGenerator>(ItemTypeConstants.WondrousItem);

            var factory = new MagicalItemGeneratorRuntimeFactory(armorGenerator, potionGenerator, ringGenerator, rodGenerator, scrollGenerator, staffGenerator,
                wandGenerator, weaponGenerator, wondrousItemGenerator);

            return factory;
        }
    }
}
