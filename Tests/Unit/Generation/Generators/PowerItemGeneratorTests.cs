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
    public class PowerItemGeneratorTests
    {
        private IPowerItemGenerator powerItemGenerator;
        private Mock<IMundaneItemGenerator> mockMundaneItemGenerator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IPowerGearGeneratorFactory> mockPowerGearGeneratorFactory;
        private Mock<IPowerGearGenerator> mockPowerGearGenerator;
        private Mock<IMagicalItemGenerator> mockMagicalItemGenerator;
        private Mock<IMagicalItemGeneratorFactory> mockMagicalItemGeneratorFactory;
        private Mock<ICurseGenerator> mockCurseGenerator;

        [SetUp]
        public void Setup()
        {
            mockMundaneItemGenerator = new Mock<IMundaneItemGenerator>();
            mockPowerGearGenerator = new Mock<IPowerGearGenerator>();
            mockPowerGearGeneratorFactory = new Mock<IPowerGearGeneratorFactory>();
            mockCurseGenerator = new Mock<ICurseGenerator>();

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>())).Returns(ItemsConstants.ItemTypes.WondrousItem);

            mockMagicalItemGenerator = new Mock<IMagicalItemGenerator>();
            mockMagicalItemGeneratorFactory = new Mock<IMagicalItemGeneratorFactory>();
            var dummyMock = new Mock<IMagicalItemGenerator>();
            var item = new TraitItem();
            dummyMock.Setup(m => m.GenerateAtPower(It.IsAny<String>())).Returns(item);
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith(It.IsAny<String>())).Returns(dummyMock.Object);

            powerItemGenerator = new PowerItemGenerator(mockMundaneItemGenerator.Object, mockPercentileResultProvider.Object,
                mockPowerGearGeneratorFactory.Object, mockMagicalItemGeneratorFactory.Object, mockCurseGenerator.Object);
        }

        [Test]
        public void PowerItemGeneratorReturnsItem()
        {
            var item = powerItemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.Not.Null);
        }

        [Test]
        public void PowerItemGeneratorGeneratesMundaneItem()
        {
            var tool = new BasicItem();
            mockMundaneItemGenerator.Setup(g => g.Generate()).Returns(tool);

            var item = powerItemGenerator.GenerateAtPower(ItemsConstants.Power.Mundane);
            Assert.That(item, Is.EqualTo(tool));
        }

        [Test]
        public void PowerItemGeneratorGetsTypeFromPercentileResultProvider()
        {
            powerItemGenerator.GenerateAtPower("power");
            mockPercentileResultProvider.Verify(p => p.GetPercentileResult("powerItems"), Times.Once);
        }

        [Test]
        public void PowerItemGeneratorGetsArmorFromPowerArmorGenerator()
        {
            var gear = new Gear();
            mockPowerGearGenerator.Setup(g => g.GenerateAtPower("power")).Returns(gear);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerItems")).Returns(ItemsConstants.ItemTypes.Armor);
            mockPowerGearGeneratorFactory.Setup(p => p.CreateWith(ItemsConstants.ItemTypes.Armor)).Returns(mockPowerGearGenerator.Object);

            var item = powerItemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(gear));
        }

        [Test]
        public void PowerItemGeneratorGetsWeaponFromPowerWeaponGenerator()
        {
            var gear = new Gear();
            mockPowerGearGenerator.Setup(g => g.GenerateAtPower("power")).Returns(gear);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerItems")).Returns(ItemsConstants.ItemTypes.Weapon);
            mockPowerGearGeneratorFactory.Setup(f => f.CreateWith(ItemsConstants.ItemTypes.Weapon)).Returns(mockPowerGearGenerator.Object);

            var item = powerItemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(gear));
        }

        [Test]
        public void PowerItemGeneratorGetsMagicalItemsFromMagicalItemGenerator()
        {
            var magicalItem = new TraitItem();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerItems")).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            var item = powerItemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(magicalItem));
        }

        [Test]
        public void PowerItemGeneratorDoesNotGetCurseTraits()
        {
            var magicalItem = new TraitItem();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerItems")).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            mockCurseGenerator.Setup(g => g.HasCurse()).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurseTrait()).Returns("cursed");

            var item = powerItemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(magicalItem));
            Assert.That(magicalItem.Traits, Is.Not.Contains("cursed"));
        }

        [Test]
        public void PowerItemGeneratorGetsCurseTraits()
        {
            var magicalItem = new TraitItem();
            mockMagicalItemGenerator.Setup(g => g.GenerateAtPower("power")).Returns(magicalItem);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerItems")).Returns("magic item");
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateWith("magic item")).Returns(mockMagicalItemGenerator.Object);

            mockCurseGenerator.Setup(g => g.HasCurse()).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurseTrait()).Returns("cursed");

            var item = powerItemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(magicalItem));
            Assert.That(magicalItem.Traits, Contains.Item("cursed"));
        }

        [Test]
        public void PowerItemGeneratorGetsSpecificCursedItems()
        {
            var cursedItem = new BasicItem();
            mockCurseGenerator.Setup(g => g.HasCurse()).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurseTrait()).Returns("SpecificCursedItem");
            mockCurseGenerator.Setup(g => g.GenerateSpecificCursedItem()).Returns(cursedItem);

            var item = powerItemGenerator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(cursedItem));
        }
    }
}