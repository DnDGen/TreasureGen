using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class MundaneArmorTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "MundaneArmor";
        }

        [Test]
        public void ChainShirtPercentile()
        {
            AssertContent("Chain shirt", 1, 12);
        }

        [Test]
        public void MasterworkStuddedLeatherPercentile()
        {
            AssertContent("Masterwork studded leather", 13, 18);
        }

        [Test]
        public void BreastplatePercentile()
        {
            AssertContent("Breastplate", 19, 26);
        }

        [Test]
        public void BandedMailPercentile()
        {
            AssertContent("Banded mail", 27, 34);
        }

        [Test]
        public void HalfPlatePercentile()
        {
            AssertContent("Half-plate", 35, 54);
        }

        [Test]
        public void FullPlatePercentile()
        {
            AssertContent("Full plate", 55, 80);
        }

        [Test]
        public void DarkwoodShieldsPercentile()
        {
            AssertContent("DarkwoodShields", 81, 90);
        }

        [Test]
        public void MasterworkShieldsPercentile()
        {
            AssertContent("MasterworkShields", 91, 100);
        }
    }
}