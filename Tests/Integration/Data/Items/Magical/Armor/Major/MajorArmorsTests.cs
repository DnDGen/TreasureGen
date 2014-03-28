using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Major
{
    [TestFixture, PercentileTable("MajorArmors")]
    public class MajorArmorsTests : PercentileTests
    {
        [Test]
        public void Plus3ShieldPercentile()
        {
            var content = String.Format("{0},3", AttributeConstants.Shield);
            AssertPercentile(content, 1, 8);
        }

        [Test]
        public void Plus3ArmorPercentile()
        {
            var content = String.Format("{0},3", ItemTypeConstants.Armor);
            AssertPercentile(content, 9, 16);
        }

        [Test]
        public void Plus4ShieldPercentile()
        {
            var content = String.Format("{0},4", AttributeConstants.Shield);
            AssertPercentile(content, 17, 27);
        }

        [Test]
        public void Plus4ArmorPercentile()
        {
            var content = String.Format("{0},4", ItemTypeConstants.Armor);
            AssertPercentile(content, 28, 38);
        }

        [Test]
        public void Plus5ShieldPercentile()
        {
            var content = String.Format("{0},5", AttributeConstants.Shield);
            AssertPercentile(content, 39, 49);
        }

        [Test]
        public void Plus5ArmorPercentile()
        {
            var content = String.Format("{0},5", ItemTypeConstants.Armor);
            AssertPercentile(content, 50, 57);
        }

        [Test]
        public void SpecificArmorPercentile()
        {
            AssertPercentile("SpecificArmors,0", 58, 60);
        }

        [Test]
        public void SpecificShieldPercentile()
        {
            AssertPercentile("SpecificShields,0", 61, 63);
        }

        [Test]
        public void SpecialAbilityPercentile()
        {
            AssertPercentile("SpecialAbility,1", 64, 100);
        }
    }
}