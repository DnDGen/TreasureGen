using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Armor
{
    [TestFixture, PercentileTable("MediumArmor")]
    public class MediumArmorTests : PercentileTests
    {
        [Test]
        public void Plus1ShieldPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.Gear.Types.Shield);
            AssertContent(content, 1, 5);
        }

        [Test]
        public void Plus1ArmorPercentile()
        {
            var content = String.Format("{0},1", ItemsConstants.ItemTypes.Armor);
            AssertContent(content, 6, 10);
        }

        [Test]
        public void Plus2ShieldPercentile()
        {
            var content = String.Format("{0},2", ItemsConstants.Gear.Types.Shield);
            AssertContent(content, 11, 20);
        }

        [Test]
        public void Plus2ArmorPercentile()
        {
            var content = String.Format("{0},2", ItemsConstants.ItemTypes.Armor);
            AssertContent(content, 21, 30);
        }

        [Test]
        public void Plus3ShieldPercentile()
        {
            var content = String.Format("{0},3", ItemsConstants.Gear.Types.Shield);
            AssertContent(content, 31, 40);
        }

        [Test]
        public void Plus3ArmorPercentile()
        {
            var content = String.Format("{0},3", ItemsConstants.ItemTypes.Armor);
            AssertContent(content, 41, 50);
        }

        [Test]
        public void Plus4ShieldPercentile()
        {
            var content = String.Format("{0},4", ItemsConstants.Gear.Types.Shield);
            AssertContent(content, 51, 55);
        }

        [Test]
        public void Plus4ArmorPercentile()
        {
            var content = String.Format("{0},4", ItemsConstants.ItemTypes.Armor);
            AssertContent(content, 56, 57);
        }

        [Test]
        public void SpecificArmorPercentile()
        {
            AssertContent("SpecificArmors,0", 58, 60);
        }

        [Test]
        public void SpecificShieldPercentile()
        {
            AssertContent("SpecificShields,0", 61, 63);
        }

        [Test]
        public void SpecialAbilityPercentile()
        {
            AssertContent("SpecialAbility,1", 64, 100);
        }
    }
}