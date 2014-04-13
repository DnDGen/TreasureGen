using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Weapons
{
    [TestFixture]
    public class RangedTraitsTests : PercentileTests
    {
        protected override String tableName
        {
            get { return "RangedTraits"; }
        }

        [TestCase(TraitConstants.Markings, 1, 20)]
        [TestCase(EmptyContent, 21, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}