using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls
{
    [TestFixture, PercentileTable("SpellTypes")]
    public class SpellTypesTests : PercentileTests
    {
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