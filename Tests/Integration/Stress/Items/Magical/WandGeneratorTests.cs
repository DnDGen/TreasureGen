using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class WandGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Wand)]
        public IMagicalItemGenerator WandGenerator { get; set; }

        [Test]
        public void StressedWandGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var wand = WandGenerator.GenerateAtPower(power);

            if (wand.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            Assert.That(wand.Name, Is.StringStarting("Wand of"));
            Assert.That(wand.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(wand.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(wand.Contents, Is.Empty);
            Assert.That(wand.IsMagical, Is.True);
            Assert.That(wand.ItemType, Is.EqualTo(ItemTypeConstants.Wand));
            Assert.That(wand.Magic.Bonus, Is.EqualTo(0));
            Assert.That(wand.Magic.Charges, Is.InRange<Int32>(1, 50));
            Assert.That(wand.Magic.Curse, Is.Not.Null);
            Assert.That(wand.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(wand.Magic.SpecialAbilities, Is.Empty);
            Assert.That(wand.Quantity, Is.EqualTo(1));
            Assert.That(wand.Traits, Is.Not.Null);
        }
    }
}