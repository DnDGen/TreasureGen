using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class KnowledgeCategoriesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "KnowledgeCategories";
        }

        [TestCase("Arcana", 1, 10)]
        [TestCase("Architecture", 11, 20)]
        [TestCase("Dungeoneering", 21, 30)]
        [TestCase("Geography", 31, 40)]
        [TestCase("History", 41, 50)]
        [TestCase("Local", 51, 60)]
        [TestCase("Nature", 61, 70)]
        [TestCase("Nobility", 71, 80)]
        [TestCase("Religion", 81, 90)]
        [TestCase("The planes", 91, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}