using Ninject;
using NUnit.Framework;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class PotionGeneratorTests : MagicalItemGeneratorStressTests
    {
        [Inject, Named(ItemTypeConstants.Potion)]
        public MagicalItemGenerator PotionGenerator { get; set; }

        [TestCase("Potion generator")]
        public override void Stress(string thingToStress)
        {
            Stress();
        }

        protected override string itemType
        {
            get { return ItemTypeConstants.Potion; }
        }

        protected override void MakeAssertionsAgainst(Item potion)
        {
            Assert.That(potion.Name, Does.StartWith("Potion of ").Or.StartWith("Oil of "));
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