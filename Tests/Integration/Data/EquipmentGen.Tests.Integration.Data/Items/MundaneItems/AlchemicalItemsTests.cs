using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("AlchemicalItems")]
    public class AlchemicalItemsTests : PercentileTests
    {
        [Test]
        public void AlchemistsFirePercentile()
        {
            AssertContent("Alchemist's fire,1d4", 1, 12);
        }

        [Test]
        public void AcidPercentile()
        {
            AssertContent("Acid,2d4", 13, 24);
        }

        [Test]
        public void SmokestickPercentile()
        {
            AssertContent("Smokestick,1d4", 25, 36);
        }

        [Test]
        public void HolyWaterPercentile()
        {
            AssertContent("Holy water,1d4", 37, 48);
        }

        [Test]
        public void AntitoxinPercentile()
        {
            AssertContent("Antitoxin,1d4", 49, 62);
        }

        [Test]
        public void EverburningTorchPercentile()
        {
            AssertContent("Everburning torch,1", 63, 74);
        }

        [Test]
        public void TanglefootBagPercentile()
        {
            AssertContent("Tanglefoot bag,1d4", 75, 88);
        }

        [Test]
        public void ThunderstonePercentile()
        {
            AssertContent("Thunderstone,1d4", 89, 100);
        }
    }
}