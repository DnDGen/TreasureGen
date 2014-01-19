using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class PowerFactoryFactoryTests
    {
        private IPowerFactoryFactory factory;

        [SetUp]
        public void Setup()
        {
            var mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            var mockAlchemicalItemFactory = new Mock<IAlchemicalItemFactory>();
            var mockGearFactoryFactory = new Mock<IGearFactoryFactory>();
            var mockToolFactory = new Mock<IToolFactory>();

            factory = new PowerFactoryFactory(mockPercentileResultProvider.Object, mockAlchemicalItemFactory.Object,
                mockGearFactoryFactory.Object, mockToolFactory.Object);
        }

        [Test]
        public void MundanePowerProducesMundaneFactory()
        {
            var powerFactory = factory.CreateWith(ItemsConstants.Power.Mundane);
            Assert.That(powerFactory, Is.TypeOf<MundaneItemFactory>());
        }

        [Test]
        public void MinorPowerProducesMundaneFactory()
        {
            var powerFactory = factory.CreateWith(ItemsConstants.Power.Minor);
            Assert.That(powerFactory, Is.TypeOf<MinorItemFactory>());
        }

        [Test]
        public void MediumPowerProducesMundaneFactory()
        {
            var powerFactory = factory.CreateWith(ItemsConstants.Power.Medium);
            Assert.That(powerFactory, Is.TypeOf<MediumItemFactory>());
        }

        [Test]
        public void MajorPowerProducesMundaneFactory()
        {
            var powerFactory = factory.CreateWith(ItemsConstants.Power.Major);
            Assert.That(powerFactory, Is.TypeOf<MajorItemFactory>());
        }
    }
}