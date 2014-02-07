using System;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class ItemsGeneratorTests
    {
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
        private Mock<IMundaneItemGenerator> mockMundaneItemGenerator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IMagicalGearGeneratorFactory> mockMagicalGearGeneratorFactory;
        private Mock<IMagicalGearGenerator> mockMagicalGearGenerator;
        private Mock<IMagicalItemGeneratorFactory> mockMagicalItemGeneratorFactory;
        private Mock<IMagicalItemGenerator> mockMagicalItemGenerator;
        private Mock<ICurseGenerator> mockCurseGenerator;
        private IItemsGenerator itemsGenerator;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "power";
            result.Amount = 9266;
            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>())).Returns(result);

            mockMundaneItemGenerator = new Mock<IMundaneItemGenerator>();
            mockMagicalGearGenerator = new Mock<IMagicalGearGenerator>();
            mockMagicalGearGeneratorFactory = new Mock<IMagicalGearGeneratorFactory>();
            mockCurseGenerator = new Mock<ICurseGenerator>();

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>())).Returns(ItemTypeConstants.WondrousItem);

            mockMagicalItemGenerator = new Mock<IMagicalItemGenerator>();
            mockMagicalItemGeneratorFactory = new Mock<IMagicalItemGeneratorFactory>();
            var dummyMock = new Mock<IMagicalItemGenerator>();
            var item = new TraitItem();
            dummyMock.Setup(m => m.GenerateAtPower(It.IsAny<String>())).Returns(item);
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith(It.IsAny<String>())).Returns(dummyMock.Object);

            itemsGenerator = new ItemsGenerator(mockTypeAndAmountPercentileResultProvider.Object, mockMundaneItemGenerator.Object, mockPercentileResultProvider.Object,
                mockMagicalGearGeneratorFactory.Object, mockMagicalItemGeneratorFactory.Object, mockCurseGenerator.Object);
        }

        [Test]
        public void ItemsAreGenerated()
        {
            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items, Is.Not.Null);
        }

        [Test]
        public void ItemsGeneratorGetsItemTypeFromTypeAndAmountPercentileResultProvider()
        {
            itemsGenerator.GenerateAtLevel(9266);
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetResultFrom("Level9266Items"), Times.Once);
        }

        [Test]
        public void ItemsGeneratorGetsAmountFromRoll()
        {
            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items.Count(), Is.EqualTo(9266));
        }

        [Test]
        public void ItemsGeneratorReturnsItems()
        {
            result.Type = PowerConstants.Mundane;
            result.Amount = 2;

            var firstItem = new AlchemicalItem();
            var secondItem = new BasicItem();
            mockMundaneItemGenerator.SetupSequence(f => f.Generate()).Returns(firstItem).Returns(secondItem);

            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items, Contains.Item(firstItem));
            Assert.That(items, Contains.Item(secondItem));
            Assert.That(items.Count(), Is.EqualTo(2));
        }

        [Test]
        public void IfTypeAndAmountProviderReturnsEmptyResult_ItemsGeneratorReturnsEmptyEnumerable()
        {
            result.Type = String.Empty;
            result.Amount = 0;
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetResultFrom("Level1Items")).Returns(result);

            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items, Is.Empty);
        }

        [Test]
        public void ItemGeneratorReturnsItem()
        {
            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.Not.Null);
        }

        [Test]
        public void ItemGeneratorGeneratesMundaneItem()
        {
            var tool = new BasicItem();
            mockMundaneItemGenerator.Setup(g => g.Generate()).Returns(tool);

            var item = itemsGenerator.GenerateAtPower(PowerConstants.Mundane);
            Assert.That(item, Is.EqualTo(tool));
        }

        [Test]
        public void ItemGeneratorGetsTypeFromPercentileResultProvider()
        {
            itemsGenerator.GenerateAtPower("power");
            mockPercentileResultProvider.Verify(p => p.GetResultFrom("powerItems"), Times.Once);
        }

        [Test]
        public void ItemGeneratorGetsArmorFromMagicalArmorGenerator()
        {
            var gear = new Gear();
            mockMagicalGearGenerator.Setup(g => g.GenerateAtPower("power")).Returns(gear);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerItems")).Returns(ItemTypeConstants.Armor);
            mockMagicalGearGeneratorFactory.Setup(p => p.CreateWith(ItemTypeConstants.Armor)).Returns(mockMagicalGearGenerator.Object);

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(gear));
        }

        [Test]
        public void ItemGeneratorGetsWeaponFromMagicalWeaponGenerator()
        {
            var gear = new Gear();
            mockMagicalGearGenerator.Setup(g => g.GenerateAtPower("power")).Returns(gear);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerItems")).Returns(ItemTypeConstants.Weapon);
            mockMagicalGearGeneratorFactory.Setup(f => f.CreateWith(ItemTypeConstants.Weapon)).Returns(mockMagicalGearGenerator.Object);

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(gear));
        }

        [Test]
        public void ItemGeneratorGetsMagicalItemsFromMagicalItemGenerator()
        {
            var magicalItem = new TraitItem();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerItems")).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public void ItemGeneratorDoesNotGetCurseTraits()
        {
            var magicalItem = new TraitItem();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerItems")).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            mockCurseGenerator.Setup(g => g.HasCurse()).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurseTrait()).Returns("cursed");

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(magicalItem));
            Assert.That(magicalItem.Traits, Is.Not.Contains("cursed"));
        }

        [Test]
        public void ItemGeneratorGetsCurseTraits()
        {
            var magicalItem = new TraitItem();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerItems")).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            mockCurseGenerator.Setup(g => g.HasCurse()).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurseTrait()).Returns("cursed");

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(magicalItem));
            Assert.That(magicalItem.Traits, Contains.Item("cursed"));
        }

        [Test]
        public void ItemGeneratorGetsSpecificCursedItems()
        {
            var cursedItem = new BasicItem();
            mockCurseGenerator.Setup(g => g.HasCurse()).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurseTrait()).Returns("SpecificCursedItem");
            mockCurseGenerator.Setup(g => g.GenerateSpecificCursedItem()).Returns(cursedItem);

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(cursedItem));
        }

        [Test]
        public void MundaneItemsCannotBeCursed()
        {
            var cursedItem = new BasicItem();
            mockCurseGenerator.Setup(g => g.HasCurse()).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurseTrait()).Returns("SpecificCursedItem");
            mockCurseGenerator.Setup(g => g.GenerateSpecificCursedItem()).Returns(cursedItem);

            var tool = new BasicItem();
            mockMundaneItemGenerator.Setup(g => g.Generate()).Returns(tool);

            var item = itemsGenerator.GenerateAtPower(PowerConstants.Mundane);
            Assert.That(item, Is.EqualTo(tool));
        }
    }
}