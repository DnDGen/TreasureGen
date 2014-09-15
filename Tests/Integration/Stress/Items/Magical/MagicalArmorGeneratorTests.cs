using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class MagicalArmorGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Armor)]
        public IMagicalItemGenerator MagicalArmorGenerator { get; set; }

        [TestCase("Magical Armor generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertionsAgainst(Item armor)
        {
            Assert.That(armor.Name, Is.Not.Empty);
            Assert.That(armor.Traits, Is.Not.Null);
            Assert.That(armor.Attributes, Is.Not.Null);
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.Contents, Is.Not.Null);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor));
            Assert.That(armor.Magic.Charges, Is.EqualTo(0));
            Assert.That(armor.Magic.SpecialAbilities, Is.Not.Null);

            if (armor.IsMagical)
                Assert.That(armor.Magic.Bonus, Is.GreaterThan(0));
            else
                Assert.That(armor.Magic.Bonus, Is.EqualTo(0));
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower();
            return MagicalArmorGenerator.GenerateAtPower(power);
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