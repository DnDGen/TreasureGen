using Moq;
using NUnit.Framework;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalItemGeneratorIntelligenceDecoratorTests
    {
        private MagicalItemGenerator intelligenceDecorator;
        private Mock<IIntelligenceGenerator> mockIntelligenceGenerator;
        private Mock<MagicalItemGenerator> mockInnerGenerator;

        private Item innerItem;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<MagicalItemGenerator>();
            mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            intelligenceDecorator = new MagicalItemGeneratorIntelligenceDecorator(mockInnerGenerator.Object, mockIntelligenceGenerator.Object);

            innerItem = new Item();
            innerItem.ItemType = "item type";
            innerItem.Attributes = new[] { "attribute 1", "attribute 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power")).Returns(innerItem);
        }

        [Test]
        public void GetItemFromInnerGenerator()
        {
            var item = intelligenceDecorator.GenerateFrom("power");
            Assert.That(item, Is.EqualTo(innerItem));
        }

        [Test]
        public void DoNotGetIntelligenceIfNotIntelligent()
        {
            var intelligence = new Intelligence();
            intelligence.Ego = 9266;
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(innerItem.ItemType, innerItem.Attributes, It.IsAny<bool>())).Returns(false);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Item>())).Returns(intelligence);

            var item = intelligenceDecorator.GenerateFrom("power");
            Assert.That(item, Is.EqualTo(innerItem));
            Assert.That(item.Magic.Intelligence, Is.Not.EqualTo(intelligence));
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(0));
        }

        [Test]
        public void GetIntelligenceIfIntelligent()
        {
            var intelligence = new Intelligence();
            intelligence.Ego = 9266;
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(innerItem.ItemType, innerItem.Attributes, It.IsAny<bool>())).Returns(true);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Item>())).Returns(intelligence);

            var item = intelligenceDecorator.GenerateFrom("power");
            Assert.That(item, Is.EqualTo(innerItem));
            Assert.That(item.Magic.Intelligence, Is.EqualTo(intelligence));
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(9266));
        }

        [Test]
        public void DecorateCustomItem()
        {
            var template = new Item();
            mockInnerGenerator.Setup(g => g.GenerateFrom(template, true)).Returns(innerItem);

            var intelligence = new Intelligence();
            intelligence.Ego = 9266;
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(innerItem.ItemType, innerItem.Attributes, It.IsAny<bool>())).Returns(true);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Item>())).Returns(intelligence);

            var decoratedItem = intelligenceDecorator.GenerateFrom(template, allowRandomDecoration: true);
            Assert.That(decoratedItem, Is.Not.EqualTo(template));
            Assert.That(decoratedItem, Is.EqualTo(innerItem));
            Assert.That(decoratedItem.Magic.Intelligence, Is.EqualTo(intelligence));
            Assert.That(decoratedItem.Magic.Intelligence.Ego, Is.EqualTo(9266));
        }

        [Test]
        public void DoNotDecorateCustomItem()
        {
            var template = new Item();
            mockInnerGenerator.Setup(g => g.GenerateFrom(template, false)).Returns(innerItem);

            var intelligence = new Intelligence();
            intelligence.Ego = 9266;
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(innerItem.ItemType, innerItem.Attributes, It.IsAny<bool>())).Returns(true);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Item>())).Returns(intelligence);

            var decoratedItem = intelligenceDecorator.GenerateFrom(template);
            Assert.That(decoratedItem, Is.Not.EqualTo(template));
            Assert.That(decoratedItem, Is.EqualTo(innerItem));
            Assert.That(decoratedItem.Magic.Intelligence, Is.Not.EqualTo(intelligence));
            Assert.That(decoratedItem.Magic.Intelligence.Ego, Is.EqualTo(0));
        }

        [Test]
        public void GenerateFromSubset()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(innerItem);

            var item = intelligenceDecorator.GenerateFrom("power", subset);
            Assert.That(item, Is.EqualTo(innerItem));
        }

        [Test]
        public void SubsetDoesNotGetIntelligenceIfNotIntelligent()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(innerItem);

            var intelligence = new Intelligence();
            intelligence.Ego = 9266;
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(innerItem.ItemType, innerItem.Attributes, It.IsAny<bool>())).Returns(false);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Item>())).Returns(intelligence);

            var item = intelligenceDecorator.GenerateFrom("power", subset);
            Assert.That(item, Is.EqualTo(innerItem));
            Assert.That(item.Magic.Intelligence, Is.Not.EqualTo(intelligence));
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(0));
        }

        [Test]
        public void SubsetGetsIntelligenceIfIntelligent()
        {
            var subset = new[] { "item 1", "item 2" };
            mockInnerGenerator.Setup(g => g.GenerateFrom("power", subset)).Returns(innerItem);

            var intelligence = new Intelligence();
            intelligence.Ego = 9266;
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(innerItem.ItemType, innerItem.Attributes, It.IsAny<bool>())).Returns(true);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Item>())).Returns(intelligence);

            var item = intelligenceDecorator.GenerateFrom("power", subset);
            Assert.That(item, Is.EqualTo(innerItem));
            Assert.That(item.Magic.Intelligence, Is.EqualTo(intelligence));
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(9266));
        }
    }
}