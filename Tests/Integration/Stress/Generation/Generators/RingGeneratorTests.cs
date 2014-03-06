using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class RingGeneratorTests : StressTests
    {
        [Inject]
        public IMagicalItemGeneratorFactory MagicalItemGeneratorFactory { get; set; }

        private IMagicalItemGenerator ringGenerator;

        [SetUp]
        public void Setup()
        {
            ringGenerator = MagicalItemGeneratorFactory.CreateWith(ItemTypeConstants.Ring);

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void StressedRingGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var power = GetNewPower(false);
                var item = ringGenerator.GenerateAtPower(power);

                Assert.That(item.Name, Is.Not.Empty);
                Assert.That(item.Traits, Is.Not.Null);
                Assert.That(item.Attributes, Is.Not.Null);
                Assert.That(item.Quantity, Is.EqualTo(1));
                Assert.That(item.Magic[Magic.IsMagical], Is.True);
            }

            AssertIterations();
        }
    }
}