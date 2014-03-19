using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Goods.Gems
{
    [TestFixture, PercentileTable("GemValues")]
    public class GemValuesTests : PercentileTests
    {
        [Test]
        public void GemValue4d4Percentile()
        {
            AssertContent("4d4", 1, 25);
        }

        [Test]
        public void GemValue2d4x10Percentile()
        {
            AssertContent("2d4*10", 26, 50);
        }

        [Test]
        public void GemValue4d4x10Percentile()
        {
            AssertContent("4d4*10", 51, 70);
        }

        [Test]
        public void GemValue2d4x100Percentile()
        {
            AssertContent("2d4*100", 71, 90);
        }

        [Test]
        public void GemValue4d4x100Percentile()
        {
            AssertContent("4d4*100", 91, 99);
        }

        [Test]
        public void GemValue2d4x1000Percentile()
        {
            AssertContent("2d4*1000", 100);
        }
    }
}