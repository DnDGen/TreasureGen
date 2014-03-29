using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class CommonMeleeWeaponsTests : PercentileTests
    {
        protected override String GetTableName()
        {
            return "CommonMeleeWeapons";
        }

        [TestCase(WeaponConstants.Dagger, 1, 4)]
        [TestCase(WeaponConstants.Greataxe, 5, 14)]
        [TestCase(WeaponConstants.Greatsword, 15, 24)]
        [TestCase(WeaponConstants.Kama, 25, 28)]
        [TestCase(WeaponConstants.Longsword, 29, 41)]
        [TestCase(WeaponConstants.LightMace, 42, 45)]
        [TestCase(WeaponConstants.HeavyMace, 46, 50)]
        [TestCase(WeaponConstants.Nunchaku, 51, 54)]
        [TestCase(WeaponConstants.Quarterstaff, 55, 57)]
        [TestCase(WeaponConstants.Rapier, 58, 61)]
        [TestCase(WeaponConstants.Scimitar, 62, 66)]
        [TestCase(WeaponConstants.Shortspear, 67, 70)]
        [TestCase(WeaponConstants.Siangham, 71, 74)]
        [TestCase(WeaponConstants.BastardSword, 75, 84)]
        [TestCase(WeaponConstants.ShortSword, 85, 89)]
        [TestCase(WeaponConstants.DwarvenWaraxe, 90, 100)]
        public void Percentile(String content, Int32 lower, Int32 upper)
        {
            AssertPercentile(content, lower, upper);
        }
    }
}