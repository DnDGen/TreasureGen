using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rods
{
    [TestFixture]
    public class MajorRodsTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.Rod); }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase("Rod of cancellation", 0, 1, 4)]
        [TestCase("Rod of metamagic: Enlarge", 0, 5, 6)]
        [TestCase("Rod of metamagic: Extend", 0, 7, 8)]
        [TestCase("Rod of metamagic: Silent", 0, 9, 10)]
        [TestCase("Rod of wonder", 0, 11, 14)]
        [TestCase("Rod of the python", 1, 15, 18)]
        [TestCase("Rod of flame extinguishing", 0, 19, 21)]
        [TestCase("Rod of the viper", 2, 22, 25)]
        [TestCase("Rod of enemy detection", 0, 26, 30)]
        [TestCase("Rod of greater metamagic: Enlarge", 0, 31, 36)]
        [TestCase("Rod of greater metamagic: Extend", 0, 37, 42)]
        [TestCase("Rod of greater metamagic: Silent", 0, 43, 48)]
        [TestCase("Rod of splendor", 4, 49, 53)]
        [TestCase("Rod of withering", 1, 54, 58)]
        [TestCase("Rod of metamagic: Empower", 0, 59, 64)]
        [TestCase("Rod of thunder and lightning", 2, 65, 69)]
        [TestCase("Rod of lesser metamagic: Quicken", 0, 70, 73)]
        [TestCase("Rod of negation", 0, 74, 77)]
        [TestCase("Rod of absorption", 0, 78, 80)]
        [TestCase("Rod of flailing", 3, 81, 84)]
        [TestCase("Rod of metamagic: Maximize", 0, 85, 86)]
        [TestCase("Rod of rulership", 0, 87, 88)]
        [TestCase("Rod of security", 0, 89, 90)]
        [TestCase("Rod of lordly might", 2, 91, 92)]
        [TestCase("Rod of greater metamagic: Empower", 0, 93, 94)]
        [TestCase("Rod of metamagic: Quicken", 0, 95, 96)]
        [TestCase("Rod of alertness", 1, 97, 98)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
        {
            base.TypeAndAmountPercentile(type, amount, lower, upper);
        }

        [TestCase("Rod of greater metamagic: Maximize", 0, 99)]
        [TestCase("Rod of greater metamagic: Quicken", 0, 100)]
        public override void TypeAndAmountPercentile(String type, Int32 amount, Int32 roll)
        {
            base.TypeAndAmountPercentile(type, amount, roll);
        }
    }
}