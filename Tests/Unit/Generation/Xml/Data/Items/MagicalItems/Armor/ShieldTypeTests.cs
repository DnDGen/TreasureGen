using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Armor
{
    [TestFixture, PercentileTable("ShieldType")]
    public class ShieldTypeTests : PercentileTests
    {
        [Test]
        public void BucklerPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.Buckler, 1, 10);
        }

        [Test]
        public void LightWoodenShieldPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.LightWoodenShield, 11, 15);
        }

        [Test]
        public void LightSteelShieldPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.LightSteelShield, 16, 20);
        }

        [Test]
        public void HeavyWoodenShieldPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.HeavyWoodenShield, 21, 30);
        }

        [Test]
        public void HeavySteelShieldPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.HeavySteelShield, 31, 95);
        }

        [Test]
        public void TowerShieldPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.TowerShield, 96, 100);
        }
    }
}