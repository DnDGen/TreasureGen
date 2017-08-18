using EventGen;
using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Selections;

namespace TreasureGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class SpecialAbilityDataSelectorEventDecoratorTests
    {
        private ISpecialAbilityDataSelector selector;
        private Mock<ISpecialAbilityDataSelector> mockInnerSelector;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ISpecialAbilityDataSelector>();
            mockEventQueue = new Mock<GenEventQueue>();
            selector = new SpecialAbilityDataSelectorEventDecorator(mockInnerSelector.Object, mockEventQueue.Object);
        }

        [Test]
        public void DoNotLogIsSpecialAbilityEvents()
        {
            mockInnerSelector.Setup(s => s.IsSpecialAbility("ability name")).Returns(true);

            var isAbility = selector.IsSpecialAbility("ability name");
            Assert.That(isAbility, Is.True);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void DoNotLogIsNotSpecialAbilityEvents()
        {
            mockInnerSelector.Setup(s => s.IsSpecialAbility("ability name")).Returns(false);

            var isAbility = selector.IsSpecialAbility("ability name");
            Assert.That(isAbility, Is.False);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void LogGenerationEvents()
        {
            var abilitySelection = new SpecialAbilitySelection();
            abilitySelection.BaseName = "base name";
            abilitySelection.BonusEquivalent = 9266;
            abilitySelection.Power = 90210;

            mockInnerSelector.Setup(s => s.SelectFrom("ability name")).Returns(abilitySelection);

            var ability = selector.SelectFrom("ability name");
            Assert.That(ability, Is.EqualTo(abilitySelection));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Selecting data for special ability ability name"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Selected data for special ability ability name"), Times.Once);
        }
    }
}
