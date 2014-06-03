using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class SpecificGearGeneratorTests : StressTests
    {
        [Inject]
        public ISpecificGearGenerator SpecificGearGenerator { get; set; }

        protected override void MakeAssertions()
        {
            var power = GetNewPower(false);
            var specificGearType = GetNewSpecificGearType();
            var gear = SpecificGearGenerator.GenerateFrom(power, specificGearType);

            if (gear.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            Assert.That(gear.Name, Is.Not.Empty);
            Assert.That(gear.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(gear.Quantity, Is.EqualTo(1));
            Assert.That(gear.Traits, Is.Not.Null);
            Assert.That(gear.Contents, Is.Not.Null);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Armor).Or.EqualTo(ItemTypeConstants.Weapon));

            if (!gear.IsMagical)
                return;

            Assert.That(gear.Magic.Bonus, Is.AtLeast(0), gear.Name);
            Assert.That(gear.Magic.Charges, Is.AtLeast(0));
            Assert.That(gear.Magic.Curse, Is.Not.Null);
            Assert.That(gear.Magic.SpecialAbilities, Is.Not.Null);
            Assert.That(gear.Magic.Intelligence, Is.Not.Null);
        }

        private String GetNewSpecificGearType()
        {
            switch (Random.Next(3))
            {
                case 0: return "SpecificArmors";
                case 1: return "SpecificShields";
                case 2: return "SpecificWeapons";
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}