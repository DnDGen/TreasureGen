using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class WondrousItemTraitsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "WondrousItemTraits";
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