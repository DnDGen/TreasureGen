using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Generators
{
    [TestFixture]
    public class MundaneItemGeneratorTests : DurationTest
    {
        [Inject]
        public IPowerItemGeneratorFactory PowerItemGeneratorFactory { get; set; }

        private IPowerItemGenerator mundaneItemGenerator;

        [SetUp]
        public void Setup()
        {
            mundaneItemGenerator = PowerItemGeneratorFactory.CreateWith(ItemsConstants.Power.Mundane);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void MundaneItemGeneratorDuration()
        {
            mundaneItemGenerator.Generate();
            AssertDuration();
        }
    }
}