using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor
{
    [TestFixture, PercentileTable("ShieldTypes")]
    public class ShieldTypesTests : PercentileTests
    {
        [Test]
        public void BucklerPercentile()
        {
            AssertPercentile(ArmorConstants.Buckler, 1, 10);
        }

        [Test]
        public void LightWoodenShieldPercentile()
        {
            AssertPercentile(ArmorConstants.LightWoodenShield, 11, 15);
        }

        [Test]
        public void LightSteelShieldPercentile()
        {
            AssertPercentile(ArmorConstants.LightSteelShield, 16, 20);
        }

        [Test]
        public void HeavyWoodenShieldPercentile()
        {
            AssertPercentile(ArmorConstants.HeavyWoodenShield, 21, 30);
        }

        [Test]
        public void HeavySteelShieldPercentile()
        {
            AssertPercentile(ArmorConstants.HeavySteelShield, 31, 95);
        }

        [Test]
        public void TowerShieldPercentile()
        {
            AssertPercentile(ArmorConstants.TowerShield, 96, 100);
        }
    }
}