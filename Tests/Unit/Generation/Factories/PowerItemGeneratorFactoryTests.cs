using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class PowerItemGeneratorFactoryTests
    {
        private IPowerItemGeneratorFactory factory;

        [SetUp]
        public void Setup()
        {
            var mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            var mockAlchemicalItemGenerator = new Mock<IAlchemicalItemGenerator>();
            var mockGearGeneratorFactory = new Mock<IGearGeneratorFactory>();
            var mockToolGenerator = new Mock<IToolGenerator>();

            factory = new PowerItemGeneratorFactory(mockPercentileResultProvider.Object, mockAlchemicalItemGenerator.Object,
                mockGearGeneratorFactory.Object, mockToolGenerator.Object);
        }

        [Test]
        public void MundanePowerProducesMundaneGenerator()
        {
            var powerGenerator = factory.CreateWith(ItemsConstants.Power.Mundane);
            Assert.That(powerGenerator, Is.TypeOf<MundaneItemGenerator>());
        }

        [Test]
        public void MinorPowerProducesMundaneGenerator()
        {
            var powerGenerator = factory.CreateWith(ItemsConstants.Power.Minor);
            Assert.That(powerGenerator, Is.TypeOf<MinorItemGenerator>());
        }

        [Test]
        public void MediumPowerProducesMundaneGenerator()
        {
            var powerGenerator = factory.CreateWith(ItemsConstants.Power.Medium);
            Assert.That(powerGenerator, Is.TypeOf<MediumItemGenerator>());
        }

        [Test]
        public void MajorPowerProducesMundaneGenerator()
        {
            var powerGenerator = factory.CreateWith(ItemsConstants.Power.Major);
            Assert.That(powerGenerator, Is.TypeOf<MajorItemGenerator>());
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidTypeThrowsError()
        {
            factory.CreateWith("invalid type");
        }
    }
}