using DnDGen.TreasureGen.Generators.Items.Magical;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalItemGeneratorTraitsDecoratorTests
    {
        private MagicalItemGenerator decorator;
        private Mock<IMagicalItemTraitsGenerator> mockTraitsGenerator;
        private Mock<MagicalItemGenerator> mockInnerGenerator;
        private Item item;

        [SetUp]
        public void Setup()
        {
            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockInnerGenerator = new Mock<MagicalItemGenerator>();
            item = new Item();
            decorator = new MagicalItemGeneratorTraitsDecorator(mockInnerGenerator.Object, mockTraitsGenerator.Object);

            item.ItemType = "item type";
            item.IsMagical = true;
            mockInnerGenerator.Setup(g => g.GenerateFrom("power")).Returns(item);
        }

        [Test]
        public void GetItemFromInnerGenerator()
        {
            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem, Is.EqualTo(item));
        }

        [Test]
        public void GetTraitsForItem()
        {
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Is.EquivalentTo(traits));
        }

        [Test]
        public void EmptyTraitsIsAlright()
        {
            var traits = Enumerable.Empty<string>();
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Is.Empty);
        }

        [Test]
        public void ItemCanHaveTraitsFromInnerGenerator()
        {
            item.Traits.Add("inner trait");
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom("power");

            foreach (var trait in traits)
                Assert.That(decoratedItem.Traits, Contains.Item(trait));

            Assert.That(decoratedItem.Traits, Contains.Item("inner trait"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(3));
        }

        [Test]
        public void EmptyGeneratedTraitsIsAlright()
        {
            item.Traits.Add("inner trait");
            var traits = Enumerable.Empty<string>();
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Contains.Item("inner trait"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void DoNotGetTraitsIfItemIsNotMagical()
        {
            item.IsMagical = false;
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom("power");
            Assert.That(decoratedItem.Traits, Is.Empty);
        }

        [Test]
        public void DecorateCustomItem()
        {
            var template = new Item();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, true)).Returns(item);
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom(template, allowRandomDecoration: true);
            Assert.That(decoratedItem, Is.Not.EqualTo(template));
            Assert.That(decoratedItem, Is.EqualTo(item));
            Assert.That(decoratedItem.Traits, Is.EquivalentTo(traits));
        }

        [Test]
        public void DoNotDecorateCustomItem()
        {
            var template = new Item();

            mockInnerGenerator.Setup(g => g.GenerateFrom(template, false)).Returns(item);
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom(template);
            Assert.That(decoratedItem, Is.Not.EqualTo(template));
            Assert.That(decoratedItem, Is.EqualTo(item));
            Assert.That(decoratedItem.Traits, Is.Empty);
        }

        [Test]
        public void GenerateFromSubset()
        {
            var subset = new[] { "item 1", "item 2" };
            var subsetItem = new Item();
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(subsetItem);

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem, Is.EqualTo(subsetItem));
        }

        [Test]
        public void GetTraitsForItemFromSubset()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(item);

            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem.Traits, Is.EquivalentTo(traits));
        }

        [Test]
        public void EmptyTraitsFromSubsetIsAlright()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(item);

            var traits = Enumerable.Empty<string>();
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem.Traits, Is.Empty);
        }

        [Test]
        public void ItemFromSubsetCanHaveTraitsFromInnerGenerator()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(item);

            item.Traits.Add("inner trait");
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom("power", subset);

            foreach (var trait in traits)
                Assert.That(decoratedItem.Traits, Contains.Item(trait));

            Assert.That(decoratedItem.Traits, Contains.Item("inner trait"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(3));
        }

        [Test]
        public void EmptyGeneratedTraitsFromSubsetIsAlright()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(item);

            item.Traits.Add("inner trait");
            var traits = Enumerable.Empty<string>();
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem.Traits, Contains.Item("inner trait"));
            Assert.That(decoratedItem.Traits.Count, Is.EqualTo(1));
        }

        [Test]
        public void DoNotGetTraitsIfItemFromSubsetIsNotMagical()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(item);

            item.IsMagical = false;
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(item.ItemType, item.Attributes)).Returns(traits);

            var decoratedItem = decorator.GenerateFrom("power", subset);
            Assert.That(decoratedItem.Traits, Is.Empty);
        }
    }
}