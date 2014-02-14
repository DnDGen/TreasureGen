using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class WondrousItemGeneratorTests : StressTest
    {
        [Inject]
        public IMagicalItemGeneratorFactory MagicalItemGeneratorFactory { get; set; }

        private IMagicalItemGenerator wondrousItemGenerator;

        [SetUp]
        public void Setup()
        {
            wondrousItemGenerator = MagicalItemGeneratorFactory.CreateWith(ItemTypeConstants.WondrousItem);

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void StressedWondrousItemGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var power = GetNewPower(false);
                var item = wondrousItemGenerator.GenerateAtPower(power);

                Assert.That(item.Name, Is.Not.Empty);
                Assert.That(item.Traits, Is.Not.Null);
                Assert.That(item.Charges, Is.Not.Negative);
                Assert.That(item.Types, Is.Not.Null);

                if (item.Intelligence.IsIntelligent)
                {
                    Assert.That(item.Intelligence.Alignment, Is.Not.Empty);
                    Assert.That(item.Intelligence.CharismaStat, Is.AtLeast(10));
                    Assert.That(item.Intelligence.Communication, Is.Not.Empty);
                    Assert.That(item.Intelligence.Ego, Is.AtLeast(3));
                    Assert.That(item.Intelligence.IntelligenceStat, Is.AtLeast(10));
                    Assert.That(item.Intelligence.Powers, Is.Not.Empty);
                    Assert.That(item.Intelligence.DedicatedPower, Is.Not.Null);
                    Assert.That(item.Intelligence.Senses, Is.Not.Empty);
                    Assert.That(item.Intelligence.SpecialPurpose, Is.Not.Null);
                    Assert.That(item.Intelligence.WisdomStat, Is.AtLeast(10));

                    Assert.That(item.Types, Is.Not.Contains(TypeConstants.OneTimeUse));
                }
            }

            AssertIterations();
        }
    }
}