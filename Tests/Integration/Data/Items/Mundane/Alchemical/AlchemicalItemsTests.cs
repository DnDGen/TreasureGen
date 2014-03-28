using System;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Alchemical
{
    [TestFixture, PercentileTable("AlchemicalItems")]
    public class AlchemicalItemsTests : PercentileTests
    {
        [TestCase("Alchemist's fire,1d4", 1, 12)]
        [TestCase("Acid,2d4", 13, 24)]
        [TestCase("Smokestick,1d4", 25, 36)]
        [TestCase("Holy water,1d4", 37, 48)]
        [TestCase("Antitoxin,1d4", 49, 62)]
        [TestCase("Everburning torch,1", 63, 74)]
        [TestCase("Tanglefoot bag,1d4", 75, 88)]
        [TestCase("Thunderstone,1d4", 89, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}