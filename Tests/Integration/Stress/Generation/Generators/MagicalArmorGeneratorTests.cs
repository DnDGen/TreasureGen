using EquipmentGen.Core.Data.Items.Constants;
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
                Assert.That(armor.Charges, Is.Not.Negative);

                if (armor.Intelligence.IsIntelligent)
                {
                    Assert.That(armor.Intelligence.Alignment, Is.Not.Empty);
                    Assert.That(armor.Intelligence.CharismaStat, Is.AtLeast(10));
                    Assert.That(armor.Intelligence.Communication, Is.Not.Empty);
                    Assert.That(armor.Intelligence.Ego, Is.AtLeast(3));
                    Assert.That(armor.Intelligence.IntelligenceStat, Is.AtLeast(10));
                    Assert.That(armor.Intelligence.Powers, Is.Not.Empty);
                    Assert.That(armor.Intelligence.DedicatedPower, Is.Not.Null);
                    Assert.That(armor.Intelligence.Senses, Is.Not.Empty);
                    Assert.That(armor.Intelligence.SpecialPurpose, Is.Not.Null);
                    Assert.That(armor.Intelligence.WisdomStat, Is.AtLeast(10));
                }
                else
                {
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
            }

            AssertIterations();
        }
    }
}