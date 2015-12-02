using Ninject;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class ScrollGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Scroll)]
        public IMagicalItemGenerator ScrollGenerator { get; set; }

        [TestCase("Scroll generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override String itemType
        {
            get { return ItemTypeConstants.Scroll; }
        }

        protected override void MakeAssertionsAgainst(Item scroll)
        {
            Assert.That(scroll.Name, Is.EqualTo(ItemTypeConstants.Scroll));
            Assert.That(scroll.Traits, Contains.Item("Arcane").Or.Contains("Divine"));
            Assert.That(scroll.Traits.Count, Is.EqualTo(1));
            Assert.That(scroll.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
            Assert.That(scroll.Attributes.Count(), Is.EqualTo(1));
            Assert.That(scroll.Quantity, Is.EqualTo(1));
            Assert.That(scroll.IsMagical, Is.True);
            Assert.That(scroll.Contents, Is.Not.Empty);
            Assert.That(scroll.ItemType, Is.EqualTo(ItemTypeConstants.Scroll));
            Assert.That(scroll.Magic.Bonus, Is.EqualTo(0));
            Assert.That(scroll.Magic.Charges, Is.EqualTo(0));
            Assert.That(scroll.Magic.Curse, Is.Not.Null);
            Assert.That(scroll.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(scroll.Magic.SpecialAbilities, Is.Empty);
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower();
            return ScrollGenerator.GenerateAtPower(power);
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
            GenerateOrFail(s => s.Traits.Count == 1 && s.Magic.Curse == String.Empty && s.Magic.Intelligence.Ego == 0);
        }

        [Test]
        public override void SpecificCursedItemsAreIntelligent()
        {
            AssertSpecificCursedItemsAreIntelligent();
        }

        [Test]
        public override void SpecificCursedItemsAreNotDecorated()
        {
            AssertSpecificCursedItemsAreNotDecorated();
        }

        [Test]
        public override void SpecificCursedItemsHaveTraits()
        {
            AssertSpecificCursedItemsHaveTraits();
        }

        [Test]
        public override void SpecificCursedItemsDoNotHaveSpecialMaterials()
        {
            AssertSpecificCursedItemsDoNotHaveSpecialMaterials();
        }
    }
}