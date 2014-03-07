using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class MagicalArmorGeneratorTests : StressTests
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
                Assert.That(armor.Traits, Is.Not.Null);
                Assert.That(armor.Attributes, Contains.Item(ItemTypeConstants.Armor));
                Assert.That(armor.Quantity, Is.EqualTo(1));
                Assert.That(armor.Magic, Is.Not.Null);
            }

            AssertIterations();
        }
    }
}