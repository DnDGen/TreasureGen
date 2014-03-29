using System;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls
{
    [TestFixture]
    public class SpellTypesTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "SpellTypes";
        }

        [Test]
        public void ArcanePercentile()
        {
            AssertPercentile("Arcane", 1, 70);
        }

        [Test]
        public void DivinePercentile()
        {
            AssertPercentile("Divine", 71, 100);
        }
    }
}