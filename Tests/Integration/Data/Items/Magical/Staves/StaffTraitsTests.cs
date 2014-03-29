using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Staves
{
    [TestFixture]
    public class StaffTraitsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "StaffTraits";
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