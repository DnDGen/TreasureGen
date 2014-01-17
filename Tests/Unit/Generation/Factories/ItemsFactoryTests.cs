using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class ItemsFactoryTests
    {
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
        private IItemsFactory factory;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            factory = new ItemsFactory(mockTypeAndAmountPercentileResultProvider.Object);
        }

        [Test]
        public void ItemsAreGenerated()
        {
            var items = factory.CreateAtLevel(1);
            Assert.That(items, Is.Not.Null);
        }

        [Test]
        public void ItemsFactoryGetsItemTypeFromItemPercentileResultProvider()
        {
            factory.CreateAtLevel(1);
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetTypeAndAmountPercentileResult("Level1Items"), Times.Once);
        }
    }
}