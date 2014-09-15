using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalWeaponGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Weapon)]
        public IMagicalItemGenerator MagicalWeaponGenerator { get; set; }

        [TestCase("Magical weapon generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertionsAgainst(Item weapon)
        {
            Assert.That(weapon.Name, Is.Not.Empty);
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Common).Or.Contains(AttributeConstants.Uncommon).Or.Contains(AttributeConstants.Specific));
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Melee).Or.Contains(AttributeConstants.Ranged));
            Assert.That(weapon.Contents, Is.Not.Null);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));

            if (weapon.IsMagical && !weapon.Attributes.Contains(AttributeConstants.Specific))
                Assert.That(weapon.Magic.Bonus, Is.GreaterThan(0), weapon.Name);

            if (weapon.Attributes.Contains(AttributeConstants.Ammunition))
                Assert.That(weapon.Quantity, Is.InRange<Int32>(1, 50));
            else
                Assert.That(weapon.Quantity, Is.EqualTo(1));

            Assert.That(weapon.Traits, Is.Not.Null);
            Assert.That(weapon.Magic.Charges, Is.AtLeast(0));
            Assert.That(weapon.Magic.SpecialAbilities, Is.Not.Null);

            if (weapon.Attributes.Contains(AttributeConstants.Charged))
                Assert.That(weapon.Magic.Charges, Is.GreaterThan(0));
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower();
            return MagicalWeaponGenerator.GenerateAtPower(power);
        }

        [Test]
        public void IntelligenceHappens()
        {
            AssertIntelligenceHappens();
        }

        [Test]
        public void TraitsHappen()
        {
            AssertTraitsHappen();
        }

        [Test]
        public void SpecialMaterialsHappen()
        {
            AssertSpecialMaterialsHappen();
        }
    }
}