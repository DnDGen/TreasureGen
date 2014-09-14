using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class IsDeckOFIllusionsFullyChargedTests : BooleanPercentileTests
    {
        protected override String tableName
        {
            get { return "IsDeckOfIllusionsFullyCharged"; }
        }

        [TestCase(true, 1, 90)]
        [TestCase(false, 91, 100)]
        public override void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            base.BooleanPercentile(isTrue, lower, upper);
        }
    }
}