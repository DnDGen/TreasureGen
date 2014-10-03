using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Potion)]
        public IMagicalItemGenerator PotionGenerator { get; set; }

        [TestCase("Potion generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override String itemType
        {
            get { return ItemTypeConstants.Potion; }
        }

        protected override void MakeAssertionsAgainst(Item potion)
        {
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

        protected override Item GenerateItem()
        {
            var power = GetNewPower();
            return PotionGenerator.GenerateAtPower(power);
        }

        [Test]
        public override void CursesHappen()
        {
            AssertCursesHappen();
        }

        [Test]
        public override void SpecificCursesHappen()
        {
            AssertSpecificCursesHappen();
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            AssertNoDecorationsHappen();
        }

        [Test]
        public override void SpecificCursedItemsAreIntelligent()
        {
            AssertSpecificCursedItemsAreIntelligent();
        }

        [Test]
        public override void SpecificCursedItemsHaveTraits()
        {
            AssertSpecificCursedItemsHaveTraits();
        }

        [Test]
        public override void SpecificCursedItemsHaveSpecialMaterials()
        {
            AssertSpecificCursedItemsHaveSpecialMaterials();
        }

        [Test]
        public override void SpecificCursedItemsAreNotDecorated()
        {
            AssertSpecificCursedItemsAreNotDecorated();
        }
    }
}