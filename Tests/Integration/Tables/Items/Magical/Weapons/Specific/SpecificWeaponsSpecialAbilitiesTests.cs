using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables.Interfaces;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Weapons.Specific
{
    [TestFixture]
    public class SpecificWeaponsSpecialAbilitiesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPESpecialAbilities, ItemTypeConstants.Weapon); }
        }

        [TestCase(WeaponConstants.SleepArrow)]
        [TestCase(WeaponConstants.ScreamingBolt)]
        [TestCase(WeaponConstants.SilverDagger)]
        [TestCase(WeaponConstants.Longsword)]
        [TestCase(WeaponConstants.JavelinOfLightning)]
        [TestCase(WeaponConstants.SlayingArrow)]
        [TestCase(WeaponConstants.Dagger)]
        [TestCase(WeaponConstants.Battleaxe)]
        [TestCase(WeaponConstants.GreaterSlayingArrow)]
        [TestCase(WeaponConstants.Shatterspike)]
        [TestCase(WeaponConstants.DaggerOfVenom)]
        [TestCase(WeaponConstants.TridentOfWarning)]
        [TestCase(WeaponConstants.AssassinsDagger)]
        [TestCase(WeaponConstants.ShiftersSorrow)]
        [TestCase(WeaponConstants.TridentOfFishCommand)]
        [TestCase(WeaponConstants.FlameTongue, SpecialAbilityConstants.FlamingBurst)]
        [TestCase(WeaponConstants.LuckBlade0)]
        [TestCase(WeaponConstants.SwordOfSubtlety)]
        [TestCase(WeaponConstants.SwordOfThePlanes)]
        [TestCase(WeaponConstants.NineLivesStealer)]
        [TestCase(WeaponConstants.SwordOfLifeStealing)]
        [TestCase(WeaponConstants.Oathbow)]
        [TestCase(WeaponConstants.MaceOfTerror)]
        [TestCase(WeaponConstants.LifeDrinker)]
        [TestCase(WeaponConstants.SylvanScimitar)]
        [TestCase(WeaponConstants.RapierOfPuncturing, SpecialAbilityConstants.Wounding)]
        [TestCase(WeaponConstants.SunBlade)]
        [TestCase(WeaponConstants.FrostBrand, SpecialAbilityConstants.Frost)]
        [TestCase(WeaponConstants.DwarvenThrower)]
        [TestCase(WeaponConstants.LuckBlade1)]
        [TestCase(WeaponConstants.MaceOfSmiting)]
        [TestCase(WeaponConstants.LuckBlade2)]
        [TestCase(WeaponConstants.HolyAvenger)]
        [TestCase(WeaponConstants.LuckBlade3)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}