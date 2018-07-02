using EventGen;
using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpecialAbilitiesGeneratorEventDecoratorTests
    {
        private ISpecialAbilitiesGenerator decorator;
        private Mock<ISpecialAbilitiesGenerator> mockInnerGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerGenerator = new Mock<ISpecialAbilitiesGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new SpecialAbilitiesGeneratorEventDecorator(mockInnerGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void LogGenerationEvents()
        {
            var innerItem = new Item();
            innerItem.Name = Guid.NewGuid().ToString();
            innerItem.ItemType = Guid.NewGuid().ToString();
            var innerAbilities = new[]
            {
                new SpecialAbility(),
                new SpecialAbility(),
            };

            mockInnerGenerator.Setup(g => g.GenerateFor(innerItem, "power", 9266)).Returns(innerAbilities);

            var abilities = decorator.GenerateFor(innerItem, "power", 9266);
            Assert.That(abilities, Is.EqualTo(innerAbilities));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generating 9266 power special abilities for {innerItem.Name}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generated 2 power special abilities for {innerItem.Name}"), Times.Once);
        }

        [Test]
        public void LogGenerationEventsForTemplate()
        {
            var innerAbilities = new[]
            {
                new SpecialAbility(),
                new SpecialAbility(),
            };

            var templateAbilities = new[]
            {
                new SpecialAbility(),
                new SpecialAbility(),
                new SpecialAbility(),
            };

            mockInnerGenerator.Setup(g => g.GenerateFor(templateAbilities)).Returns(innerAbilities);

            var item = decorator.GenerateFor(templateAbilities);
            Assert.That(item, Is.EqualTo(innerAbilities));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generating 3 special abilities from templates"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Generated 2 special abilities"), Times.Once);
        }
    }
}
