using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Helpers;
using DnDGen.TreasureGen.Tables;
using NUnit.Framework;
using System;
using System.Data;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class WeaponDamagesTests : CollectionsTests
    {
        protected override string tableName => TableNameConstants.Collections.Set.WeaponDamages;

        private DamageHelper damageHelper;
        private IWeaponDataSelector weaponDataSelector;

        [SetUp]
        public void Setup()
        {
            damageHelper = new DamageHelper();
            weaponDataSelector = GetNewInstanceOf<IWeaponDataSelector>();
        }

        [TestCase(WeaponConstants.Dagger,
            "1d2#Piercing or Slashing#", "1d3#Piercing or Slashing#", "1d4#Piercing or Slashing#", "1d6#Piercing or Slashing#", "1d8#Piercing or Slashing#", "2d6#Piercing or Slashing#", "3d6#Piercing or Slashing#",
            "2d2#Piercing or Slashing#", "2d3#Piercing or Slashing#", "2d4#Piercing or Slashing#", "2d6#Piercing or Slashing#", "2d8#Piercing or Slashing#", "4d6#Piercing or Slashing#", "6d6#Piercing or Slashing#")]
        [TestCase(WeaponConstants.Greataxe,
            "1d8#Slashing#", "1d10#Slashing#", "1d12#Slashing#", "3d6#Slashing#", "4d6#Slashing#", "6d6#Slashing#", "8d6#Slashing#",
            "3d8#Slashing#", "3d10#Slashing#", "3d12#Slashing#", "9d6#Slashing#", "12d6#Slashing#", "18d6#Slashing#", "24d6#Slashing#")]
        [TestCase(WeaponConstants.Greatsword,
            "1d8#Slashing#", "1d10#Slashing#", "2d6#Slashing#", "3d6#Slashing#", "4d6#Slashing#", "6d6#Slashing#", "8d6#Slashing#",
            "2d8#Slashing#", "2d10#Slashing#", "4d6#Slashing#", "6d6#Slashing#", "8d6#Slashing#", "12d6#Slashing#", "16d6#Slashing#")]
        [TestCase(WeaponConstants.Kama,
            "1d3#Slashing#", "1d4#Slashing#", "1d6#Slashing#", "1d8#Slashing#", "2d6#Slashing#", "3d6#Slashing#", "4d6#Slashing#",
            "2d3#Slashing#", "2d4#Slashing#", "2d6#Slashing#", "2d8#Slashing#", "4d6#Slashing#", "6d6#Slashing#", "8d6#Slashing#")]
        [TestCase(WeaponConstants.Longsword,
            "1d4#Slashing#", "1d6#Slashing#", "1d8#Slashing#", "2d6#Slashing#", "3d6#Slashing#", "4d6#Slashing#", "6d6#Slashing#",
            "2d4#Slashing#", "2d6#Slashing#", "2d8#Slashing#", "4d6#Slashing#", "6d6#Slashing#", "8d6#Slashing#", "12d6#Slashing#")]
        [TestCase(WeaponConstants.LightMace,
            "1d3#Bludgeoning#", "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#", "3d6#Bludgeoning#", "4d6#Bludgeoning#",
            "2d3#Bludgeoning#", "2d4#Bludgeoning#", "2d6#Bludgeoning#", "2d8#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#", "8d6#Bludgeoning#")]
        [TestCase(WeaponConstants.HeavyMace,
            "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#", "3d6#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#",
            "2d4#Bludgeoning#", "2d6#Bludgeoning#", "2d8#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#", "8d6#Bludgeoning#", "12d6#Bludgeoning#")]
        [TestCase(WeaponConstants.Nunchaku,
            "1d3#Bludgeoning#", "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#", "3d6#Bludgeoning#", "4d6#Bludgeoning#",
            "2d3#Bludgeoning#", "2d4#Bludgeoning#", "2d6#Bludgeoning#", "2d8#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#", "8d6#Bludgeoning#")]
        [TestCase(WeaponConstants.Quarterstaff,
            "1d3#Bludgeoning#,1d3#Bludgeoning#", "1d4#Bludgeoning#,1d4#Bludgeoning#", "1d6#Bludgeoning#,1d6#Bludgeoning#", "1d8#Bludgeoning#,1d8#Bludgeoning#", "2d6#Bludgeoning#,2d6#Bludgeoning#", "3d6#Bludgeoning#,3d6#Bludgeoning#", "4d6#Bludgeoning#,4d6#Bludgeoning#",
            "2d3#Bludgeoning#,2d3#Bludgeoning#", "2d4#Bludgeoning#,2d4#Bludgeoning#", "2d6#Bludgeoning#,2d6#Bludgeoning#", "2d8#Bludgeoning#,2d8#Bludgeoning#", "4d6#Bludgeoning#,4d6#Bludgeoning#", "6d6#Bludgeoning#,6d6#Bludgeoning#", "8d6#Bludgeoning#,8d6#Bludgeoning#")]
        [TestCase(WeaponConstants.Rapier,
            "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#",
            "2d3#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#", "8d6#Piercing#")]
        [TestCase(WeaponConstants.Scimitar,
            "1d3#Slashing#", "1d4#Slashing#", "1d6#Slashing#", "1d8#Slashing#", "2d6#Slashing#", "3d6#Slashing#", "4d6#Slashing#",
            "2d3#Slashing#", "2d4#Slashing#", "2d6#Slashing#", "2d8#Slashing#", "4d6#Slashing#", "6d6#Slashing#", "8d6#Slashing#")]
        [TestCase(WeaponConstants.Shortspear,
            "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#",
            "2d3#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#", "8d6#Piercing#")]
        [TestCase(WeaponConstants.Siangham,
            "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#",
            "2d3#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#", "8d6#Piercing#")]
        [TestCase(WeaponConstants.BastardSword,
            "1d6#Slashing#", "1d8#Slashing#", "1d10#Slashing#", "2d8#Slashing#", "3d8#Slashing#", "4d8#Slashing#", "6d8#Slashing#",
            "2d6#Slashing#", "2d8#Slashing#", "2d10#Slashing#", "4d8#Slashing#", "6d8#Slashing#", "8d8#Slashing#", "12d8#Slashing#")]
        [TestCase(WeaponConstants.ShortSword,
            "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#",
            "2d3#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#", "8d6#Piercing#")]
        [TestCase(WeaponConstants.DwarvenWaraxe,
            "1d6#Slashing#", "1d8#Slashing#", "1d10#Slashing#", "2d8#Slashing#", "3d8#Slashing#", "4d8#Slashing#", "6d8#Slashing#",
            "3d6#Slashing#", "3d8#Slashing#", "3d10#Slashing#", "6d8#Slashing#", "9d8#Slashing#", "12d8#Slashing#", "18d8#Slashing#")]
        [TestCase(WeaponConstants.OrcDoubleAxe,
            "1d4#Slashing#,1d4#Slashing#", "1d6#Slashing#,1d6#Slashing#", "1d8#Slashing#,1d8#Slashing#", "2d6#Slashing#,2d6#Slashing#", "3d6#Slashing#,3d6#Slashing#", "4d6#Slashing#,4d6#Slashing#", "6d6#Slashing#,6d6#Slashing#",
            "3d4#Slashing#,3d4#Slashing#", "3d6#Slashing#,3d6#Slashing#", "3d8#Slashing#,3d8#Slashing#", "6d6#Slashing#,6d6#Slashing#", "9d6#Slashing#,9d6#Slashing#", "12d6#Slashing#,12d6#Slashing#", "18d6#Slashing#,18d6#Slashing#")]
        [TestCase(WeaponConstants.Battleaxe,
            "1d4#Slashing#", "1d6#Slashing#", "1d8#Slashing#", "2d6#Slashing#", "3d6#Slashing#", "4d6#Slashing#", "6d6#Slashing#",
            "3d4#Slashing#", "3d6#Slashing#", "3d8#Slashing#", "6d6#Slashing#", "9d6#Slashing#", "12d6#Slashing#", "18d6#Slashing#")]
        [TestCase(WeaponConstants.SpikedChain,
            "1d4#Piercing#", "1d6#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#", "6d6#Piercing#",
            "2d4#Piercing#", "2d6#Piercing#", "4d4#Piercing#", "4d6#Piercing#", "6d6#Piercing#", "8d6#Piercing#", "12d6#Piercing#")]
        [TestCase(WeaponConstants.Club,
            "1d3#Bludgeoning#", "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#", "3d6#Bludgeoning#", "4d6#Bludgeoning#",
            "2d3#Bludgeoning#", "2d4#Bludgeoning#", "2d6#Bludgeoning#", "2d8#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#", "8d6#Bludgeoning#")]
        [TestCase(WeaponConstants.HandCrossbow,
            "1d2#Piercing#", "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#",
            "2d2#Piercing#", "2d3#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#")]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow,
            "1d6#Piercing#", "1d8#Piercing#", "1d10#Piercing#", "2d8#Piercing#", "3d8#Piercing#", "4d8#Piercing#", "6d8#Piercing#",
            "2d6#Piercing#", "2d8#Piercing#", "2d10#Piercing#", "4d8#Piercing#", "6d8#Piercing#", "8d8#Piercing#", "12d8#Piercing#")]
        [TestCase(WeaponConstants.LightRepeatingCrossbow,
            "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#", "6d6#Piercing#",
            "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#", "8d6#Piercing#", "12d6#Piercing#")]
        [TestCase(WeaponConstants.PunchingDagger,
            "1d2#Piercing#", "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#",
            "2d2#Piercing#", "2d3#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#")]
        [TestCase(WeaponConstants.Falchion,
            "1d4#Slashing#", "1d6#Slashing#", "2d4#Slashing#", "2d6#Slashing#", "3d6#Slashing#", "4d6#Slashing#", "6d6#Slashing#",
            "2d4#Slashing#", "2d6#Slashing#", "4d4#Slashing#", "4d6#Slashing#", "6d6#Slashing#", "8d6#Slashing#", "12d6#Slashing#")]
        [TestCase(WeaponConstants.DireFlail,
            "1d4#Bludgeoning#,1d4#Bludgeoning#", "1d6#Bludgeoning#,1d6#Bludgeoning#", "1d8#Bludgeoning#,1d8#Bludgeoning#", "2d6#Bludgeoning#,2d6#Bludgeoning#", "3d6#Bludgeoning#,3d6#Bludgeoning#", "4d6#Bludgeoning#,4d6#Bludgeoning#", "6d6#Bludgeoning#,6d6#Bludgeoning#",
            "2d4#Bludgeoning#,2d4#Bludgeoning#", "2d6#Bludgeoning#,2d6#Bludgeoning#", "2d8#Bludgeoning#,2d8#Bludgeoning#", "4d6#Bludgeoning#,4d6#Bludgeoning#", "6d6#Bludgeoning#,6d6#Bludgeoning#", "8d6#Bludgeoning#,8d6#Bludgeoning#", "12d6#Bludgeoning#,12d6#Bludgeoning#")]
        [TestCase(WeaponConstants.HeavyFlail,
            "1d6#Bludgeoning#", "1d8#Bludgeoning#", "1d10#Bludgeoning#", "2d8#Bludgeoning#", "3d8#Bludgeoning#", "4d8#Bludgeoning#", "6d8#Bludgeoning#",
            "2d6#Bludgeoning#", "2d8#Bludgeoning#", "2d10#Bludgeoning#", "4d8#Bludgeoning#", "6d8#Bludgeoning#", "8d8#Bludgeoning#", "12d8#Bludgeoning#")]
        [TestCase(WeaponConstants.Flail,
            "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#", "3d6#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#",
            "2d4#Bludgeoning#", "2d6#Bludgeoning#", "2d8#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#", "8d6#Bludgeoning#", "12d6#Bludgeoning#")]
        [TestCase(WeaponConstants.Gauntlet,
            "1#Bludgeoning#", "1d2#Bludgeoning#", "1d3#Bludgeoning#", "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#",
            "2#Bludgeoning#", "2d2#Bludgeoning#", "2d3#Bludgeoning#", "2d4#Bludgeoning#", "2d6#Bludgeoning#", "2d8#Bludgeoning#", "4d6#Bludgeoning#")]
        [TestCase(WeaponConstants.SpikedGauntlet,
            "1d2#Piercing#", "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#",
            "2d2#Piercing#", "2d3#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#")]
        [TestCase(WeaponConstants.Glaive,
            "1d6#Slashing#", "1d8#Slashing#", "1d10#Slashing#", "2d8#Slashing#", "3d8#Slashing#", "4d8#Slashing#", "6d8#Slashing#",
            "3d6#Slashing#", "3d8#Slashing#", "3d10#Slashing#", "6d8#Slashing#", "9d8#Slashing#", "12d8#Slashing#", "18d8#Slashing#")]
        [TestCase(WeaponConstants.Greatclub,
            "1d6#Bludgeoning#", "1d8#Bludgeoning#", "1d10#Bludgeoning#", "2d8#Bludgeoning#", "3d8#Bludgeoning#", "4d8#Bludgeoning#", "6d8#Bludgeoning#",
            "2d6#Bludgeoning#", "2d8#Bludgeoning#", "2d10#Bludgeoning#", "4d8#Bludgeoning#", "6d8#Bludgeoning#", "8d8#Bludgeoning#", "12d8#Bludgeoning#")]
        [TestCase(WeaponConstants.Guisarme,
            "1d4#Slashing#", "1d6#Slashing#", "2d4#Slashing#", "2d6#Slashing#", "3d6#Slashing#", "4d6#Slashing#", "6d6#Slashing#",
            "3d4#Slashing#", "3d6#Slashing#", "6d4#Slashing#", "6d6#Slashing#", "9d6#Slashing#", "12d6#Slashing#", "18d6#Slashing#")]
        [TestCase(WeaponConstants.Halberd,
            "1d6#Piercing or Slashing#", "1d8#Piercing or Slashing#", "1d10#Piercing or Slashing#", "2d8#Piercing or Slashing#", "3d8#Piercing or Slashing#", "4d8#Piercing or Slashing#", "6d8#Piercing or Slashing#",
            "3d6#Piercing or Slashing#", "3d8#Piercing or Slashing#", "3d10#Piercing or Slashing#", "6d8#Piercing or Slashing#", "9d8#Piercing or Slashing#", "12d8#Piercing or Slashing#", "18d8#Piercing or Slashing#")]
        [TestCase(WeaponConstants.Spear,
            "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#", "6d6#Piercing#",
            "3d4#Piercing#", "3d6#Piercing#", "3d8#Piercing#", "6d6#Piercing#", "9d6#Piercing#", "12d6#Piercing#", "18d6#Piercing#")]
        [TestCase(WeaponConstants.GnomeHookedHammer,
            "1d4#Bludgeoning#,1d3#Piercing#", "1d6#Bludgeoning#,1d4#Piercing#", "1d8#Bludgeoning#,1d6#Piercing#", "2d6#Bludgeoning#,1d8#Piercing#", "3d6#Bludgeoning#,2d6#Piercing#", "4d6#Bludgeoning#,3d6#Piercing#", "6d6#Bludgeoning#,4d6#Piercing#",
            "3d4#Bludgeoning#,4d3#Piercing#", "3d6#Bludgeoning#,4d4#Piercing#", "3d8#Bludgeoning#,4d6#Piercing#", "6d6#Bludgeoning#,4d8#Piercing#", "9d6#Bludgeoning#,8d6#Piercing#", "12d6#Bludgeoning#,12d6#Piercing#", "18d6#Bludgeoning#,16d6#Piercing#")]
        [TestCase(WeaponConstants.LightHammer,
            "1d2#Bludgeoning#", "1d3#Bludgeoning#", "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#", "3d6#Bludgeoning#",
            "2d2#Bludgeoning#", "2d3#Bludgeoning#", "2d4#Bludgeoning#", "2d6#Bludgeoning#", "2d8#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#")]
        [TestCase(WeaponConstants.Handaxe,
            "1d3#Slashing#", "1d4#Slashing#", "1d6#Slashing#", "1d8#Slashing#", "2d6#Slashing#", "3d6#Slashing#", "4d6#Slashing#",
            "3d3#Slashing#", "3d4#Slashing#", "3d6#Slashing#", "3d8#Slashing#", "6d6#Slashing#", "9d6#Slashing#", "12d6#Slashing#")]
        [TestCase(WeaponConstants.Kukri,
            "1d2#Slashing#", "1d3#Slashing#", "1d4#Slashing#", "1d6#Slashing#", "1d8#Slashing#", "2d6#Slashing#", "3d6#Slashing#",
            "2d2#Slashing#", "2d3#Slashing#", "2d4#Slashing#", "2d6#Slashing#", "2d8#Slashing#", "4d6#Slashing#", "6d6#Slashing#")]
        [TestCase(WeaponConstants.Lance,
            "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#", "6d6#Piercing#",
            "3d4#Piercing#", "3d6#Piercing#", "3d8#Piercing#", "6d6#Piercing#", "9d6#Piercing#", "12d6#Piercing#", "18d6#Piercing#")]
        [TestCase(WeaponConstants.Longspear,
            "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#", "6d6#Piercing#",
            "3d4#Piercing#", "3d6#Piercing#", "3d8#Piercing#", "6d6#Piercing#", "9d6#Piercing#", "12d6#Piercing#", "18d6#Piercing#")]
        [TestCase(WeaponConstants.Morningstar,
            "1d4#Bludgeoning and Piercing#", "1d6#Bludgeoning and Piercing#", "1d8#Bludgeoning and Piercing#", "2d6#Bludgeoning and Piercing#", "3d6#Bludgeoning and Piercing#", "4d6#Bludgeoning and Piercing#", "6d6#Bludgeoning and Piercing#",
            "2d4#Bludgeoning and Piercing#", "2d6#Bludgeoning and Piercing#", "2d8#Bludgeoning and Piercing#", "4d6#Bludgeoning and Piercing#", "6d6#Bludgeoning and Piercing#", "8d6#Bludgeoning and Piercing#", "12d6#Bludgeoning and Piercing#")]
        [TestCase(WeaponConstants.Net,
            "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#",
            "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#")]
        [TestCase(WeaponConstants.HeavyPick,
            "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#",
            "4d3#Piercing#", "4d4#Piercing#", "4d6#Piercing#", "4d8#Piercing#", "8d6#Piercing#", "12d6#Piercing#", "16d6#Piercing#")]
        [TestCase(WeaponConstants.LightPick,
            "1d2#Piercing#", "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#",
            "4d2#Piercing#", "4d3#Piercing#", "4d4#Piercing#", "4d6#Piercing#", "4d8#Piercing#", "8d6#Piercing#", "12d6#Piercing#")]
        [TestCase(WeaponConstants.Sai,
            "1d2#Bludgeoning#", "1d3#Bludgeoning#", "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#", "3d6#Bludgeoning#",
            "2d2#Bludgeoning#", "2d3#Bludgeoning#", "2d4#Bludgeoning#", "2d6#Bludgeoning#", "2d8#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#")]
        [TestCase(WeaponConstants.Bolas,
            "1d2#Bludgeoning#", "1d3#Bludgeoning#", "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#", "3d6#Bludgeoning#",
            "2d2#Bludgeoning#", "2d3#Bludgeoning#", "2d4#Bludgeoning#", "2d6#Bludgeoning#", "2d8#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#")]
        [TestCase(WeaponConstants.Ranseur,
            "1d4#Piercing#", "1d6#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#", "6d6#Piercing#",
            "3d4#Piercing#", "3d6#Piercing#", "6d4#Piercing#", "6d6#Piercing#", "9d6#Piercing#", "12d6#Piercing#", "18d6#Piercing#")]
        [TestCase(WeaponConstants.Sap,
            "1d3#Bludgeoning#", "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#", "3d6#Bludgeoning#", "4d6#Bludgeoning#",
            "2d3#Bludgeoning#", "2d4#Bludgeoning#", "2d6#Bludgeoning#", "2d8#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#", "8d6#Bludgeoning#")]
        [TestCase(WeaponConstants.Scythe,
            "1d4#Piercing or Slashing#", "1d6#Piercing or Slashing#", "2d4#Piercing or Slashing#", "2d6#Piercing or Slashing#", "3d6#Piercing or Slashing#", "4d6#Piercing or Slashing#", "6d6#Piercing or Slashing#",
            "4d4#Piercing or Slashing#", "4d6#Piercing or Slashing#", "8d4#Piercing or Slashing#", "8d6#Piercing or Slashing#", "12d6#Piercing or Slashing#", "16d6#Piercing or Slashing#", "24d6#Piercing or Slashing#")]
        [TestCase(WeaponConstants.Shuriken,
            "0#Piercing#", "1#Piercing#", "1d2#Piercing#", "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#",
            "1#Piercing#", "2#Piercing#", "2d2#Piercing#", "2d3#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#")]
        [TestCase(WeaponConstants.Sickle,
            "1d3#Slashing#", "1d4#Slashing#", "1d6#Slashing#", "1d8#Slashing#", "2d6#Slashing#", "3d6#Slashing#", "4d6#Slashing#",
            "2d3#Slashing#", "2d4#Slashing#", "2d6#Slashing#", "2d8#Slashing#", "4d6#Slashing#", "6d6#Slashing#", "8d6#Slashing#")]
        [TestCase(WeaponConstants.TwoBladedSword,
            "1d4#Slashing#,1d4#Slashing#", "1d6#Slashing#,1d6#Slashing#", "1d8#Slashing#,1d8#Slashing#", "2d6#Slashing#,2d6#Slashing#", "3d6#Slashing#,3d6#Slashing#", "4d6#Slashing#,4d6#Slashing#", "6d6#Slashing#,6d6#Slashing#",
            "2d4#Slashing#,2d4#Slashing#", "2d6#Slashing#,2d6#Slashing#", "2d8#Slashing#,2d8#Slashing#", "4d6#Slashing#,4d6#Slashing#", "6d6#Slashing#,6d6#Slashing#", "8d6#Slashing#,8d6#Slashing#", "12d6#Slashing#,12d6#Slashing#")]
        [TestCase(WeaponConstants.Trident,
            "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#", "6d6#Piercing#",
            "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#", "8d6#Piercing#", "12d6#Piercing#")]
        [TestCase(WeaponConstants.DwarvenUrgrosh,
            "1d4#Slashing#,1d3#Piercing#", "1d6#Slashing#,1d4#Piercing#", "1d8#Slashing#,1d6#Piercing#", "2d6#Slashing#,1d8#Piercing#", "3d6#Slashing#,2d6#Piercing#", "4d6#Slashing#,3d6#Piercing#", "6d6#Slashing#,4d6#Piercing#",
            "3d4#Slashing#,3d3#Piercing#", "3d6#Slashing#,3d4#Piercing#", "3d8#Slashing#,3d6#Piercing#", "6d6#Slashing#,3d8#Piercing#", "9d6#Slashing#,6d6#Piercing#", "12d6#Slashing#,9d6#Piercing#", "18d6#Slashing#,12d6#Piercing#")]
        [TestCase(WeaponConstants.Warhammer,
            "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#", "3d6#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#",
            "3d4#Bludgeoning#", "3d6#Bludgeoning#", "3d8#Bludgeoning#", "6d6#Bludgeoning#", "9d6#Bludgeoning#", "12d6#Bludgeoning#", "18d6#Bludgeoning#")]
        [TestCase(WeaponConstants.Whip,
            "1#Slashing#", "1d2#Slashing#", "1d3#Slashing#", "1d4#Slashing#", "1d6#Slashing#", "1d8#Slashing#", "2d6#Slashing#",
            "2#Slashing#", "2d2#Slashing#", "2d3#Slashing#", "2d4#Slashing#", "2d6#Slashing#", "2d8#Slashing#", "4d6#Slashing#")]
        [TestCase(WeaponConstants.ThrowingAxe,
            "1d3#Slashing#", "1d4#Slashing#", "1d6#Slashing#", "1d8#Slashing#", "2d6#Slashing#", "3d6#Slashing#", "4d6#Slashing#",
            "2d3#Slashing#", "2d4#Slashing#", "2d6#Slashing#", "2d8#Slashing#", "4d6#Slashing#", "6d6#Slashing#", "8d6#Slashing#")]
        [TestCase(WeaponConstants.HeavyCrossbow,
            "1d6#Piercing#", "1d8#Piercing#", "1d10#Piercing#", "2d8#Piercing#", "3d8#Piercing#", "4d8#Piercing#", "6d8#Piercing#",
            "2d6#Piercing#", "2d8#Piercing#", "2d10#Piercing#", "4d8#Piercing#", "6d8#Piercing#", "8d8#Piercing#", "12d8#Piercing#")]
        [TestCase(WeaponConstants.LightCrossbow,
            "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#", "6d6#Piercing#",
            "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#", "8d6#Piercing#", "12d6#Piercing#")]
        [TestCase(WeaponConstants.Dart,
            "1d2#Piercing#", "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#",
            "2d2#Piercing#", "2d3#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#")]
        [TestCase(WeaponConstants.Javelin,
            "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#",
            "2d3#Piercing#", "2d4#Piercing#", "2d6#Piercing#", "2d8#Piercing#", "4d6#Piercing#", "6d6#Piercing#", "8d6#Piercing#")]
        [TestCase(WeaponConstants.Shortbow,
            "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#",
            "3d3#Piercing#", "3d4#Piercing#", "3d6#Piercing#", "3d8#Piercing#", "6d6#Piercing#", "9d6#Piercing#", "12d6#Piercing#")]
        [TestCase(WeaponConstants.CompositeShortbow,
            "1d3#Piercing#", "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#",
            "3d3#Piercing#", "3d4#Piercing#", "3d6#Piercing#", "3d8#Piercing#", "6d6#Piercing#", "9d6#Piercing#", "12d6#Piercing#")]
        [TestCase(WeaponConstants.Sling,
            "1d2#Bludgeoning#", "1d3#Bludgeoning#", "1d4#Bludgeoning#", "1d6#Bludgeoning#", "1d8#Bludgeoning#", "2d6#Bludgeoning#", "3d6#Bludgeoning#",
            "2d2#Bludgeoning#", "2d3#Bludgeoning#", "2d4#Bludgeoning#", "2d6#Bludgeoning#", "2d8#Bludgeoning#", "4d6#Bludgeoning#", "6d6#Bludgeoning#")]
        [TestCase(WeaponConstants.Longbow,
            "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#", "6d6#Piercing#",
            "3d4#Piercing#", "3d6#Piercing#", "3d8#Piercing#", "6d6#Piercing#", "9d6#Piercing#", "12d6#Piercing#", "18d6#Piercing#")]
        [TestCase(WeaponConstants.CompositeLongbow,
            "1d4#Piercing#", "1d6#Piercing#", "1d8#Piercing#", "2d6#Piercing#", "3d6#Piercing#", "4d6#Piercing#", "6d6#Piercing#",
            "3d4#Piercing#", "3d6#Piercing#", "3d8#Piercing#", "6d6#Piercing#", "9d6#Piercing#", "12d6#Piercing#", "18d6#Piercing#")]
        [TestCase(WeaponConstants.Arrow,
            "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#",
            "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#")]
        [TestCase(WeaponConstants.CrossbowBolt,
            "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#",
            "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#", "0#Piercing#")]
        [TestCase(WeaponConstants.SlingBullet,
            "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#",
            "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#", "0#Bludgeoning#")]
        [TestCase(WeaponConstants.PincerStaff,
            "1d6#Bludgeoning#", "1d8#Bludgeoning#", "1d10#Bludgeoning#", "2d8#Bludgeoning#", "3d8#Bludgeoning#", "4d8#Bludgeoning#", "6d8#Bludgeoning#",
            "2d6#Bludgeoning#", "2d8#Bludgeoning#", "2d10#Bludgeoning#", "4d8#Bludgeoning#", "6d8#Bludgeoning#", "8d8#Bludgeoning#", "12d8#Bludgeoning#")]
        public void WeaponDamages(string weapon, params string[] damagesData)
        {
            foreach (var data in damagesData)
            {
                var isValid = damageHelper.ValidateEntry(data);
                Assert.That(isValid, Is.True, data);
            }

            var parsed = damagesData.SelectMany(damageHelper.ParseEntry).ToArray();
            var entries = damageHelper.BuildEntries(parsed);
            var datas = damageHelper.ParseEntries(entries);
            var damages = datas.Select(damageHelper.BuildEntry).ToArray();

            var sizes = TraitConstants.Sizes.All();
            Assert.That(damages, Has.Length.EqualTo(sizes.Count() * 2)
                .And.All.Not.Empty);

            foreach (var damage in damages)
            {
                var isValid = damageHelper.ValidateEntries(damage);
                Assert.That(isValid, Is.True);
            }

            base.OrderedCollections(weapon, damages);
        }

        [TestCase(SpecialAbilityConstants.Aberrationbane,
            "2d6##Against Aberrations",
            "2d6##Against Aberrations",
            "2d6##Against Aberrations",
            "2d6##Against Aberrations")]
        [TestCase(SpecialAbilityConstants.AcidResistance)]
        [TestCase(SpecialAbilityConstants.AirOutsiderbane,
            "2d6##Against Air Outsiders",
            "2d6##Against Air Outsiders",
            "2d6##Against Air Outsiders",
            "2d6##Against Air Outsiders")]
        [TestCase(SpecialAbilityConstants.Anarchic,
            "2d6##Against Lawful alignment",
            "2d6##Against Lawful alignment",
            "2d6##Against Lawful alignment",
            "2d6##Against Lawful alignment")]
        [TestCase(SpecialAbilityConstants.Animalbane,
            "2d6##Against Animals",
            "2d6##Against Animals",
            "2d6##Against Animals",
            "2d6##Against Animals")]
        [TestCase(SpecialAbilityConstants.Animated)]
        [TestCase(SpecialAbilityConstants.AquaticHumanoidbane,
            "2d6##Against Aquatic humanoids",
            "2d6##Against Aquatic humanoids",
            "2d6##Against Aquatic humanoids",
            "2d6##Against Aquatic humanoids")]
        [TestCase(SpecialAbilityConstants.ArrowCatching)]
        [TestCase(SpecialAbilityConstants.ArrowDeflection)]
        [TestCase(SpecialAbilityConstants.Axiomatic,
            "2d6##Against Chaotic alignment",
            "2d6##Against Chaotic alignment",
            "2d6##Against Chaotic alignment",
            "2d6##Against Chaotic alignment")]
        [TestCase(SpecialAbilityConstants.Bane,
            "2d6##Against DESIGNATEDFOE",
            "2d6##Against DESIGNATEDFOE",
            "2d6##Against DESIGNATEDFOE",
            "2d6##Against DESIGNATEDFOE")]
        [TestCase(SpecialAbilityConstants.Bashing)]
        [TestCase(SpecialAbilityConstants.Blinding)]
        [TestCase(SpecialAbilityConstants.BrilliantEnergy)]
        [TestCase(SpecialAbilityConstants.ChaoticOutsiderbane,
            "2d6##Against Chaotic Outsiders",
            "2d6##Against Chaotic Outsiders",
            "2d6##Against Chaotic Outsiders",
            "2d6##Against Chaotic Outsiders")]
        [TestCase(SpecialAbilityConstants.ColdResistance)]
        [TestCase(SpecialAbilityConstants.Constructbane,
            "2d6##Against Constructs",
            "2d6##Against Constructs",
            "2d6##Against Constructs",
            "2d6##Against Constructs")]
        [TestCase(SpecialAbilityConstants.Dancing)]
        [TestCase(SpecialAbilityConstants.Defending)]
        [TestCase(SpecialAbilityConstants.DESIGNATEDFOEbane,
            "2d6##Against DESIGNATEDFOE",
            "2d6##Against DESIGNATEDFOE",
            "2d6##Against DESIGNATEDFOE",
            "2d6##Against DESIGNATEDFOE")]
        [TestCase(SpecialAbilityConstants.Disruption)]
        [TestCase(SpecialAbilityConstants.Distance)]
        [TestCase(SpecialAbilityConstants.Dragonbane,
            "2d6##Against Dragons",
            "2d6##Against Dragons",
            "2d6##Against Dragons",
            "2d6##Against Dragons")]
        [TestCase(SpecialAbilityConstants.Dwarfbane,
            "2d6##Against Dwarfs",
            "2d6##Against Dwarfs",
            "2d6##Against Dwarfs",
            "2d6##Against Dwarfs")]
        [TestCase(SpecialAbilityConstants.EarthOutsiderbane,
            "2d6##Against Earth Outsiders",
            "2d6##Against Earth Outsiders",
            "2d6##Against Earth Outsiders",
            "2d6##Against Earth Outsiders")]
        [TestCase(SpecialAbilityConstants.ElectricityResistance)]
        [TestCase(SpecialAbilityConstants.Elementalbane,
            "2d6##Against Elementals",
            "2d6##Against Elementals",
            "2d6##Against Elementals",
            "2d6##Against Elementals")]
        [TestCase(SpecialAbilityConstants.Elfbane,
            "2d6##Against Elfs",
            "2d6##Against Elfs",
            "2d6##Against Elfs",
            "2d6##Against Elfs")]
        [TestCase(SpecialAbilityConstants.Etherealness)]
        [TestCase(SpecialAbilityConstants.EvilOutsiderbane,
            "2d6##Against Evil Outsiders",
            "2d6##Against Evil Outsiders",
            "2d6##Against Evil Outsiders",
            "2d6##Against Evil Outsiders")]
        [TestCase(SpecialAbilityConstants.Feybane,
            "2d6##Against Feys",
            "2d6##Against Feys",
            "2d6##Against Feys",
            "2d6##Against Feys")]
        [TestCase(SpecialAbilityConstants.FireOutsiderbane,
            "2d6##Against Fire Outsiders",
            "2d6##Against Fire Outsiders",
            "2d6##Against Fire Outsiders",
            "2d6##Against Fire Outsiders")]
        [TestCase(SpecialAbilityConstants.FireResistance)]
        [TestCase(SpecialAbilityConstants.Flaming,
            "1d6#Fire#",
            "1d6#Fire#",
            "1d6#Fire#",
            "1d6#Fire#")]
        [TestCase(SpecialAbilityConstants.FlamingBurst,
            "1d6#Fire#",
            "1d6#Fire#,1d10#Fire#",
            "1d6#Fire#,2d10#Fire#",
            "1d6#Fire#,3d10#Fire#")]
        [TestCase(SpecialAbilityConstants.Fortification)]
        [TestCase(SpecialAbilityConstants.Frost,
            "1d6#Cold#",
            "1d6#Cold#",
            "1d6#Cold#",
            "1d6#Cold#")]
        [TestCase(SpecialAbilityConstants.GhostTouch)]
        [TestCase(SpecialAbilityConstants.GhostTouchArmor)]
        [TestCase(SpecialAbilityConstants.GhostTouchWeapon)]
        [TestCase(SpecialAbilityConstants.Giantbane,
            "2d6##Against Giants",
            "2d6##Against Giants",
            "2d6##Against Giants",
            "2d6##Against Giants")]
        [TestCase(SpecialAbilityConstants.Glamered)]
        [TestCase(SpecialAbilityConstants.Gnollbane, "2d6##Against Gnolls", "2d6##Against Gnolls", "2d6##Against Gnolls", "2d6##Against Gnolls")]
        [TestCase(SpecialAbilityConstants.Gnomebane, "2d6##Against Gnomes", "2d6##Against Gnomes", "2d6##Against Gnomes", "2d6##Against Gnomes")]
        [TestCase(SpecialAbilityConstants.Goblinoidbane, "2d6##Against Goblinoids", "2d6##Against Goblinoids", "2d6##Against Goblinoids", "2d6##Against Goblinoids")]
        [TestCase(SpecialAbilityConstants.GoodOutsiderbane, "2d6##Against Good Outsiders", "2d6##Against Good Outsiders", "2d6##Against Good Outsiders", "2d6##Against Good Outsiders")]
        [TestCase(SpecialAbilityConstants.GreaterAcidResistance)]
        [TestCase(SpecialAbilityConstants.GreaterColdResistance)]
        [TestCase(SpecialAbilityConstants.GreaterElectricityResistance)]
        [TestCase(SpecialAbilityConstants.GreaterFireResistance)]
        [TestCase(SpecialAbilityConstants.GreaterShadow)]
        [TestCase(SpecialAbilityConstants.GreaterSilentMoves)]
        [TestCase(SpecialAbilityConstants.GreaterSlick)]
        [TestCase(SpecialAbilityConstants.GreaterSonicResistance)]
        [TestCase(SpecialAbilityConstants.Halflingbane, "2d6##Against Halflings", "2d6##Against Halflings", "2d6##Against Halflings", "2d6##Against Halflings")]
        [TestCase(SpecialAbilityConstants.HeavyFortification)]
        [TestCase(SpecialAbilityConstants.Holy, "2d6##Against Evil alignment", "2d6##Against Evil alignment", "2d6##Against Evil alignment", "2d6##Against Evil alignment")]
        [TestCase(SpecialAbilityConstants.Humanbane, "2d6##Against Humans", "2d6##Against Humans", "2d6##Against Humans", "2d6##Against Humans")]
        [TestCase(SpecialAbilityConstants.IcyBurst, "1d6#Cold#", "1d6#Cold#,1d10#Cold#", "1d6#Cold#,2d10#Cold#", "1d6#Cold#,3d10#Cold#")]
        [TestCase(SpecialAbilityConstants.ImprovedAcidResistance)]
        [TestCase(SpecialAbilityConstants.ImprovedColdResistance)]
        [TestCase(SpecialAbilityConstants.ImprovedElectricityResistance)]
        [TestCase(SpecialAbilityConstants.ImprovedFireResistance)]
        [TestCase(SpecialAbilityConstants.ImprovedShadow)]
        [TestCase(SpecialAbilityConstants.ImprovedSilentMoves)]
        [TestCase(SpecialAbilityConstants.ImprovedSlick)]
        [TestCase(SpecialAbilityConstants.ImprovedSonicResistance)]
        [TestCase(SpecialAbilityConstants.Invulnerability)]
        [TestCase(SpecialAbilityConstants.Keen)]
        [TestCase(SpecialAbilityConstants.KiFocus)]
        [TestCase(SpecialAbilityConstants.LawfulOutsiderbane, "2d6##Against Lawful Outsiders", "2d6##Against Lawful Outsiders", "2d6##Against Lawful Outsiders", "2d6##Against Lawful Outsiders")]
        [TestCase(SpecialAbilityConstants.LightFortification)]
        [TestCase(SpecialAbilityConstants.MagicalBeastbane, "2d6##Against Magical Beasts", "2d6##Against Magical Beasts", "2d6##Against Magical Beasts", "2d6##Against Magical Beasts")]
        [TestCase(SpecialAbilityConstants.Merciful, "1d6##", "1d6##", "1d6##", "1d6##")]
        [TestCase(SpecialAbilityConstants.MightyCleaving)]
        [TestCase(SpecialAbilityConstants.ModerateFortification)]
        [TestCase(SpecialAbilityConstants.MonstrousHumanoidbane, "2d6##Against Monstrous Humanoids", "2d6##Against Monstrous Humanoids", "2d6##Against Monstrous Humanoids", "2d6##Against Monstrous Humanoids")]
        [TestCase(SpecialAbilityConstants.Oozebane, "2d6##Against Oozes", "2d6##Against Oozes", "2d6##Against Oozes", "2d6##Against Oozes")]
        [TestCase(SpecialAbilityConstants.Orcbane, "2d6##Against Orcs", "2d6##Against Orcs", "2d6##Against Orcs", "2d6##Against Orcs")]
        [TestCase(SpecialAbilityConstants.Plantbane, "2d6##Against Plants", "2d6##Against Plants", "2d6##Against Plants", "2d6##Against Plants")]
        [TestCase(SpecialAbilityConstants.Reflecting)]
        [TestCase(SpecialAbilityConstants.ReptilianHumanoidbane, "2d6##Against Reptilian Humanoids", "2d6##Against Reptilian Humanoids", "2d6##Against Reptilian Humanoids", "2d6##Against Reptilian Humanoids")]
        [TestCase(SpecialAbilityConstants.Returning)]
        [TestCase(SpecialAbilityConstants.Seeking)]
        [TestCase(SpecialAbilityConstants.Shadow)]
        [TestCase(SpecialAbilityConstants.Shapeshifterbane, "2d6##Against Shapeshifters", "2d6##Against Shapeshifters", "2d6##Against Shapeshifters", "2d6##Against Shapeshifters")]
        [TestCase(SpecialAbilityConstants.Shock, "1d6#Electricity#", "1d6#Electricity#", "1d6#Electricity#", "1d6#Electricity#")]
        [TestCase(SpecialAbilityConstants.ShockingBurst, "1d6#Electricity#", "1d6#Electricity#,1d10#Electricity#", "1d6#Electricity#,2d10#Electricity#", "1d6#Electricity#,3d10#Electricity#")]
        [TestCase(SpecialAbilityConstants.SilentMoves)]
        [TestCase(SpecialAbilityConstants.Slick)]
        [TestCase(SpecialAbilityConstants.SonicResistance)]
        [TestCase(SpecialAbilityConstants.Speed)]
        [TestCase(SpecialAbilityConstants.SpellResistance)]
        [TestCase(SpecialAbilityConstants.SpellResistance13)]
        [TestCase(SpecialAbilityConstants.SpellResistance15)]
        [TestCase(SpecialAbilityConstants.SpellResistance17)]
        [TestCase(SpecialAbilityConstants.SpellResistance19)]
        [TestCase(SpecialAbilityConstants.SpellStoring)]
        [TestCase(SpecialAbilityConstants.Throwing)]
        [TestCase(SpecialAbilityConstants.Thundering, "", "1d8#Sonic#", "2d8#Sonic#", "3d8#Sonic#")]
        [TestCase(SpecialAbilityConstants.Undeadbane, "2d6##Against Undead", "2d6##Against Undead", "2d6##Against Undead", "2d6##Against Undead")]
        [TestCase(SpecialAbilityConstants.UndeadControlling)]
        [TestCase(SpecialAbilityConstants.Unholy, "2d6##Against Good alignment", "2d6##Against Good alignment", "2d6##Against Good alignment", "2d6##Against Good alignment")]
        [TestCase(SpecialAbilityConstants.Verminbane, "2d6##Against Vermin", "2d6##Against Vermin", "2d6##Against Vermin", "2d6##Against Vermin")]
        [TestCase(SpecialAbilityConstants.Vicious, "2d6##,1d6##To the Wielder", "2d6##,1d6##To the Wielder", "2d6##,1d6##To the Wielder", "2d6##,1d6##To the Wielder")]
        [TestCase(SpecialAbilityConstants.Vorpal)]
        [TestCase(SpecialAbilityConstants.WaterOutsiderbane, "2d6##Against Water Outsiders", "2d6##Against Water Outsiders", "2d6##Against Water Outsiders", "2d6##Against Water Outsiders")]
        [TestCase(SpecialAbilityConstants.Wild)]
        [TestCase(SpecialAbilityConstants.Wounding, "1#Constitution#", "1#Constitution#", "1#Constitution#", "1#Constitution#")]
        public void SpecialAbilityDamages(string specialAbility, params string[] damagesData)
        {
            foreach (var data in damagesData)
            {
                var isValid = damageHelper.ValidateEntry(data);
                Assert.That(isValid, Is.True, data);
            }

            var parsed = damagesData.SelectMany(damageHelper.ParseEntry).ToArray();
            var entries = damageHelper.BuildEntries(parsed);
            var datas = damageHelper.ParseEntries(entries);
            var damages = datas.Select(damageHelper.BuildEntry).ToArray();

            Assert.That(damages, Has.Length.EqualTo(4).Or.Empty);

            foreach (var damage in damages)
            {
                var isValid = damageHelper.ValidateEntries(damage);
                Assert.That(isValid, Is.True);
            }

            base.OrderedCollections(specialAbility, damages);
        }

        [Test]
        public void AllKeysArePresent()
        {
            var weapons = WeaponConstants.GetAllWeapons(false, false);
            var specialAbilities = SpecialAbilityConstants.GetAllAbilities(true);

            var expectedKeys = weapons.Union(specialAbilities);
            var actualKeys = GetKeys();

            AssertCollection(actualKeys, expectedKeys);
        }

        [Test]
        public void BludgeoningWeaponsMatchConstants()
        {
            var weapons = WeaponConstants.GetAllWeapons(false, false);
            var bludgeoning = WeaponConstants.GetAllBludgeoning(false, false);

            foreach (var weapon in weapons)
            {
                var data = table[weapon];

                var isBludgeoning = bludgeoning.Contains(weapon);
                var hasBludgeoning = data.All(d => d.Contains(AttributeConstants.DamageTypes.Bludgeoning));

                Assert.That(hasBludgeoning, Is.EqualTo(isBludgeoning), weapon);
            }
        }

        [Test]
        public void PiercingWeaponsMatchConstants()
        {
            var weapons = WeaponConstants.GetAllWeapons(false, false);
            var piercing = WeaponConstants.GetAllPiercing(false, false);

            foreach (var weapon in weapons)
            {
                var data = table[weapon];

                var isPiercing = piercing.Contains(weapon);
                var hasPiercing = data.All(d => d.Contains(AttributeConstants.DamageTypes.Piercing));

                Assert.That(hasPiercing, Is.EqualTo(isPiercing), weapon);
            }
        }

        [Test]
        public void SlashingWeaponsMatchConstants()
        {
            var weapons = WeaponConstants.GetAllWeapons(false, false);
            var slashing = WeaponConstants.GetAllSlashing(false, false);

            foreach (var weapon in weapons)
            {
                var data = table[weapon];

                var isSlashing = slashing.Contains(weapon);
                var hasSlashing = data.All(d => d.Contains(AttributeConstants.DamageTypes.Slashing));

                Assert.That(hasSlashing, Is.EqualTo(isSlashing), weapon);
            }
        }

        [Test]
        public void DoubleWeaponsHaveMultipleDamages()
        {
            var weapons = WeaponConstants.GetAllWeapons(false, false);
            var doubleWeapons = WeaponConstants.GetAllDouble(false, false);

            foreach (var weapon in weapons)
            {
                var isDouble = doubleWeapons.Contains(weapon);
                var damageData = table[weapon].Select(d => damageHelper.ParseEntries(d));

                if (isDouble)
                {
                    Assert.That(damageData, Is.All.Length.EqualTo(2), weapon);
                }
                else
                {
                    Assert.That(damageData, Is.All.Length.EqualTo(1), weapon);
                }
            }
        }

        [Test]
        public void WeaponCriticalDamagesHaveCorrectMultiplier()
        {
            var weapons = WeaponConstants.GetAllWeapons(false, false);
            var sizes = TraitConstants.Sizes.All().ToArray();

            foreach (var weapon in weapons)
            {
                var weaponData = weaponDataSelector.Select(weapon);
                var damageDatas = table[weapon].Select(d => damageHelper.ParseEntries(d));

                foreach (var damageData in damageDatas)
                {
                    for (var i = 0; i < sizes.Length; i++)
                    {
                        var normal = damageData[i];
                        var critical = damageData[i + sizes.Length];

                        Assert.That(critical[DataIndexConstants.Weapon.DamageData.TypeIndex], Is.EqualTo(normal[DataIndexConstants.Weapon.DamageData.TypeIndex]), weapon);
                        Assert.That(normal[DataIndexConstants.Weapon.DamageData.ConditionIndex], Is.Empty, weapon);
                        Assert.That(critical[DataIndexConstants.Weapon.DamageData.ConditionIndex], Is.Empty, weapon);

                        var normalSections = normal[DataIndexConstants.Weapon.DamageData.RollIndex].Split('d');
                        var normalQuantity = Convert.ToInt32(normalSections[0]);
                        var normalDie = Convert.ToInt32(normalSections[1]);

                        var criticalSections = critical[DataIndexConstants.Weapon.DamageData.RollIndex].Split('d');
                        var criticalQuantity = Convert.ToInt32(criticalSections[0]);
                        var criticalDie = Convert.ToInt32(criticalSections[1]);

                        Assert.That(criticalDie, Is.EqualTo(normalDie), weapon);
                        Assert.That(criticalQuantity, Is.EqualTo(normalQuantity * 2), weapon);
                    }
                }
            }
        }
    }
}
