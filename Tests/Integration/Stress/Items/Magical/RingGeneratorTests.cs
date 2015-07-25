using Ninject;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class RingGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Ring)]
        public IMagicalItemGenerator RingGenerator { get; set; }

        [TestCase("Ring generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override String itemType
        {
            get { return ItemTypeConstants.Ring; }
        }

        protected override void MakeAssertionsAgainst(Item ring)
        {
            Assert.That(ring.Name, Is.StringStarting("Ring of "));
            Assert.That(ring.Traits, Is.Not.Null);
            Assert.That(ring.Attributes, Is.Not.Null);
            Assert.That(ring.Quantity, Is.EqualTo(1));
            Assert.That(ring.IsMagical, Is.True);
            Assert.That(ring.Contents, Is.Not.Null);
            Assert.That(ring.ItemType, Is.EqualTo(ItemTypeConstants.Ring));
            Assert.That(ring.Magic.Bonus, Is.Not.Negative);
            Assert.That(ring.Magic.Charges, Is.Not.Negative);
            Assert.That(ring.Magic.SpecialAbilities, Is.Empty);

            var itemMaterials = ring.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Empty);
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower();
            return RingGenerator.GenerateAtPower(power);
        }

        [Test]
        public void ChargesHappen()
        {
            Item ring;

            do ring = GenerateItem();
            while (TestShouldKeepRunning() && !ring.Attributes.Contains(AttributeConstants.Charged));

            Assert.That(ring.Attributes, Contains.Item(AttributeConstants.Charged));
            Assert.That(ring.Magic.Charges, Is.Positive);
            AssertIterations();
        }

        [Test]
        public void ChargesDoNotHappen()
        {
            Item ring;

            do ring = GenerateItem();
            while (TestShouldKeepRunning() && ring.Attributes.Contains(AttributeConstants.Charged));

            Assert.That(ring.Attributes, Is.Not.Contains(AttributeConstants.Charged));
            Assert.That(ring.Magic.Charges, Is.EqualTo(0));
            AssertIterations();
        }

        [Test]
        public void ContentsHappen()
        {
            Item ring;

            do ring = GenerateItem();
            while (TestShouldKeepRunning() && !ring.Contents.Any());

            Assert.That(ring.Contents, Is.Not.Empty);
            AssertIterations();
        }

        [Test]
        public void ContentsDoNotHappen()
        {
            Item ring;

            do ring = GenerateItem();
            while (TestShouldKeepRunning() && ring.Contents.Any());

            Assert.That(ring.Contents, Is.Empty);
            AssertIterations();
        }

        [Test]
        public override void IntelligenceHappens()
        {
            base.IntelligenceHappens();
        }

        [Test]
        public override void TraitsHappen()
        {
            base.TraitsHappen();
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