using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class MagicalArmorGeneratorTests : StressTest
    {
        [Inject]
        public IMagicalGearGeneratorFactory MagicalGearGeneratorFactory { get; set; }

        private IMagicalGearGenerator magicalArmorGenerator;

        [SetUp]
        public void Setup()
        {
            magicalArmorGenerator = MagicalGearGeneratorFactory.CreateWith(ItemTypeConstants.Armor);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void StressedMagicalArmorGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var power = GetNewPower(false);
                var armor = magicalArmorGenerator.GenerateAtPower(power);

                Assert.That(armor.Name, Is.Not.Empty);
                Assert.That(armor.MagicalBonus, Is.GreaterThan(0));
                Assert.That(armor.Abilities, Is.Not.Null);
                Assert.That(armor.Traits, Is.Not.Null);
                Assert.That(armor.Types, Contains.Item(ItemTypeConstants.Armor));
            }

            AssertIterations();
        }
    }
}