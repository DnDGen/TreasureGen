using NUnit.Framework;
using TreasureGen.Common.Items;
using TreasureGen.Generators;
using TreasureGen.Generators.Coins;
using TreasureGen.Generators.Domain.Decorators;
using TreasureGen.Generators.Domain.RuntimeFactories;
using TreasureGen.Generators.Goods;
using TreasureGen.Generators.Items;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Generators.Items.Mundane;

namespace TreasureGen.Tests.Integration.Bootstrap.Modules
{
    [TestFixture]
    public class GeneratorsModuleTests : BootstrapTests
    {
        [Test]
        public void CoinGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ICoinGenerator>();
        }

        [Test]
        public void GoodsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IGoodsGenerator>();
        }

        [Test]
        public void TreasureGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ITreasureGenerator>();
        }

        [Test]
        public void ItemsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IItemsGenerator>();
        }

        [Test]
        public void AlchemicalItemGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.AlchemicalItem);
            Assert.That(generator, Is.InstanceOf<MundaneItemGeneratorSpecialMaterialDecorator>());
        }

        [Test]
        public void AlchemicalItemGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MundaneItemGenerator>(ItemTypeConstants.AlchemicalItem);
        }

        [Test]
        public void ToolGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.Tool);
            Assert.That(generator, Is.InstanceOf<MundaneItemGeneratorSpecialMaterialDecorator>());
        }

        [Test]
        public void ToolGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MundaneItemGenerator>(ItemTypeConstants.Tool);
        }

        [Test]
        public void MundaneGearGeneratorFactoryNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMundaneItemGeneratorFactory>();
        }

        [Test]
        public void MagicalItemGeneratorFactoryNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGeneratorFactory>();
        }

        [Test]
        public void SpecialMaterialGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialMaterialGenerator>();
        }

        [Test]
        public void SpecialAbilitiesGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecialAbilitiesGenerator>();
        }

        [Test]
        public void CurseGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ICurseGenerator>();
        }

        [Test]
        public void MagicalItemTraitsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemTraitsGenerator>();
        }

        [Test]
        public void SpellGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpellGenerator>();
        }

        [Test]
        public void IntelligenceGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IIntelligenceGenerator>();
        }

        [Test]
        public void ChargesGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IChargesGenerator>();
        }

        [Test]
        public void SpecificGearGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ISpecificGearGenerator>();
        }

        [Test]
        public void MagicalArmorGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MagicalItemGenerator>(ItemTypeConstants.Armor);
        }

        [Test]
        public void MagicalArmorGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MagicalItemGenerator>(ItemTypeConstants.Armor);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorTraitsDecorator>());
        }

        [Test]
        public void MagicalWeaponGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MagicalItemGenerator>(ItemTypeConstants.Weapon);
        }

        [Test]
        public void MagicalWeaponGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MagicalItemGenerator>(ItemTypeConstants.Weapon);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorTraitsDecorator>());
        }

        [Test]
        public void PotionGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MagicalItemGenerator>(ItemTypeConstants.Potion);
        }

        [Test]
        public void PotionGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MagicalItemGenerator>(ItemTypeConstants.Potion);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorTraitsDecorator>());
        }

        [Test]
        public void RingGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MagicalItemGenerator>(ItemTypeConstants.Ring);
        }

        [Test]
        public void RingGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MagicalItemGenerator>(ItemTypeConstants.Ring);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorTraitsDecorator>());
        }

        [Test]
        public void RodGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MagicalItemGenerator>(ItemTypeConstants.Rod);
        }

        [Test]
        public void RodGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MagicalItemGenerator>(ItemTypeConstants.Rod);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorTraitsDecorator>());
        }

        [Test]
        public void ScrollGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MagicalItemGenerator>(ItemTypeConstants.Scroll);
        }

        [Test]
        public void ScrollGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MagicalItemGenerator>(ItemTypeConstants.Scroll);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorTraitsDecorator>());
        }

        [Test]
        public void StaffGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MagicalItemGenerator>(ItemTypeConstants.Staff);
        }

        [Test]
        public void StaffGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MagicalItemGenerator>(ItemTypeConstants.Staff);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorTraitsDecorator>());
        }

        [Test]
        public void WandGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MagicalItemGenerator>(ItemTypeConstants.Wand);
        }

        [Test]
        public void WandGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MagicalItemGenerator>(ItemTypeConstants.Wand);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorTraitsDecorator>());
        }

        [Test]
        public void WondrousItemGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MagicalItemGenerator>(ItemTypeConstants.WondrousItem);
        }

        [Test]
        public void WondrousItemGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MagicalItemGenerator>(ItemTypeConstants.WondrousItem);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorTraitsDecorator>());
        }

        [Test]
        public void MundaneArmorGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.Armor);
            Assert.That(generator, Is.InstanceOf<MundaneItemGeneratorSpecialMaterialDecorator>());
        }

        [Test]
        public void MundaneArmorGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MundaneItemGenerator>(ItemTypeConstants.Armor);
        }

        [Test]
        public void MundaneWeaponGeneratorIsDecorated()
        {
            var generator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.Weapon);
            Assert.That(generator, Is.InstanceOf<MundaneItemGeneratorSpecialMaterialDecorator>());
        }

        [Test]
        public void MundaneWeaponGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<MundaneItemGenerator>(ItemTypeConstants.Weapon);
        }

        [Test]
        public void AmmunitionGeneratorIsNotConstructedAsSingleton()
        {
            AssertNotSingleton<IAmmunitionGenerator>();
        }
    }
}