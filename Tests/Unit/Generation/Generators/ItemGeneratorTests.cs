using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class ItemGeneratorTests
    {
        private IItemGenerator itemGenerator;
        private Mock<IMundaneItemGenerator> mockMundaneItemGenerator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IMagicalGearGeneratorFactory> mockMagicalGearGeneratorFactory;
        private Mock<IMagicalGearGenerator> mockMagicalGearGenerator;
        private Mock<IMagicalItemGeneratorFactory> mockMagicalItemGeneratorFactory;
        private Mock<IMagicalItemGenerator> mockMagicalItemGenerator;
        private Mock<ICurseGenerator> mockCurseGenerator;

        [SetUp]
        public void Setup()
        {
            mockMundaneItemGenerator = new Mock<IMundaneItemGenerator>();
            mockMagicalGearGenerator = new Mock<IMagicalGearGenerator>();
            mockMagicalGearGeneratorFactory = new Mock<IMagicalGearGeneratorFactory>();
            mockCurseGenerator = new Mock<ICurseGenerator>();

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>())).Returns(ItemsConstants.ItemTypes.WondrousItem);

            mockMagicalItemGenerator = new Mock<IMagicalItemGenerator>();
            mockMagicalItemGeneratorFactory = new Mock<IMagicalItemGeneratorFactory>();
            var dummyMock = new Mock<IMagicalItemGenerator>();
            var item = new TraitItem();
            dummyMock.Setup(m => m.GenerateAtPower(It.IsAny<String>())).Returns(item);
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith(It.IsAny<String>())).Returns(dummyMock.Object);

            itemGenerator = new ItemGenerator(mockMundaneItemGenerator.Object, mockPercentileResultProvider.Object,
                mockMagicalGearGeneratorFactory.Object, mockMagicalItemGeneratorFactory.Object, mockCurseGenerator.Object);
        }

        [Test]
        public void ItemGeneratorReturnsItem()
        {
            var item = itemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.Not.Null);
        }

        [Test]
        public void ItemGeneratorGeneratesMundaneItem()
        {
            var tool = new BasicItem();
            mockMundaneItemGenerator.Setup(g => g.Generate()).Returns(tool);

            var item = itemGenerator.GenerateAtPower(ItemsConstants.Power.Mundane);
            Assert.That(item, Is.EqualTo(tool));
        }

        [Test]
        public void ItemGeneratorGetsTypeFromPercentileResultProvider()
        {
            itemGenerator.GenerateAtPower("power");
            mockPercentileResultProvider.Verify(p => p.GetPercentileResult("powerItems"), Times.Once);
        }

        [Test]
        public void ItemGeneratorGetsArmorFromMagicalArmorGenerator()
        {
            var gear = new Gear();
            mockMagicalGearGenerator.Setup(g => g.GenerateAtPower("power")).Returns(gear);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerItems")).Returns(ItemsConstants.ItemTypes.Armor);
            mockMagicalGearGeneratorFactory.Setup(p => p.CreateWith(ItemsConstants.ItemTypes.Armor)).Returns(mockMagicalGearGenerator.Object);

            var item = itemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(gear));
        }

        [Test]
        public void ItemGeneratorGetsWeaponFromMagicalWeaponGenerator()
        {
            var gear = new Gear();
            mockMagicalGearGenerator.Setup(g => g.GenerateAtPower("power")).Returns(gear);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerItems")).Returns(ItemsConstants.ItemTypes.Weapon);
            mockMagicalGearGeneratorFactory.Setup(f => f.CreateWith(ItemsConstants.ItemTypes.Weapon)).Returns(mockMagicalGearGenerator.Object);

            var item = itemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(gear));
        }

        [Test]
        public void ItemGeneratorGetsMagicalItemsFromMagicalItemGenerator()
        {
            var magicalItem = new TraitItem();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerItems")).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            var item = itemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public void ItemGeneratorDoesNotGetCurseTraits()
        {
            var magicalItem = new TraitItem();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerItems")).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            mockCurseGenerator.Setup(g => g.HasCurse()).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurseTrait()).Returns("cursed");

            var item = itemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(magicalItem));
            Assert.That(magicalItem.Traits, Is.Not.Contains("cursed"));
        }

        [Test]
        public void ItemGeneratorGetsCurseTraits()
        {
            var magicalItem = new TraitItem();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerItems")).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            mockCurseGenerator.Setup(g => g.HasCurse()).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurseTrait()).Returns("cursed");

            var item = itemGenerator.GenerateAtPower("power");
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

            var item = itemGenerator.GenerateAtPower("power");
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

            var item = itemGenerator.GenerateAtPower(ItemsConstants.Power.Mundane);
            Assert.That(item, Is.EqualTo(tool));
        }
    }
}