using NUnit.Framework;
using RollGen;
using TreasureGen.Coins;
using TreasureGen.Domain.Generators;
using TreasureGen.Domain.Generators.Coins;
using TreasureGen.Domain.Generators.Factories;
using TreasureGen.Domain.Generators.Goods;
using TreasureGen.Domain.Generators.Items;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Generators;
using TreasureGen.Goods;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class GeneratorsModuleTests : IoCTests
    {
        [Test]
        public void CoinGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ICoinGenerator>();
        }

        [Test]
        public void CoinGeneratorIsDecorated()
        {
            var generator = InjectAndAssertDuration<ICoinGenerator>();
            Assert.That(generator, Is.InstanceOf<CoinGeneratorEventDecorator>());
        }

        [Test]
        public void GoodsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IGoodsGenerator>();
        }

        [Test]
        public void GoodsGeneratorIsDecorated()
        {
            var generator = InjectAndAssertDuration<IGoodsGenerator>();
            Assert.That(generator, Is.InstanceOf<GoodsGeneratorEventDecorator>());
        }

        [Test]
        public void TreasureGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<ITreasureGenerator>();
        }

        [Test]
        public void TreasureGeneratorIsDecorated()
        {
            var generator = InjectAndAssertDuration<ITreasureGenerator>();
            Assert.That(generator, Is.InstanceOf<TreasureGeneratorEventDecorator>());
        }

        [Test]
        public void ItemsGeneratorNotConstructedAsSingleton()
        {
            AssertNotSingleton<IItemsGenerator>();
        }

        [Test]
        public void ItemsGeneratorIsDecorated()
        {
            var generator = InjectAndAssertDuration<IItemsGenerator>();
            Assert.That(generator, Is.InstanceOf<ItemsGeneratorEventDecorator>());
        }

        [TestCase(ItemTypeConstants.AlchemicalItem)]
        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.Tool)]
        [TestCase(ItemTypeConstants.Weapon)]
        public void MundaneItemGeneratorIsDecorated(string itemType)
        {
            var generator = InjectAndAssertDuration<MundaneItemGenerator>(itemType);
            Assert.That(generator, Is.InstanceOf<MundaneItemGeneratorEventDecorator>());
        }

        [TestCase(ItemTypeConstants.AlchemicalItem)]
        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.Tool)]
        [TestCase(ItemTypeConstants.Weapon)]
        public void MundaneItemGeneratorIsNotConstructedAsSingleton(string itemType)
        {
            AssertNotSingleton<MundaneItemGenerator>(itemType);
        }

        [Test]
        public void MundaneGearGeneratorRuntimeFactoryNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMundaneItemGeneratorRuntimeFactory>();
        }

        [Test]
        public void MagicalItemGeneratorRuntimeFactoryNotConstructedAsSingleton()
        {
            AssertNotSingleton<IMagicalItemGeneratorRuntimeFactory>();
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
        public void CurseGeneratorIsDecorated()
        {
            var generator = InjectAndAssertDuration<ICurseGenerator>();
            Assert.That(generator, Is.InstanceOf<CurseGeneratorEventDecorator>());
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

        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.Potion)]
        [TestCase(ItemTypeConstants.Ring)]
        [TestCase(ItemTypeConstants.Rod)]
        [TestCase(ItemTypeConstants.Scroll)]
        [TestCase(ItemTypeConstants.Staff)]
        [TestCase(ItemTypeConstants.Wand)]
        [TestCase(ItemTypeConstants.Weapon)]
        [TestCase(ItemTypeConstants.WondrousItem)]
        public void MagicalItemGeneratorIsDecorated(string itemType)
        {
            var generator = InjectAndAssertDuration<MagicalItemGenerator>(itemType);
            Assert.That(generator, Is.InstanceOf<MagicalItemGeneratorEventDecorator>());
        }

        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.Potion)]
        [TestCase(ItemTypeConstants.Ring)]
        [TestCase(ItemTypeConstants.Rod)]
        [TestCase(ItemTypeConstants.Scroll)]
        [TestCase(ItemTypeConstants.Staff)]
        [TestCase(ItemTypeConstants.Wand)]
        [TestCase(ItemTypeConstants.Weapon)]
        [TestCase(ItemTypeConstants.WondrousItem)]
        public void MagicalItemGeneratorIsNotConstructedAsSingleton(string itemType)
        {
            AssertNotSingleton<MagicalItemGenerator>(itemType);
        }

        [Test]
        public void GeneratorIsNotConstructedAsASingleton()
        {
            AssertNotSingleton<Generator>();
        }

        [Test]
        public void JustInTimeFactoryInjected()
        {
            AssertNotSingleton<JustInTimeFactory>();
        }

        [Test]
        public void EXTERNAL_DiceInjected()
        {
            AssertNotSingleton<Dice>();
        }
    }
}