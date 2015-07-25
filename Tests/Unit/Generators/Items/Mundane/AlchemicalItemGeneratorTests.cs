using TreasureGen.Common.Items;
using TreasureGen.Generators.Interfaces.Items.Mundane;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors.Interfaces;
using TreasureGen.Selectors.Interfaces.Objects;
using TreasureGen.Tables.Interfaces;
using Moq;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class AlchemicalItemGeneratorTests
    {
        private IMundaneItemGenerator generator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            generator = new AlchemicalItemGenerator(mockTypeAndAmountPercentileSelector.Object);
            result = new TypeAndAmountPercentileResult();
        }

        [Test]
        public void GenerateAlchemicalItem()
        {
            result.Type = "alchemical item";
            result.Amount = 9266;
            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.AlchemicalItems)).Returns(result);

            var item = generator.Generate();
            Assert.That(item.Name, Is.EqualTo(result.Type));
            Assert.That(item.Quantity, Is.EqualTo(9266));
            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.AlchemicalItem));
        }
    }
}