using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Domain.Decorators;
using TreasureGen.Generators.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Decorators
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
            mockInnerGenerator.Setup(g => g.GenerateAtPower("power")).Returns(innerItem);
        }

        [Test]
        public void GetItemFromInnerGenerator()
        {
            var item = intelligenceDecorator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(innerItem));
        }

        [Test]
        public void DoNotGetIntelligenceIfNotIntelligent()
        {
            var intelligence = new Intelligence();
            intelligence.Ego = 9266;
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(innerItem.ItemType, innerItem.Attributes, It.IsAny<Boolean>())).Returns(false);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Item>())).Returns(intelligence);

            var item = intelligenceDecorator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(innerItem));
            Assert.That(item.Magic.Intelligence, Is.Not.EqualTo(intelligence));
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(0));
        }

        [Test]
        public void GetIntelligenceIfIntelligent()
        {
            var intelligence = new Intelligence();
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(innerItem.ItemType, innerItem.Attributes, It.IsAny<Boolean>())).Returns(true);
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Item>())).Returns(intelligence);

            var item = intelligenceDecorator.GenerateAtPower("power");
            Assert.That(item, Is.EqualTo(innerItem));
            Assert.That(item.Magic.Intelligence, Is.EqualTo(intelligence));
        }
    }
}