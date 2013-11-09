using D20Dice.Dice;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace EquipmentGen.Tests.Generation.Xml.Data
{
    [TestFixture]
    public abstract class PercentileTests
    {
        protected String tableName;

        private Mock<IDice> mockDice;
        private IPercentileResultProvider percentileResultProvider;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            percentileResultProvider = ProviderFactory.CreatePercentileResultProviderUsing(mockDice.Object);
        }

        protected void AssertEmpty(Int32 roll)
        {
            AssertContent(String.Empty, roll);
        }

        protected void AssertEmpty(Int32 minInclusive, Int32 maxInclusive)
        {
            AssertContent(String.Empty, minInclusive, maxInclusive);
        }

        protected void AssertContent(String content, Int32 minInclusive, Int32 maxInclusive)
        {
            for (var roll = 1; roll <= 100; roll++)
            {
                if (roll >= minInclusive && roll <= maxInclusive)
                    AssertRollGrantsContent(roll, content);
                else
                    AssertRollDoesNotGrantContent(roll, content);
            }
        }

        protected void AssertContent(String content, Int32 roll)
        {
            AssertContent(content, roll, roll);
        }

        private void AssertRollGrantsContent(Int32 roll, String content)
        {
            var result = GetResult(roll);
            Assert.That(result, Is.EqualTo(content), String.Format("Roll: {0}", roll));
        }

        private void AssertRollDoesNotGrantContent(Int32 roll, String content)
        {
            var result = GetResult(roll);
            Assert.That(result, Is.Not.EqualTo(content), String.Format("Roll: {0}", roll));
        }

        private String GetResult(Int32 roll)
        {
            mockDice.Setup(d => d.Percentile(1, 0)).Returns(roll);
            return percentileResultProvider.GetPercentileResult(tableName);
        }
    }
}