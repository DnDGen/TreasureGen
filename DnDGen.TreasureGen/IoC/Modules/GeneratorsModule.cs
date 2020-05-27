using DnDGen.TreasureGen.Coins;
using DnDGen.TreasureGen.Generators;
using DnDGen.TreasureGen.Generators.Coins;
using DnDGen.TreasureGen.Generators.Goods;
using DnDGen.TreasureGen.Generators.Items;
using DnDGen.TreasureGen.Generators.Items.Magical;
using DnDGen.TreasureGen.Generators.Items.Mundane;
using DnDGen.TreasureGen.Goods;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using Ninject.Activation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.IoC.Modules
{
    internal class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITreasureGenerator>().To<TreasureGenerator>();
            Bind<ICoinGenerator>().To<CoinGenerator>();
            Bind<IGoodsGenerator>().To<GoodsGenerator>();
            Bind<IItemsGenerator>().To<ItemsGenerator>();
            Bind<ICurseGenerator>().To<CurseGenerator>();
            Bind<ISpecificGearGenerator>().To<SpecificGearGenerator>();
            Bind<ISpecialAbilitiesGenerator>().To<SpecialAbilitiesGenerator>();
            Bind<IChargesGenerator>().To<ChargesGenerator>();
            Bind<IIntelligenceGenerator>().To<IntelligenceGenerator>();
            Bind<IMagicalItemTraitsGenerator>().To<MagicalItemTraitsGenerator>();
            Bind<ISpecialMaterialGenerator>().To<SpecialMaterialGenerator>();
            Bind<ISpellGenerator>().To<SpellGenerator>();

            var decorators = new[]
            {
                typeof(MundaneItemGeneratorSpecialMaterialDecorator),
            };

            NameAndDecorate<MundaneItemGenerator, ToolGenerator>(ItemTypeConstants.Tool, decorators);
            NameAndDecorate<MundaneItemGenerator, AlchemicalItemGenerator>(ItemTypeConstants.AlchemicalItem, decorators);
            NameAndDecorate<MundaneItemGenerator, MundaneArmorGenerator>(ItemTypeConstants.Armor, decorators);
            NameAndDecorate<MundaneItemGenerator, MundaneWeaponGenerator>(ItemTypeConstants.Weapon, decorators);

            decorators = new[]
            {
                typeof(MagicalItemGeneratorCurseDecorator),
                typeof(MagicalItemGeneratorIntelligenceDecorator),
                typeof(MagicalItemGeneratorTraitsDecorator),
                typeof(MagicalItemGeneratorSpecialMaterialDecorator),
                typeof(MagicalItemGeneratorMundaneProxy),
            };

            NameAndDecorate<MagicalItemGenerator, MagicalArmorGenerator>(ItemTypeConstants.Armor, decorators);
            NameAndDecorate<MagicalItemGenerator, PotionGenerator>(ItemTypeConstants.Potion, decorators);
            NameAndDecorate<MagicalItemGenerator, RingGenerator>(ItemTypeConstants.Ring, decorators);
            NameAndDecorate<MagicalItemGenerator, RodGenerator>(ItemTypeConstants.Rod, decorators);
            NameAndDecorate<MagicalItemGenerator, ScrollGenerator>(ItemTypeConstants.Scroll, decorators);
            NameAndDecorate<MagicalItemGenerator, StaffGenerator>(ItemTypeConstants.Staff, decorators);
            NameAndDecorate<MagicalItemGenerator, WandGenerator>(ItemTypeConstants.Wand, decorators);
            NameAndDecorate<MagicalItemGenerator, MagicalWeaponGenerator>(ItemTypeConstants.Weapon, decorators);
            NameAndDecorate<MagicalItemGenerator, WondrousItemGenerator>(ItemTypeConstants.WondrousItem, decorators);
        }

        private void NameAndDecorate<S, T>(string name, params Type[] decorators)
            where T : S
        {
            var implementations = new[] { typeof(T) }.Union(decorators).Take(decorators.Length);

            foreach (var implementation in implementations)
            {
                Bind<S>().To(implementation).When(r => Need(implementation, r, name, implementations));
            }

            Bind<S>().To(decorators.Last()).Named(name);
        }

        private bool Need(Type implementation, IRequest request, string name, IEnumerable<Type> implementations)
        {
            var implementationsList = implementations.ToList();
            var depth = implementationsList.Count - implementationsList.IndexOf(implementation);

            return request.Depth == depth && request.ActiveBindings.Any(b => b.Metadata.Name == name);
        }
    }
}