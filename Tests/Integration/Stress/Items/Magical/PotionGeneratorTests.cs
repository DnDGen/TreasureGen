using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Potion)]
        public IMagicalItemGenerator PotionGenerator { get; set; }

        [Test]
        public void StressedPotionGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var potion = PotionGenerator.GenerateAtPower(power);

            if (potion.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            Assert.That(potion.Name, Is.StringStarting("Potion of ").Or.StringStarting("Oil of "));
            Assert.That(potion.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(potion.Contents, Is.Empty);
            Assert.That(potion.IsMagical, Is.True);
            Assert.That(potion.Magic.Bonus, Is.AtLeast(0));
            Assert.That(potion.Magic.Charges, Is.EqualTo(0));
            Assert.That(potion.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(potion.Magic.SpecialAbilities, Is.Empty);
            Assert.That(potion.Quantity, Is.EqualTo(1));
            Assert.That(potion.Traits, Is.Empty);
            Assert.That(potion.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
        }
    }
}