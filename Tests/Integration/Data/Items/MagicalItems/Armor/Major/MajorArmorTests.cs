using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Major
{
    [TestFixture, PercentileTable("MajorArmor")]
    public class MajorArmorTests : PercentileTests
    {
        [Test]
        public void Plus3ShieldPercentile()
        {
            var content = String.Format("{0},3", AttributeConstants.Shield);
            AssertContent(content, 1, 8);
        }

        [Test]
        public void Plus3ArmorPercentile()
        {
            var content = String.Format("{0},3", ItemTypeConstants.Armor);
            AssertContent(content, 9, 16);
        }

        [Test]
        public void Plus4ShieldPercentile()
        {
            var content = String.Format("{0},4", AttributeConstants.Shield);
            AssertContent(content, 17, 27);
        }

        [Test]
        public void Plus4ArmorPercentile()
        {
            var content = String.Format("{0},4", ItemTypeConstants.Armor);
            AssertContent(content, 28, 38);
        }

        [Test]
        public void Plus5ShieldPercentile()
        {
            var content = String.Format("{0},5", AttributeConstants.Shield);
            AssertContent(content, 39, 49);
        }

        [Test]
        public void Plus5ArmorPercentile()
        {
            var content = String.Format("{0},5", ItemTypeConstants.Armor);
            AssertContent(content, 50, 57);
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