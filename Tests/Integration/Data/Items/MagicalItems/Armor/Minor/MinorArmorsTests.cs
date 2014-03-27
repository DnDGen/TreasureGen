using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Tables.TestAttributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Minor
{
    [TestFixture, PercentileTable("MinorArmors")]
    public class MinorArmorsTests : PercentileTests
    {
        [Test]
        public void Plus1ShieldPercentile()
        {
            var content = String.Format("{0},1", AttributeConstants.Shield);
            AssertPercentile(content, 1, 60);
        }

        [Test]
        public void Plus1ArmorPercentile()
        {
            var content = String.Format("{0},1", ItemTypeConstants.Armor);
            AssertPercentile(content, 61, 80);
        }

        [Test]
        public void Plus2ShieldPercentile()
        {
            var content = String.Format("{0},2", AttributeConstants.Shield);
            AssertPercentile(content, 81, 85);
        }

        [Test]
        public void Plus2ArmorPercentile()
        {
            var content = String.Format("{0},2", ItemTypeConstants.Armor);
            AssertPercentile(content, 86, 87);
        }

        [Test]
        public void SpecificArmorPercentile()
        {
            AssertPercentile("SpecificArmors,0", 88, 89);
        }

        [Test]
        public void SpecificShieldPercentile()
        {
            AssertPercentile("SpecificShields,0", 90, 91);
        }

        [Test]
        public void SpecialAbilityPercentile()
        {
            AssertPercentile("SpecialAbility,1", 92, 100);
        }
    }
}