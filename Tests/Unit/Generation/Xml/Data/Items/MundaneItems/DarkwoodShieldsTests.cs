using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture]
    public class DarkwoodShieldsTests : PercentileTests
    {
        [SetUp]
        public void Setup()
        {
            tableName = "DarkwoodShields";
        }

        [Test]
        public void DarkwoodBucklerPercentile()
        {
            AssertContent("Buckler", 1, 50);
        }

        [Test]
        public void DarkwoodShieldPercentile()
        {
            AssertContent("Shield", 51, 100);
        }
    }
}