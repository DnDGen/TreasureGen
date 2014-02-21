using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("DarkwoodShields")]
    public class DarkwoodShieldsTests : PercentileTests
    {
        [Test]
        public void DarkwoodBucklerPercentile()
        {
            AssertContent(ArmorConstants.DarkwoodBuckler, 1, 50);
        }

        [Test]
        public void DarkwoodShieldPercentile()
        {
            AssertContent(ArmorConstants.DarkwoodShield, 51, 100);
        }
    }
}