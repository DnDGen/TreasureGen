using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Armor.Medium
{
    [TestFixture]
    public class MediumArmorsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "MediumArmors";
        }

        [Test]
        public void Plus1ShieldPercentile()
        {
            var content = String.Format("{0},1", AttributeConstants.Shield);
            AssertPercentile(content, 1, 5);
        }

        [Test]
        public void Plus1ArmorPercentile()
        {
            var content = String.Format("{0},1", ItemTypeConstants.Armor);
            AssertPercentile(content, 6, 10);
        }

        [Test]
        public void Plus2ShieldPercentile()
        {
            var content = String.Format("{0},2", AttributeConstants.Shield);
            AssertPercentile(content, 11, 20);
        }

        [Test]
        public void Plus2ArmorPercentile()
        {
            var content = String.Format("{0},2", ItemTypeConstants.Armor);
            AssertPercentile(content, 21, 30);
        }

        [Test]
        public void Plus3ShieldPercentile()
        {
            var content = String.Format("{0},3", AttributeConstants.Shield);
            AssertPercentile(content, 31, 40);
        }

        [Test]
        public void Plus3ArmorPercentile()
        {
            var content = String.Format("{0},3", ItemTypeConstants.Armor);
            AssertPercentile(content, 41, 50);
        }

        [Test]
        public void Plus4ShieldPercentile()
        {
            var content = String.Format("{0},4", AttributeConstants.Shield);
            AssertPercentile(content, 51, 55);
        }

        [Test]
        public void Plus4ArmorPercentile()
        {
            var content = String.Format("{0},4", ItemTypeConstants.Armor);
            AssertPercentile(content, 56, 57);
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