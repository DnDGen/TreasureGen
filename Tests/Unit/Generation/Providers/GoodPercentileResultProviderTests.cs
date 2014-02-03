using System.Linq;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Providers
{
    [TestFixture]
    public class GoodPercentileResultProviderTests
    {
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private IGoodPercentileResultProvider provider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            provider = new GoodPercentileResultProvider(mockPercentileResultProvider.Object);
        }

        [Test]
        public void GoodValuePercentileComesFromProvider()
        {
            var tableName = "goodTypeValue";
            mockPercentileResultProvider.Setup(p => p.GetResultFrom(tableName)).Returns("value roll,description 1,description 2");

            var result = provider.GetResultFrom(tableName);
            Assert.That(result.ValueRoll, Is.EqualTo("value roll"));
            Assert.That(result.Descriptions, Contains.Item("description 1"));
            Assert.That(result.Descriptions, Contains.Item("description 2"));
            Assert.That(result.Descriptions.Count(), Is.EqualTo(2));
        }
    }
}