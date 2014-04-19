using System;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class SpeciicGearGeneratorTests : StressTests
    {
        [Inject]
        public ISpecificGearGenerator SpecificGearGenerator { get; set; }

        [Test]
        public void StressedSpecificGearGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var specificGearType = GetNewSpecificGearType();
            var gear = SpecificGearGenerator.GenerateFrom(power, specificGearType);

            if (gear.Magic.Curse == "This is a specific cursed item")
                return;

            Assert.That(gear.Name, Is.Not.Empty);
            Assert.That(gear.Attributes, Is.Not.Empty);
            Assert.That(gear.Quantity, Is.EqualTo(1));
            Assert.That(gear.Traits, Is.Not.Null);

            if (!gear.IsMagical)
                return;

            Assert.That(gear.Magic.Bonus, Is.AtLeast(0));
            Assert.That(gear.Magic.Charges, Is.AtLeast(0));
            Assert.That(gear.Magic.Curse, Is.Not.Null);
            Assert.That(gear.Magic.SpecialAbilities, Is.Not.Null);
            Assert.That(gear.Magic.Intelligence, Is.Not.Null);
        }

        private String GetNewSpecificGearType()
        {
            switch (Random.Next(3))
            {
                case 0: return "SpecificArmor";
                case 1: return "SpecificShield";
                case 2: return "SpecificWeapon";
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}