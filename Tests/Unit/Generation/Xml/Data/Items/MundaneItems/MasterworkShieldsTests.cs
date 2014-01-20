using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class MasterworkShieldsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "MasterworkShields";
        }

        [Test]
        public void BucklerPercentile()
        {
            AssertContent("Buckler", 1, 17);
        }

        [Test]
        public void LightWoodenShieldPercentile()
        {
            AssertContent("Light wooden shield", 18, 40);
        }

        [Test]
        public void LightSteelShieldPercentile()
        {
            AssertContent("Light steel shield", 41, 60);
        }

        [Test]
        public void HeavyWoodenShieldPercentile()
        {
            AssertContent("Heavy wooden shield", 61, 83);
        }

        [Test]
        public void HeavySteelShieldPercentile()
        {
            AssertContent("Heavy steel shield", 84, 100);
        }
    }
}