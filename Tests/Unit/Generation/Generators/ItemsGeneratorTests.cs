using System;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class ItemsGeneratorTests
    {
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;
        private Mock<IItemGenerator> mockPowerItemGenerator;
        private IItemsGenerator generator;

        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            result = new TypeAndAmountPercentileResult();
            result.Type = "power";
            result.Amount = 9266;
            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult(It.IsAny<String>())).Returns(result);

            mockPowerItemGenerator = new Mock<IItemGenerator>();

            generator = new ItemsGenerator(mockTypeAndAmountPercentileResultProvider.Object, mockPowerItemGenerator.Object);
        }

        [Test]
        public void ItemsAreGenerated()
        {
            var items = generator.GenerateAtLevel(1);
            Assert.That(items, Is.Not.Null);
        }

        [Test]
        public void ItemsGeneratorGetsItemTypeFromTypeAndAmountPercentileResultProvider()
        {
            generator.GenerateAtLevel(9266);
            mockTypeAndAmountPercentileResultProvider.Verify(p => p.GetTypeAndAmountPercentileResult("Level9266Items"), Times.Once);
        }

        [Test]
        public void ItemsGeneratorGetsAmountFromRoll()
        {
            var items = generator.GenerateAtLevel(1);
            Assert.That(items.Count(), Is.EqualTo(9266));
        }

        [Test]
        public void ItemsGeneratorReturnsItemsFromPowerItemGenerator()
        {
            result.Amount = 2;
            var firstItem = new AlchemicalItem();
            var secondItem = new BasicItem();
            mockPowerItemGenerator.SetupSequence(f => f.GenerateAtPower("power")).Returns(firstItem).Returns(secondItem);

            var items = generator.GenerateAtLevel(1);
            Assert.That(items.Count(), Is.EqualTo(2));
            Assert.That(items, Contains.Item(firstItem));
            Assert.That(items, Contains.Item(secondItem));
        }

        [Test]
        public void IfTypeAndAmountProviderReturnsEmptyResult_ItemsGeneratorReturnsEmptyEnumerable()
        {
            result.Type = String.Empty;
            result.Amount = 0;
            mockTypeAndAmountPercentileResultProvider.Setup(p => p.GetTypeAndAmountPercentileResult("Level1Items")).Returns(result);

            var items = generator.GenerateAtLevel(1);
            Assert.That(items, Is.Empty);
        }
    }
}