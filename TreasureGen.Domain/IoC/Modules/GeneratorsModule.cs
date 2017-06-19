using Ninject.Activation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Coins;
using TreasureGen.Domain.Generators;
using TreasureGen.Domain.Generators.Coins;
using TreasureGen.Domain.Generators.Factories;
using TreasureGen.Domain.Generators.Goods;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.IoC.Providers;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Generators;
using TreasureGen.Goods;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.IoC.Modules
{
    internal class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITreasureGenerator>().To<TreasureGenerator>().WhenInjectedInto<TreasureGeneratorEventGenDecorator>();
            Bind<ITreasureGenerator>().To<TreasureGeneratorEventGenDecorator>();

            Bind<ICoinGenerator>().To<CoinGenerator>().WhenInjectedInto<CoinGeneratorEventGenDecorator>();
            Bind<ICoinGenerator>().To<CoinGeneratorEventGenDecorator>();

            Bind<IGoodsGenerator>().To<GoodsGenerator>().WhenInjectedInto<GoodsGeneratorEventGenDecorator>();
            Bind<IGoodsGenerator>().To<GoodsGeneratorEventGenDecorator>();

            Bind<IItemsGenerator>().To<ItemsGenerator>().WhenInjectedInto<ItemsGeneratorEventGenDecorator>();
            Bind<IItemsGenerator>().To<ItemsGeneratorEventGenDecorator>();

            Bind<IChargesGenerator>().To<ChargesGenerator>();
            Bind<ICurseGenerator>().To<CurseGenerator>();
            Bind<IIntelligenceGenerator>().To<IntelligenceGenerator>();
            Bind<IMagicalItemTraitsGenerator>().To<MagicalItemTraitsGenerator>();
            Bind<ISpecialAbilitiesGenerator>().To<SpecialAbilitiesGenerator>();
            Bind<ISpecialMaterialGenerator>().To<SpecialMaterialGenerator>();
            Bind<ISpecificGearGenerator>().To<SpecificGearGenerator>();
            Bind<ISpellGenerator>().To<SpellGenerator>();
            Bind<Generator>().To<IterativeGenerator>();
            Bind<JustInTimeFactory>().ToProvider<JustInTimeFactoryProvider>();

            Bind<IMundaneItemGeneratorRuntimeFactory>().ToProvider<MundaneItemGeneratorFactoryProvider>();
            Bind<IMagicalItemGeneratorRuntimeFactory>().ToProvider<MagicalItemGeneratorFactoryProvider>();

            var decorators = new[]
            {
                typeof(MundaneItemGeneratorSpecialMaterialDecorator),
                typeof(MundaneItemGeneratorEventGenDecorator),
            };

            Decorate<MundaneItemGenerator, ToolGenerator>(ItemTypeConstants.Tool, decorators);
            Decorate<MundaneItemGenerator, AlchemicalItemGenerator>(ItemTypeConstants.AlchemicalItem, decorators);
            Decorate<MundaneItemGenerator, MundaneArmorGenerator>(ItemTypeConstants.Armor, decorators);
            Decorate<MundaneItemGenerator, MundaneWeaponGenerator>(ItemTypeConstants.Weapon, decorators);

            decorators = new[]
            {
                typeof(MagicalItemGeneratorCurseDecorator),
                typeof(MagicalItemGeneratorIntelligenceDecorator),
                typeof(MagicalItemGeneratorMundaneProxy),
                typeof(MagicalItemGeneratorSpecialMaterialDecorator),
                typeof(MagicalItemGeneratorTraitsDecorator),
                typeof(MagicalItemGeneratorEventGenDecorator),
            };

            Decorate<MagicalItemGenerator, MagicalArmorGenerator>(ItemTypeConstants.Armor, decorators);
            Decorate<MagicalItemGenerator, PotionGenerator>(ItemTypeConstants.Potion, decorators);
            Decorate<MagicalItemGenerator, RingGenerator>(ItemTypeConstants.Ring, decorators);
            Decorate<MagicalItemGenerator, RodGenerator>(ItemTypeConstants.Rod, decorators);
            Decorate<MagicalItemGenerator, ScrollGenerator>(ItemTypeConstants.Scroll, decorators);
            Decorate<MagicalItemGenerator, StaffGenerator>(ItemTypeConstants.Staff, decorators);
            Decorate<MagicalItemGenerator, WandGenerator>(ItemTypeConstants.Wand, decorators);
            Decorate<MagicalItemGenerator, MagicalWeaponGenerator>(ItemTypeConstants.Weapon, decorators);
            Decorate<MagicalItemGenerator, WondrousItemGenerator>(ItemTypeConstants.WondrousItem, decorators);
        }

        private void Decorate<S, T>(string name, params Type[] decorators)
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