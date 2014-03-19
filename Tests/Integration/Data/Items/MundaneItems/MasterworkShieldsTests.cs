using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MundaneItems
{
    [TestFixture, PercentileTable("MasterworkShields")]
    public class MasterworkShieldsTests : PercentileTests
    {
        [Test]
        public void BucklerPercentile()
        {
            AssertContent(ArmorConstants.Buckler, 1, 17);
        }

        [Test]
        public void LightWoodenShieldPercentile()
        {
            AssertContent(ArmorConstants.LightWoodenShield, 18, 40);
        }

        [Test]
        public void LightSteelShieldPercentile()
        {
            AssertContent(ArmorConstants.LightSteelShield, 41, 60);
        }

        [Test]
        public void HeavyWoodenShieldPercentile()
        {
            AssertContent(ArmorConstants.HeavyWoodenShield, 61, 83);
        }

        [Test]
        public void HeavySteelShieldPercentile()
        {
            AssertContent(ArmorConstants.HeavySteelShield, 84, 100);
        }
    }
}