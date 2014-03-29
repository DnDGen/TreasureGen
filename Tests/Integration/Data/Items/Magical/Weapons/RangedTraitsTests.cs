using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Weapons
{
    [TestFixture]
    public class RangedTraitsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "RangedTraits";
        }

        [Test]
        public void MarkingsPercentile()
        {
            AssertPercentile(TraitConstants.Markings, 1, 20);
        }

        [Test]
        public void EmptyPercentile()
        {
            AssertPercentile(String.Empty, 21, 100);
        }
    }
}