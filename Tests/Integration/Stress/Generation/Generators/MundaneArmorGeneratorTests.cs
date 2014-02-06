using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class MundaneArmorGeneratorTests : StressTest
    {
        [Inject]
        public IMundaneGearGeneratorFactory MundaneGearGeneratorFactory { get; set; }

        private IMundaneGearGenerator mundaneArmorGenerator;

        [SetUp]
        public void Setup()
        {
            mundaneArmorGenerator = MundaneGearGeneratorFactory.CreateWith(ItemsConstants.ItemTypes.Armor);
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
                Assert.That(armor.Abilities, Is.Empty);
                Assert.That(armor.MagicalBonus, Is.EqualTo(0));
                Assert.That(armor.Types, Contains.Item(ItemsConstants.ItemTypes.Armor));
            }

            AssertIterations();
        }
    }
}