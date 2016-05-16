using NUnit.Framework;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class ItemTests
    {
        private Item item;

        [SetUp]
        public void Setup()
        {
            item = new Item();
        }

        [Test]
        public void NameInitialized()
        {
            Assert.That(item.Name, Is.Empty);
        }

        [Test]
        public void AttributesInitialized()
        {
            Assert.That(item.Attributes, Is.Empty);
        }

        [Test]
        public void MagicInitialized()
        {
            Assert.That(item.Magic, Is.Not.Null);
        }

        [Test]
        public void QuantityInitialized()
        {
            Assert.That(item.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void TraitsInitialized()
        {
            Assert.That(item.Traits, Is.Empty);
        }

        [Test]
        public void IsMagicalTrueIfSetToTrue()
        {
            item.IsMagical = true;
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void IsMagicalDefaultsToFalse()
        {
            Assert.That(item.IsMagical, Is.False);
        }

        [Test]
        public void IsMagicalFalseIfSetToFalse()
        {
            item.IsMagical = true;
            item.IsMagical = false;
            Assert.That(item.IsMagical, Is.False);
        }

        [Test]
        public void IsMagicalTrueIfThereIsABonus()
        {
            item.Magic.Bonus = 1;
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void IsMagicalTrueIfThereAreCharges()
        {
            item.Magic.Charges = 1;
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void IsMagicalTrueIfThereIsACurse()
        {
            item.Magic.Curse = "curse";
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void IsMagicalTrueIfThereIsIntelligenceWithEgo()
        {
            item.Magic.Intelligence.Ego = 1;
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void IsMagicalTrueIfThereAreSpecialAbilities()
        {
            item.Magic.SpecialAbilities = new[] { new SpecialAbility() };
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void ContentsInitialized()
        {
            Assert.That(item.Contents, Is.Empty);
        }

        [Test]
        public void ItemTypeInitialized()
        {
            Assert.That(item.ItemType, Is.Empty);
        }
    }
}