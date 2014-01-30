﻿using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Armor
{
    [TestFixture, PercentileTable("MinorArmor")]
    public class MinorArmorTests : PercentileTests
    {[Test]
        public void Plus1ShieldPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Gear.Types.Shield);
            AssertContent(content, 1, 60);
        }

        [Test]
        public void Plus1ArmorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.ItemTypes.Armor);
            AssertContent(content, 61, 80);
        }

        [Test]
        public void Plus2ShieldPercentile()
        {
            var content = String.Format("{0},2", ItemsConstants.Gear.Types.Shield);
            AssertContent(content, 81, 85);
        }

        [Test]
        public void Plus2ArmorPercentile()
        {
            var content = String.Format("{0},2", ItemsConstants.ItemTypes.Armor);
            AssertContent(content, 86, 87);
        }

        [Test]
        public void SpecificShieldPercentile()
        {
            var content = String.Format("Specific{0},0", ItemsConstants.Gear.Types.Shield);
            AssertContent(content, 88, 89);
        }

        [Test]
        public void SpecificArmorPercentile()
        {
            var content = String.Format("Specific{0},0", ItemsConstants.ItemTypes.Armor);
            AssertContent(content, 90, 91);
        }

        [Test]
        public void SpecialAbilityPercentile()
        {
            AssertContent("SpecialAbility,0", 92, 100);
        }
    }
}