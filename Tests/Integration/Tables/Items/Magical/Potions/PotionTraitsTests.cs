using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Potions
{
    [TestFixture]
    public class PotionTraitsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "PotionTraits"; }
        }

        [TestCase(EmptyContent, 1, 100)]
        public override void Percentile(String content, Int32 lower, Int32 upper)
        {
            base.Percentile(content, lower, upper);
        }
    }
}