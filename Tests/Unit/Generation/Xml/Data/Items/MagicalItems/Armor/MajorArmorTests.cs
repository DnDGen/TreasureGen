using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems.Armor
{
    [TestFixture, PercentileTable("MajorArmor")]
    public class MajorArmorTests : PercentileTests
    {
        [Test]
        public void Plus3ShieldPercentile()
        {
            var content = String.Format("{0},3", ItemsConstants.Gear.Types.Shield);
            AssertContent(content, 1, 8);
        }

        [Test]
        public void Plus3ArmorPercentile()
        {
            var content = String.Format("{0},3", ItemsConstants.ItemTypes.Armor);
            AssertContent(content, 9, 16);
        }

        [Test]
        public void Plus4ShieldPercentile()
        {
            var content = String.Format("{0},4", ItemsConstants.Gear.Types.Shield);
            AssertContent(content, 17, 27);
        }

        [Test]
        public void Plus4ArmorPercentile()
        {
            var content = String.Format("{0},4", ItemsConstants.ItemTypes.Armor);
            AssertContent(content, 28, 38);
        }

        [Test]
        public void Plus5ShieldPercentile()
        {
            var content = String.Format("{0},5", ItemsConstants.Gear.Types.Shield);
            AssertContent(content, 39, 49);
        }

        [Test]
        public void Plus5ArmorPercentile()
        {
            var content = String.Format("{0},5", ItemsConstants.ItemTypes.Armor);
            AssertContent(content, 50, 57);
        }

        [Test]
        public void SpecificArmorPercentile()
        {
            AssertContent("SpecificArmor,0", 58, 60);
        }

        [Test]
        public void SpecificShieldPercentile()
        {
            AssertContent("SpecificShield,0", 61, 63);
        }

        [Test]
        public void SpecialAbilityPercentile()
        {
            AssertContent("SpecialAbility,1", 64, 100);
        }
    }
}