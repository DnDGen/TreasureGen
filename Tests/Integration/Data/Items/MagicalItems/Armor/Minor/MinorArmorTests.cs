using System;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Integration.Tables.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.MagicalItems.Armor.Minor
{
    [TestFixture, PercentileTable("MinorArmor")]
    public class MinorArmorTests : PercentileTests
    {
        [Test]
        public void Plus1ShieldPercentile()
        {
            var content = String.Format("{0},1", AttributeConstants.Shield);
            AssertContent(content, 1, 60);
        }

        [Test]
        public void Plus1ArmorPercentile()
        {
            var content = String.Format("{0},1", ItemTypeConstants.Armor);
            AssertContent(content, 61, 80);
        }

        [Test]
        public void Plus2ShieldPercentile()
        {
            var content = String.Format("{0},2", AttributeConstants.Shield);
            AssertContent(content, 81, 85);
        }

        [Test]
        public void Plus2ArmorPercentile()
        {
            var content = String.Format("{0},2", ItemTypeConstants.Armor);
            AssertContent(content, 86, 87);
        }

        [Test]
        public void SpecificArmorPercentile()
        {
            AssertContent("SpecificArmors,0", 88, 89);
        }

        [Test]
        public void SpecificShieldPercentile()
        {
            AssertContent("SpecificShields,0", 90, 91);
        }

        [Test]
        public void SpecialAbilityPercentile()
        {
            AssertContent("SpecialAbility,1", 92, 100);
        }
    }
}