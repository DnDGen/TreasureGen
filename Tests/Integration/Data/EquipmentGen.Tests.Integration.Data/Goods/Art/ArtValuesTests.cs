using EquipmentGen.Tests.Integration.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Data.Goods.Art
{
    [TestFixture, PercentileTable("ArtValues")]
    public class ArtValuesTests : PercentileTests
    {
        [Test]
        public void ArtValue1d10x10Percentile()
        {
            AssertContent("1d10*10", 1, 10);
        }

        [Test]
        public void ArtValue3d6x10Percentile()
        {
            AssertContent("3d6*10", 11, 25);
        }

        [Test]
        public void ArtValue1d6x100Percentile()
        {
            AssertContent("1d6*100", 26, 40);
        }

        [Test]
        public void ArtValue1d10x100Percentile()
        {
            AssertContent("1d10*100", 41, 50);
        }

        [Test]
        public void ArtValue2d6x100Percentile()
        {
            AssertContent("2d6*100", 51, 60);
        }

        [Test]
        public void ArtValue3d6x100Percentile()
        {
            AssertContent("3d6*100", 61, 70);
        }

        [Test]
        public void ArtValue4d6x100Percentile()
        {
            AssertContent("4d6*100", 71, 80);
        }

        [Test]
        public void ArtValue5d6x100Percentile()
        {
            AssertContent("5d6*100", 81, 85);
        }

        [Test]
        public void ArtValue1d4x1000Percentile()
        {
            AssertContent("1d4*1000", 86, 90);
        }

        [Test]
        public void ArtValue1d6x1000Percentile()
        {
            AssertContent("1d6*1000", 91, 95);
        }

        [Test]
        public void ArtValue2d4x1000Percentile()
        {
            AssertContent("2d4*1000", 96, 99);
        }

        [Test]
        public void ArtValue2d6x1000Percentile()
        {
            AssertContent("2d6*1000", 100);
        }
    }
}