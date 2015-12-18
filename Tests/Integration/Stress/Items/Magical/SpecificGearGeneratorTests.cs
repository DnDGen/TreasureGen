using Ninject;
using NUnit.Framework;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class SpecificGearGeneratorTests : ItemTests
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
            var gear = GenerateItem();

            Assert.That(gear.Name, Is.Not.Empty);
            Assert.That(gear.Attributes, Contains.Item(AttributeConstants.Specific));
            Assert.That(gear.Quantity, Is.InRange(1, 20));
            Assert.That(gear.Traits, Is.Not.Null);
            Assert.That(gear.Contents, Is.Not.Null);
            Assert.That(gear.ItemType, Is.EqualTo(ItemTypeConstants.Armor).Or.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(gear.Magic.Bonus, Is.Not.Negative, gear.Name);
            Assert.That(gear.Magic.Charges, Is.Not.Negative);
            Assert.That(gear.Magic.Curse, Is.Not.Null);
            Assert.That(gear.Magic.SpecialAbilities, Is.Not.Null);
            Assert.That(gear.Magic.Intelligence, Is.Not.Null);
        }

        protected override Item GenerateItem()
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
            GenerateOrFail(g => g.IsMagical);
        }

        [Test]
        public void MundaneGearHappens()
        {
            GenerateOrFail(g => g.IsMagical == false);
        }

        [Test]
        public void SlayingArrowHappens()
        {
            var slayingArrow = GenerateOrFail(g => g.ItemType == ItemTypeConstants.Weapon && g.Name == WeaponConstants.SlayingArrow);
            Assert.That(slayingArrow.Name, Is.EqualTo(WeaponConstants.SlayingArrow));
            Assert.That(slayingArrow.Traits, Has.Some.StartsWith("Designated Foe: "));
        }

        [Test]
        public void GreaterSlayingArrowHappens()
        {
            var slayingArrow = GenerateOrFail(g => g.ItemType == ItemTypeConstants.Weapon && g.Name == WeaponConstants.GreaterSlayingArrow);
            Assert.That(slayingArrow.Name, Is.EqualTo(WeaponConstants.GreaterSlayingArrow));
            Assert.That(slayingArrow.Traits, Has.Some.StartsWith("Designated Foe: "));
        }

        [Test]
        public void LuckBladeWithWishesOccurs()
        {
            var luckBlade = GenerateOrFail(g => g.ItemType == ItemTypeConstants.Weapon && g.Name == WeaponConstants.LuckBlade && g.Magic.Charges > 0);
            Assert.That(luckBlade.Magic.Charges, Is.Positive);
        }
    }
}