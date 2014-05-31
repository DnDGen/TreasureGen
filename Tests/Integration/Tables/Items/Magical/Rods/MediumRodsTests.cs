using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rods
{
    [TestFixture]
    public class MediumRodsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "MediumRods"; }
        }

        [TestCase("Rod of lesser metamagic: Enlarge,0", 1, 7)]
        [TestCase("Rod of lesser metamagic: Extend,0", 8, 14)]
        [TestCase("Rod of lesser metamagic: Silent,0", 15, 21)]
        [TestCase("Immovable rod,0", 22, 28)]
        [TestCase("Rod of lesser metamagic: Empower,0", 29, 35)]
        [TestCase("Rod of metal and mineral detection,0", 36, 42)]
        [TestCase("Rod of cancellation,0", 43, 53)]
        [TestCase("Rod of metamagic: Enlarge,0", 54, 57)]
        [TestCase("Rod of metamagic: Extend,0", 58, 61)]
        [TestCase("Rod of metamagic: Silent,0", 62, 65)]
        [TestCase("Rod of wonder,0", 66, 71)]
        [TestCase("Rod of the python,1", 72, 79)]
        [TestCase("Rod of lesser metamagic: Maximize,0", 80, 83)]
        [TestCase("Rod of flame extinguishing,0", 84, 89)]
        [TestCase("Rod of the viper,2", 90, 97)]
        [TestCase("Rod of metamagic: Empower,0", 98, 99)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }

        [TestCase("Rod of lesser metamagic: Quicken,0", 100)]
        public void Percentile(String content, Int32 roll)
        {
            AssertPercentile(content, roll);
        }
    }
}