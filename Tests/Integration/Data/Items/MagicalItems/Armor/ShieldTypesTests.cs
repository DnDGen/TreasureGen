using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor
{
    [TestFixture, PercentileTable("ShieldTypes")]
    public class ShieldTypesTests : PercentileTests
    {
        [Test]
        public void BucklerPercentile()
        {
            AssertContent(ArmorConstants.Buckler, 1, 10);
        }

        [Test]
        public void LightWoodenShieldPercentile()
        {
            AssertContent(ArmorConstants.LightWoodenShield, 11, 15);
        }

        [Test]
        public void LightSteelShieldPercentile()
        {
            AssertContent(ArmorConstants.LightSteelShield, 16, 20);
        }

        [Test]
        public void HeavyWoodenShieldPercentile()
        {
            AssertContent(ArmorConstants.HeavyWoodenShield, 21, 30);
        }

        [Test]
        public void HeavySteelShieldPercentile()
        {
            AssertContent(ArmorConstants.HeavySteelShield, 31, 95);
        }

        [Test]
        public void TowerShieldPercentile()
        {
            AssertContent(ArmorConstants.TowerShield, 96, 100);
        }
    }
}