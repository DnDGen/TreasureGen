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
    public class MundaneItemGeneratorTests
    {
        private IMundaneItemGenerator mundaneItemGenerator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IAlchemicalItemGenerator> mockAlchemicalItemGenerator;
        private Mock<IMundaneGearGeneratorFactory> mockGearGeneratorFactory;
        private Mock<IToolGenerator> mockToolGenerator;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneItems")).Returns(ItemsConstants.ItemTypes.AlchemicalItem);

            mockAlchemicalItemGenerator = new Mock<IAlchemicalItemGenerator>();
            mockGearGeneratorFactory = new Mock<IMundaneGearGeneratorFactory>();
            mockToolGenerator = new Mock<IToolGenerator>();

            mundaneItemGenerator = new MundaneItemGenerator(mockPercentileResultProvider.Object, mockAlchemicalItemGenerator.Object,
                mockGearGeneratorFactory.Object, mockToolGenerator.Object);
        }

        [Test]
        public void MundaneItemGeneratorProducesAlchemicalItems()
        {
            var item = new AlchemicalItem();
            mockAlchemicalItemGenerator.Setup(f => f.Generate()).Returns(item);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneItems")).Returns(ItemsConstants.ItemTypes.AlchemicalItem);

            var result = mundaneItemGenerator.Generate();
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void MundaneItemGeneratorProducesArmor()
        {
            var item = new Gear();
            var mockArmorGenerator = new Mock<IMundaneGearGenerator>();
            mockArmorGenerator.Setup(f => f.Generate()).Returns(item);
            mockGearGeneratorFactory.Setup(f => f.CreateWith(ItemsConstants.ItemTypes.Armor)).Returns(mockArmorGenerator.Object);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneItems")).Returns(ItemsConstants.ItemTypes.Armor);

            var result = mundaneItemGenerator.Generate();
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void MundaneItemGeneratorProducesWeapons()
        {
            var item = new Gear();
            var mockWeaponGenerator = new Mock<IMundaneGearGenerator>();
            mockWeaponGenerator.Setup(f => f.Generate()).Returns(item);
            mockGearGeneratorFactory.Setup(f => f.CreateWith(ItemsConstants.ItemTypes.Weapon)).Returns(mockWeaponGenerator.Object);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneItems")).Returns(ItemsConstants.ItemTypes.Weapon);

            var result = mundaneItemGenerator.Generate();
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void MundaneItemGeneratorProducesTools()
        {
            var item = new BasicItem();
            mockToolGenerator.Setup(f => f.Generate()).Returns(item);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneItems")).Returns(ItemsConstants.ItemTypes.Tool);

            var result = mundaneItemGenerator.Generate();
            Assert.That(result, Is.EqualTo(item));
        }
    }
}