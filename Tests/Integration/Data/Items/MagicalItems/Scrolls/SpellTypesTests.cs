using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Scrolls
{
    [TestFixture, PercentileTable("SpellTypes")]
    public class SpellTypesTests : PercentileTests
    {
        [Test]
        public void ArcanePercentile()
        {
            AssertContent("Arcane", 1, 70);
        }

        [Test]
        public void DivinePercentile()
        {
            AssertContent("Divine", 71, 100);
        }
    }
}