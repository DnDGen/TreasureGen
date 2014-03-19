using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
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