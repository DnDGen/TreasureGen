using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
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

                Assert.That(item.Name, Is.StringStarting("Ring of "));
                Assert.That(item.Traits, Is.Not.Null);
                Assert.That(item.Attributes, Is.Not.Null);
                Assert.That(item.Quantity, Is.EqualTo(1));
                Assert.That(item.Magic[Magic.IsMagical], Is.True);
            }

            AssertIterations();
        }
    }
}