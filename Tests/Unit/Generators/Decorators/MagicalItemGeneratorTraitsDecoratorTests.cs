using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Decorators;
using TreasureGen.Generators.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Decorators
{
    [TestFixture]
    public class MagicalItemGeneratorTraitsDecoratorTests
    {
        private IMagicalItemGenerator decorator;
        private Mock<IMagicalItemTraitsGenerator> mockTraitsGenerator;
        private Mock<IMagicalItemGenerator> mockInnerGenerator;
        private Item item;

        [SetUp]
        public void Setup()
        {
            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockInnerGenerator = new Mock<IMagicalItemGenerator>();
            item = new Item();
            decorator = new MagicalItemGeneratorTraitsDecorator(mockInnerGenerator.Object, mockTraitsGenerator.Object);

            item.ItemType = "item type";
            item.IsMagical = true;
            mockInnerGenerator.Setup(g => g.GenerateAtPower("power")).Returns(item);
        }

        [Test]
        public void GetItemFromInnerGenerator()
        {
            var decoratedItem = decorator.GenerateAtPower("power");
            Assert.That(decoratedItem, Is.EqualTo(item));
        }

        [Test]
        public void GetTraitsForItem()
        {
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateAtPower("power");

            Assert.That(decoratedItem.Traits, Is.SubsetOf(traits));
            Assert.That(traits, Is.SubsetOf(decoratedItem.Traits));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(traits.Count()));
        }

        [Test]
        public void EmptyTraitsIsAlright()
        {
            var traits = Enumerable.Empty<String>();
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateAtPower("power");
            Assert.That(decoratedItem.Traits, Is.Empty);
        }

        [Test]
        public void ItemCanHaveTraitsFromInnerGenerator()
        {
            item.Traits.Add("inner trait");
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateAtPower("power");

            foreach (var trait in traits)
                Assert.That(decoratedItem.Traits, Contains.Item(trait));

            Assert.That(decoratedItem.Traits, Contains.Item("inner trait"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(3));
        }

        [Test]
        public void EmptyGeneratedTraitsIsAlright()
        {
            item.Traits.Add("inner trait");
            var traits = Enumerable.Empty<String>();
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateAtPower("power");
            Assert.That(decoratedItem.Traits, Contains.Item("inner trait"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void DoNotGetTraitsIfItemIsNotMagical()
        {
            item.IsMagical = false;
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateAtPower("power");
            Assert.That(decoratedItem.Traits, Is.Empty);
        }
    }
}