using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class SpecificGearGeneratorTests : StressTests
    {
        [Inject]
        public ISpecificGearGenerator SpecificGearGenerator { get; set; }

        [TestCase("Specific gear generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var gear = GenerateSpecificGear();

            Assert.That(gear.Name, Is.Not.Empty);
            Assert.That(gear.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(gear.Quantity, Is.EqualTo(1));
            Assert.That(gear.Traits, Is.Not.Null);
            Assert.That(gear.Contents, Is.Not.Null);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Armor).Or.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(gear.Magic.Bonus, Is.Not.Negative, gear.Name);
            Assert.That(gear.Magic.Charges, Is.Not.Negative);
            Assert.That(gear.Magic.Curse, Is.Not.Null);
            Assert.That(gear.Magic.SpecialAbilities, Is.Not.Null);
            Assert.That(gear.Magic.Intelligence, Is.Not.Null);
        }

        private Item GenerateSpecificGear()
        {
            var power = GetNewPower(false);
            var specificGearType = GetNewSpecificGearType();
            return SpecificGearGenerator.GenerateFrom(power, specificGearType);
        }

        private String GetNewSpecificGearType()
        {
            switch (Random.Next(3))
            {
                case 0: return ItemTypeConstants.Armor;
                case 1: return AttributeConstants.Shield;
                default: return ItemTypeConstants.Weapon;
            }
        }

        [Test]
        public void MagicalGearHappens()
        {
            Item gear;

            do gear = GenerateSpecificGear();
            while (TestShouldKeepRunning() && gear.IsMagical == false);

            Assert.That(gear.IsMagical, Is.True);
            AssertIterations();
        }

        [Test]
        public void MundaneGearHappens()
        {
            Item gear;

            do gear = GenerateSpecificGear();
            while (TestShouldKeepRunning() && gear.IsMagical);

            Assert.That(gear.IsMagical, Is.False);
            AssertIterations();
        }
    }
}