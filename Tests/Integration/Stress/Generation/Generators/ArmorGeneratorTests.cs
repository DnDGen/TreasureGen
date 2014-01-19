using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class ArmorGeneratorTests : StressTest
    {
        [Inject]
        public IGearGeneratorFactory GearGeneratorFactory { get; set; }

        private IGearGenerator armorGenerator;

        [SetUp]
        public void Setup()
        {
            armorGenerator = GearGeneratorFactory.CreateWith(ItemsConstants.ItemTypes.Armor);
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void ArmorGeneratorReturnsArmorAtPower()
        {
            while (TestShouldKeepRunning())
            {
                var power = GetNewPower();
                var armor = armorGenerator.GenerateAtPower(power);

                Assert.That(armor, Is.Not.Null);
                Assert.That(armor.Name, Is.Not.Empty);
                Assert.That(armor.MagicalBonus, Is.Not.Negative);
                Assert.That(armor.Abilities, Is.Not.Null);
                Assert.That(armor.Traits, Is.Not.Null);
            }

            AssertIterations();
        }

        [Test]
        public void ArmorGeneratorReturnsArmorAtLevel()
        {
            while (TestShouldKeepRunning())
            {
                var level = GetNewLevel();
                var armor = armorGenerator.GenerateAtLevel(level);

                Assert.That(armor, Is.Not.Null);
                Assert.That(armor.Name, Is.Not.Empty);
                Assert.That(armor.MagicalBonus, Is.Not.Negative);
                Assert.That(armor.Abilities, Is.Not.Null);
                Assert.That(armor.Traits, Is.Not.Null);
            }

            AssertIterations();
        }
    }
}