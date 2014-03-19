using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
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
        private Mock<IDice> mockDice;

        private IItemsGenerator itemsGenerator;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "power";
            result.AmountToRoll = "9266";
            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>(), It.IsAny<Int32>())).Returns(result);

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(42);
            mockDice.Setup(d => d.Roll(result.AmountToRoll)).Returns(9266);

            mockMundaneItemGenerator = new Mock<IMundaneItemGenerator>();
            mockMagicalGearGenerator = new Mock<IMagicalGearGenerator>();
            mockMagicalGearGeneratorFactory = new Mock<IMagicalGearGeneratorFactory>();
            mockCurseGenerator = new Mock<ICurseGenerator>();

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(It.IsAny<String>(), It.IsAny<Int32>())).Returns(ItemTypeConstants.WondrousItem);

            mockMagicalItemGenerator = new Mock<IMagicalItemGenerator>();
            mockMagicalItemGeneratorFactory = new Mock<IMagicalItemGeneratorFactory>();
            var dummyMock = new Mock<IMagicalItemGenerator>();
            var item = new Item();
            dummyMock.Setup(m => m.GenerateAtPower(It.IsAny<String>())).Returns(item);
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith(It.IsAny<String>())).Returns(dummyMock.Object);

            itemsGenerator = new ItemsGenerator(mockTypeAndAmountPercentileResultProvider.Object, mockMundaneItemGenerator.Object, mockPercentileResultProvider.Object,
                mockMagicalGearGeneratorFactory.Object, mockMagicalItemGeneratorFactory.Object, mockCurseGenerator.Object, mockDice.Object);
        }

        [Test]
        public void ItemsAreGenerated()
        {
            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items, Is.Not.Null);
        }

        [Test]
        public void GetItemTypeFromTypeAndAmountPercentileResultProvider()
        {
            itemsGenerator.GenerateAtLevel(9266);
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetResultFrom("Level9266Items", 42), Times.Once);
        }

        [Test]
        public void GetAmountFromRoll()
        {
            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items.Count(), Is.EqualTo(9266));
        }

        [Test]
        public void ReturnItems()
        {
            result.Type = PowerConstants.Mundane;
            result.AmountToRoll = "2";
            mockDice.Setup(d => d.Roll(result.AmountToRoll)).Returns(2);

            var firstItem = new Item();
            var secondItem = new Item();
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
            result.AmountToRoll = String.Empty;

            mockDice.Setup(d => d.Roll(String.Empty)).Throws(new Exception());
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetResultFrom("Level1Items", 42)).Returns(result);

            var items = itemsGenerator.GenerateAtLevel(1);
            Assert.That(items, Is.Empty);
        }

        [Test]
        public void ReturnItem()
        {
            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.Not.Null);
        }

        [Test]
        public void GenerateMundaneItem()
        {
            var tool = new Item();
            mockMundaneItemGenerator.Setup(g => g.Generate()).Returns(tool);

            var item = itemsGenerator.GenerateAtPower(PowerConstants.Mundane);
            Assert.That(item, Is.EqualTo(tool));
        }

        [Test]
        public void GetTypeFromPercentileResultProvider()
        {
            itemsGenerator.GenerateAtPower("power");
            mockPercentileResultProvider.Verify(p => p.GetResultFrom("powerItems", 42), Times.Once);
        }

        [Test]
        public void GetArmorFromMagicalArmorGenerator()
        {
            var gear = new Item();
            mockMagicalGearGenerator.Setup(g => g.GenerateAtPower("power")).Returns(gear);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerItems", 42)).Returns(ItemTypeConstants.Armor);
            mockMagicalGearGeneratorFactory.Setup(p => p.CreateWith(ItemTypeConstants.Armor)).Returns(mockMagicalGearGenerator.Object);

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(gear));
        }

        [Test]
        public void GetWeaponFromMagicalWeaponGenerator()
        {
            var gear = new Item();
            mockMagicalGearGenerator.Setup(g => g.GenerateAtPower("power")).Returns(gear);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerItems", 42)).Returns(ItemTypeConstants.Weapon);
            mockMagicalGearGeneratorFactory.Setup(f => f.CreateWith(ItemTypeConstants.Weapon)).Returns(mockMagicalGearGenerator.Object);

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(gear));
        }

        [Test]
        public void GetMagicalItemsFromMagicalItemGenerator()
        {
            var magicalItem = new Item();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerItems", 42)).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public void DoNotGetCurseIfNotCursed()
        {
            var magicalItem = new Item();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerItems", 42)).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            mockCurseGenerator.Setup(g => g.HasCurse(magicalItem.Magic)).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(magicalItem));
            Assert.That(magicalItem.Magic.Keys, Is.Not.Contains(Magic.Curse));
        }

        [Test]
        public void GetCurseIfCursed()
        {
            var magicalItem = new Item();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerItems", 42)).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            mockCurseGenerator.Setup(g => g.HasCurse(magicalItem.Magic)).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("curse");

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(magicalItem));
            Assert.That(magicalItem.Magic[Magic.Curse], Is.EqualTo("curse"));
        }

        [Test]
        public void GetSpecificCursedItems()
        {
            var magicalItem = new Item();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerItems", 42)).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            var cursedItem = new Item();
            mockCurseGenerator.Setup(g => g.HasCurse(magicalItem.Magic)).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("SpecificCursedItem");
            mockCurseGenerator.Setup(g => g.GenerateSpecificCursedItem()).Returns(cursedItem);

            var item = itemsGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(cursedItem));
        }

        [Test]
        public void MundaneItemsCannotBeCursed()
        {
            var mundaneItem = new Item();
            mockMundaneItemGenerator.Setup(g => g.Generate()).Returns(mundaneItem);

            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Dictionary<Magic, Object>>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("curse");

            var item = itemsGenerator.GenerateAtPower(PowerConstants.Mundane);
            Assert.That(item.Magic, Is.Empty);
        }
    }
}