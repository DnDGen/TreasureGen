using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IntelligenceAlignmentsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "IntelligenceAlignments";
        }

        [TestCase("Chaotic good", 1, 5)]
        [TestCase("Chaotic neutral", 6, 15)]
        [TestCase("Chaotic evil", 16, 20)]
        [TestCase("Neutral evil", 21, 25)]
        [TestCase("Lawful evil", 26, 30)]
        [TestCase("Lawful good", 31, 55)]
        [TestCase("Lawful neutral", 56, 60)]
        [TestCase("Neutral good", 61, 80)]
        [TestCase("True neutral", 81, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}