using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class RingGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Ring)]
        public IMagicalItemGenerator RingGenerator { get; set; }

        [Test]
        public void StressedRingGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var ring = RingGenerator.GenerateAtPower(power);

            if (ring.Magic.ContainsKey(Magic.Curse) && ring.Magic[Magic.Curse] == "This is a specific cursed item")
                return;

            Assert.That(ring.Name, Is.StringStarting("Ring of "));
            Assert.That(ring.Traits, Is.Not.Null);
            Assert.That(ring.Attributes, Is.Not.Null);
            Assert.That(ring.Quantity, Is.EqualTo(1));
            Assert.That(ring.Magic[Magic.IsMagical], Is.True);
        }
    }
}