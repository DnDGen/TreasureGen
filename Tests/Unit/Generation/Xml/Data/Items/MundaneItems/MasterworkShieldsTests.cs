﻿using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MundaneItems
{
    [TestFixture, PercentileTable("MasterworkShields")]
    public class MasterworkShieldsTests : PercentileTests
    {
        [Test]
        public void BucklerPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.Buckler, 1, 17);
        }

        [Test]
        public void LightWoodenShieldPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.LightWoodenShield, 18, 40);
        }

        [Test]
        public void LightSteelShieldPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.LightSteelShield, 41, 60);
        }

        [Test]
        public void HeavyWoodenShieldPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.HeavyWoodenShield, 61, 83);
        }

        [Test]
        public void HeavySteelShieldPercentile()
        {
            AssertContent(ItemsConstants.Gear.Armor.HeavySteelShield, 84, 100);
        }
    }
}