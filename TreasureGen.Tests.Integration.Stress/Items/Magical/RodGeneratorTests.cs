using Ninject;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class RodGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Rod)]
        public MagicalItemGenerator RodGenerator { get; set; }

        [TestCase("Rod generator")]
        public override void Stress(string thingToStress)
        {
            Stress();
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Rod; }
        }

        protected override void MakeAssertionsAgainst(Item rod)
        {
            Assert.That(rod.Name, Is.Not.Empty);
            Assert.That(rod.Attributes, Is.Not.Null);
            Assert.That(rod.Contents, Is.Not.Null);
            Assert.That(rod.IsMagical, Is.True);
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.Magic.Bonus, Is.AtLeast(0));
            Assert.That(rod.Magic.Charges, Is.AtLeast(0));
            Assert.That(rod.Magic.SpecialAbilities, Is.Empty);
            Assert.That(rod.Quantity, Is.EqualTo(1));
            Assert.That(rod.Traits, Is.Not.Null);

            var rodMaterials = rod.Traits.Intersect(materials);
            Assert.That(rodMaterials, Is.Empty);
        }

        protected override Item GenerateItem()
        {
            var power = GetNewPower(allowMinor: false);
            return RodGenerator.GenerateAtPower(power);
        }

        [Test]
        public void ChargesHappen()
        {
            var rod = GenerateOrFail(r => r.Attributes.Contains(AttributeConstants.Charged));
            Assert.That(rod.Magic.Charges, Is.Positive);
        }

        [Test]
        public void ChargesDoNotHappen()
        {
            var rod = GenerateOrFail(r => r.Attributes.Contains(AttributeConstants.Charged) == false);
            Assert.That(rod.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void ContentsHappen()
        {
            GenerateOrFail(r => r.Contents.Any());
        }

        [Test]
        public void ContentsDoNotHappen()
        {
            GenerateOrFail(r => r.Contents.Any() == false);
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