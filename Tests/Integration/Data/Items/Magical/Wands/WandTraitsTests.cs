using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Wands
{
    [TestFixture]
    public class WandTraitsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "WandTraits";
        }

        [Test]
        public void MarkingsPercentile()
        {
            AssertPercentile(TraitConstants.Markings, 1, 30);
        }

        [Test]
        public void EmptyPercentile()
        {
            AssertPercentile(String.Empty, 31, 100);
        }
    }
}