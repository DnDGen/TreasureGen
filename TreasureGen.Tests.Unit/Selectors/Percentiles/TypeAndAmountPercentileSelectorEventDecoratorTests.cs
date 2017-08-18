using EventGen;
using Moq;
using NUnit.Framework;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;

namespace TreasureGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class TypeAndAmountPercentileSelectorEventDecoratorTests
    {
        private ITypeAndAmountPercentileSelector selector;
        private Mock<ITypeAndAmountPercentileSelector> mockInnerSelector;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockEventQueue = new Mock<GenEventQueue>();
            selector = new TypeAndAmountPercentileSelectorEventDecorator(mockInnerSelector.Object, mockEventQueue.Object);
        }

        [Test]
        public void DoNotLogSelectFromEvents()
        {
            var selection = new TypeAndAmountSelection();
            mockInnerSelector.Setup(s => s.SelectFrom("table name")).Returns(selection);

            var typeAndAmount = selector.SelectFrom("table name");
            Assert.That(typeAndAmount, Is.EqualTo(selection));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void LogSelectAllFromEvents()
        {
            var selections = new[] { new TypeAndAmountSelection(), new TypeAndAmountSelection() };
            mockInnerSelector.Setup(s => s.SelectAllFrom("table name")).Returns(selections);

            var typesAndAmounts = selector.SelectAllFrom("table name");
            Assert.That(typesAndAmounts, Is.EqualTo(selections));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Selecting all types and amounts from table name"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", $"Selected 2 types and amounts from table name"), Times.Once);
        }
    }
}
