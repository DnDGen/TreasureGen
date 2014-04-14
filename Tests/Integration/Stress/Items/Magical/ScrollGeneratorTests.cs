using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class ScrollGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Scroll)]
        public IMagicalItemGenerator ScrollGenerator { get; set; }

        [Test]
        public void StressedScrollGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var scroll = ScrollGenerator.GenerateAtPower(power);

            if (scroll.Magic.Curse == "This is a specific cursed item")
                return;

            Assert.That(scroll.Name, Is.EqualTo("Divine scroll").Or.EqualTo("Arcane scroll"));
            Assert.That(scroll.Traits, Is.Not.Empty);
            Assert.That(scroll.Attributes, Is.Not.Null);
            Assert.That(scroll.Quantity, Is.EqualTo(1));
            Assert.That(scroll.IsMagical, Is.True);
        }
    }
}