using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MagicalItems.Scrolls
{
    [TestFixture, PercentileTable("SpellType")]
    public class SpellTypeTests : PercentileTests
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