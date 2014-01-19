using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class MundaneItemFactoryTests
    {
        private IPowerFactory mundaneItemFactory;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IAlchemicalItemFactory> mockAlchemicalItemFactory;
        private Mock<IGearFactory> mockArmorFactory;
        private Mock<IGearFactory> mockWeaponFactory;
        private Mock<IToolFactory> mockToolFactory;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneItems")).Returns(ItemsConstants.ItemTypes.AlchemicalItem);

            mockAlchemicalItemFactory = new Mock<IAlchemicalItemFactory>();
            mockArmorFactory = new Mock<IGearFactory>();
            mockWeaponFactory = new Mock<IGearFactory>();
            mockToolFactory = new Mock<IToolFactory>();

            mundaneItemFactory = new MundaneItemFactory(mockPercentileResultProvider.Object, mockAlchemicalItemFactory.Object,
                mockArmorFactory.Object, mockWeaponFactory.Object, mockToolFactory.Object);
        }

        [Test]
        public void MundaneItemFactoryProducesAlchemicalItems()
        {
            var item = new AlchemicalItem();
            mockAlchemicalItemFactory.Setup(f => f.Create()).Returns(item);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneItems")).Returns(ItemsConstants.ItemTypes.AlchemicalItem);

            var result = mundaneItemFactory.Create();
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void MundaneItemFactoryProducesArmor()
        {
            var item = new Gear();
            mockArmorFactory.Setup(f => f.CreateWith(ItemsConstants.Power.Mundane)).Returns(item);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneItems")).Returns(ItemsConstants.ItemTypes.Armor);

            var result = mundaneItemFactory.Create();
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void MundaneItemFactoryProducesWeapons()
        {
            var item = new Gear();
            mockWeaponFactory.Setup(f => f.CreateWith(ItemsConstants.Power.Mundane)).Returns(item);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneItems")).Returns(ItemsConstants.ItemTypes.Weapon);

            var result = mundaneItemFactory.Create();
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void MundaneItemFactoryProducesTools()
        {
            var item = new BasicItem();
            mockToolFactory.Setup(f => f.Create()).Returns(item);
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneItems")).Returns(ItemsConstants.ItemTypes.Tool);

            var result = mundaneItemFactory.Create();
            Assert.That(result, Is.EqualTo(item));
        }
    }
}