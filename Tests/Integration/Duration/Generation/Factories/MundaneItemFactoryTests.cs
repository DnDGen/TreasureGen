using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration.Generation.Factories
{
    [TestFixture]
    public class MundaneItemFactoryTests : DurationTest
    {
        [Inject]
        public IPowerFactoryFactory PowerFactoryFactory { get; set; }

        private IPowerFactory mundaneItemFactory;

        [SetUp]
        public void Setup()
        {
            mundaneItemFactory = PowerFactoryFactory.CreateWith(ItemsConstants.Power.Mundane);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void MundaneItemFactoryDuration()
        {
            mundaneItemFactory.Create();
            AssertDuration();
        }
    }
}