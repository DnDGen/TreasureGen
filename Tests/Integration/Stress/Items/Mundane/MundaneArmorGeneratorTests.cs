using EquipmentGen.Common.Items;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Generators.Interfaces;
using Ninject;
using NUnit.Framework;
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class MundaneArmorGeneratorTests : StressTests
    {
        [Inject]
        public IMundaneGearGeneratorFactory MundaneGearGeneratorFactory { get; set; }

        private IMundaneGearGenerator mundaneArmorGenerator;

        [SetUp]
        public void Setup()
        {
            mundaneArmorGenerator = MundaneGearGeneratorFactory.CreateWith(ItemTypeConstants.Armor);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void StressedMundaneArmorGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var armor = mundaneArmorGenerator.Generate();

                Assert.That(armor.Name, Is.Not.Empty);
                Assert.That(armor.Traits, Is.Not.Null);
                Assert.That(armor.Attributes, Contains.Item(ItemTypeConstants.Armor));
                Assert.That(armor.Quantity, Is.EqualTo(1));
                Assert.That(armor.Magic, Is.Empty);
            }

            AssertIterations();
        }
    }
}