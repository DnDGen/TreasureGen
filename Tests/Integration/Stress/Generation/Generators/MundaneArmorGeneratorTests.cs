using EquipmentGen.Core.Data.Items.Constants;
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
                Assert.That(armor.Abilities, Is.Empty);
                Assert.That(armor.MagicalBonus, Is.EqualTo(0));
                Assert.That(armor.Types, Contains.Item(ItemTypeConstants.Armor));
                Assert.That(armor.Charges, Is.EqualTo(0));
                Assert.That(armor.ChargesRenewable, Is.False);
                Assert.That(armor.Intelligence.IsIntelligent, Is.False);
                Assert.That(armor.Intelligence.Alignment, Is.Empty);
                Assert.That(armor.Intelligence.CharismaStat, Is.EqualTo(0));
                Assert.That(armor.Intelligence.Communication, Is.Empty);
                Assert.That(armor.Intelligence.Ego, Is.EqualTo(0));
                Assert.That(armor.Intelligence.IntelligenceStat, Is.EqualTo(0));
                Assert.That(armor.Intelligence.Powers, Is.Empty);
                Assert.That(armor.Intelligence.DedicatedPower, Is.Empty);
                Assert.That(armor.Intelligence.Senses, Is.Empty);
                Assert.That(armor.Intelligence.SpecialPurpose, Is.Empty);
                Assert.That(armor.Intelligence.WisdomStat, Is.EqualTo(0));
            }

            AssertIterations();
        }
    }
}