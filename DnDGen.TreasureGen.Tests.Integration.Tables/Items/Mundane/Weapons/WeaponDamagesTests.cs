using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Selectors.Helpers;
using DnDGen.TreasureGen.Tables;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class WeaponDamagesTests : CollectionsTests
    {
        protected override string tableName => TableNameConstants.Collections.Set.WeaponDamages;

        private DamageHelper damageHelper;

        [SetUp]
        public void Setup()
        {
            damageHelper = new DamageHelper();
        }

        [TestCase(WeaponConstants.Dagger,
            "1d2#Piercing or slashing", "1d3#Piercing or slashing", "1d4#Piercing or slashing", "1d6#Piercing or slashing", "1d8#Piercing or slashing", "2d6#Piercing or slashing", "3d6#Piercing or slashing",
            "2d2#Piercing or slashing", "2d3#Piercing or slashing", "2d4#Piercing or slashing", "2d6#Piercing or slashing", "2d8#Piercing or slashing", "4d6#Piercing or slashing", "6d6#Piercing or slashing")]
        [TestCase(WeaponConstants.Greataxe,
            "1d8#Slashing", "1d10#Slashing", "1d12#Slashing", "3d6#Slashing", "4d6#Slashing", "6d6#Slashing", "8d6#Slashing",
            "3d8#Slashing", "3d10#Slashing", "3d12#Slashing", "9d6#Slashing", "12d6#Slashing", "18d6#Slashing", "24d6#Slashing")]
        [TestCase(WeaponConstants.Greatsword,
            "1d8#Slashing", "1d10#Slashing", "1d12#Slashing", "3d6#Slashing", "4d6#Slashing", "6d6#Slashing", "8d6#Slashing",
            "2d8#Slashing", "2d10#Slashing", "4d6#Slashing", "6d6#Slashing", "8d6#Slashing", "12d6#Slashing", "16d6#Slashing")]
        [TestCase(WeaponConstants.Kama,
            "1d3#Slashing", "1d4#Slashing", "1d6#Slashing", "1d8#Slashing", "2d6#Slashing", "3d6#Slashing", "4d6#Slashing",
            "2d3#Slashing", "2d4#Slashing", "2d6#Slashing", "2d8#Slashing", "4d6#Slashing", "6d6#Slashing", "8d6#Slashing")]
        [TestCase(WeaponConstants.Longsword,
            "1d4#Slashing", "1d6#Slashing", "1d8#Slashing", "2d6#Slashing", "3d6#Slashing", "4d6#Slashing", "6d6#Slashing",
            "2d4#Slashing", "2d6#Slashing", "2d8#Slashing", "4d6#Slashing", "6d6#Slashing", "8d6#Slashing", "12d6#Slashing")]
        [TestCase(WeaponConstants.LightMace,
            "1d3#Bludgeoning", "1d4#Bludgeoning", "1d6#Bludgeoning", "1d8#Bludgeoning", "2d6#Bludgeoning", "3d6#Bludgeoning", "4d6#Bludgeoning",
            "2d3#Bludgeoning", "2d4#Bludgeoning", "2d6#Bludgeoning", "2d8#Bludgeoning", "4d6#Bludgeoning", "6d6#Bludgeoning", "8d6#Bludgeoning")]
        [TestCase(WeaponConstants.HeavyMace,
            "1d4#Bludgeoning", "1d6#Bludgeoning", "1d8#Bludgeoning", "2d6#Bludgeoning", "3d6#Bludgeoning", "4d6#Bludgeoning", "6d6#Bludgeoning",
            "2d4#Bludgeoning", "2d6#Bludgeoning", "2d8#Bludgeoning", "4d6#Bludgeoning", "6d6#Bludgeoning", "8d6#Bludgeoning", "12d6#Bludgeoning")]
        [TestCase(WeaponConstants.Nunchaku,
            "1d3#Bludgeoning", "1d4#Bludgeoning", "1d6#Bludgeoning", "1d8#Bludgeoning", "2d6#Bludgeoning", "3d6#Bludgeoning", "4d6#Bludgeoning",
            "2d3#Bludgeoning", "2d4#Bludgeoning", "2d6#Bludgeoning", "2d8#Bludgeoning", "4d6#Bludgeoning", "6d6#Bludgeoning", "8d6#Bludgeoning")]
        [TestCase(WeaponConstants.Quarterstaff,
            "1d3#Bludgeoning,1d3#Bludgeoning", "1d4#Bludgeoning,1d4#Bludgeoning", "1d6#Bludgeoning,1d6#Bludgeoning", "1d8#Bludgeoning,1d8#Bludgeoning", "2d6#Bludgeoning,2d6#Bludgeoning", "3d6#Bludgeoning,3d6#Bludgeoning", "4d6#Bludgeoning,4d6#Bludgeoning",
            "2d3#Bludgeoning,2d3#Bludgeoning", "2d4#Bludgeoning,2d4#Bludgeoning", "2d6#Bludgeoning,2d6#Bludgeoning", "2d8#Bludgeoning,2d8#Bludgeoning", "4d6#Bludgeoning,4d6#Bludgeoning", "6d6#Bludgeoning,6d6#Bludgeoning", "8d6#Bludgeoning,8d6#Bludgeoning")]
        [TestCase(WeaponConstants.Rapier,
            "1d3#Piercing", "1d4#Piercing", "1d6#Piercing", "1d8#Piercing", "2d6#Piercing", "3d6#Piercing", "4d6#Piercing",
            "2d3#Piercing", "2d4#Piercing", "2d6#Piercing", "2d8#Piercing", "4d6#Piercing", "6d6#Piercing", "8d6#Piercing")]
        [TestCase(WeaponConstants.Scimitar,
            "1d3#Slashing", "1d4#Slashing", "1d6#Slashing", "1d8#Slashing", "2d6#Slashing", "3d6#Slashing", "4d6#Slashing",
            "2d3#Slashing", "2d4#Slashing", "2d6#Slashing", "2d8#Slashing", "4d6#Slashing", "6d6#Slashing", "8d6#Slashing")]
        [TestCase(WeaponConstants.Shortspear,
            "1d3#Piercing", "1d4#Piercing", "1d6#Piercing", "1d8#Piercing", "2d6#Piercing", "3d6#Piercing", "4d6#Piercing",
            "2d3#Piercing", "2d4#Piercing", "2d6#Piercing", "2d8#Piercing", "4d6#Piercing", "6d6#Piercing", "8d6#Piercing")]
        [TestCase(WeaponConstants.Siangham,
            "1d3#Piercing", "1d4#Piercing", "1d6#Piercing", "1d8#Piercing", "2d6#Piercing", "3d6#Piercing", "4d6#Piercing",
            "2d3#Piercing", "2d4#Piercing", "2d6#Piercing", "2d8#Piercing", "4d6#Piercing", "6d6#Piercing", "8d6#Piercing")]
        [TestCase(WeaponConstants.BastardSword,
            "1d6#Slashing", "1d8#Slashing", "1d10#Slashing", "2d8#Slashing", "3d8#Slashing", "4d8#Slashing", "6d8#Slashing",
            "2d6#Slashing", "2d8#Slashing", "2d10#Slashing", "4d8#Slashing", "6d8#Slashing", "8d8#Slashing", "12d8#Slashing")]
        [TestCase(WeaponConstants.ShortSword,
            "1d3#Piercing", "1d4#Piercing", "1d6#Piercing", "1d8#Piercing", "2d6#Piercing", "3d6#Piercing", "4d6#Piercing",
            "2d3#Piercing", "2d4#Piercing", "2d6#Piercing", "2d8#Piercing", "4d6#Piercing", "6d6#Piercing", "8d6#Piercing")]
        [TestCase(WeaponConstants.DwarvenWaraxe,
            "1d6#Slashing", "1d8#Slashing", "1d10#Slashing", "2d8#Slashing", "3d8#Slashing", "4d8#Slashing", "6d8#Slashing",
            "3d6#Slashing", "3d8#Slashing", "3d10#Slashing", "6d8#Slashing", "9d8#Slashing", "12d8#Slashing", "18d8#Slashing")]
        [TestCase(WeaponConstants.OrcDoubleAxe,
            "1d4#Slashing,1d4#Slashing", "1d6#Slashing,1d6#Slashing", "1d8#Slashing,1d8#Slashing", "2d6#Slashing,2d6#Slashing", "3d6#Slashing,3d6#Slashing", "4d6#Slashing,4d6#Slashing", "6d6#Slashing,6d6#Slashing",
            "3d4#Slashing,3d4#Slashing", "3d6#Slashing,3d6#Slashing", "3d8#Slashing,3d8#Slashing", "6d6#Slashing,6d6#Slashing", "9d6#Slashing,9d6#Slashing", "12d6#Slashing,12d6#Slashing", "18d6#Slashing,18d6#Slashing")]
        [TestCase(WeaponConstants.Battleaxe,
            "1d4#Slashing", "1d6#Slashing", "1d8#Slashing", "2d6#Slashing", "3d6#Slashing", "4d6#Slashing", "6d6#Slashing",
            "3d4#Slashing", "3d6#Slashing", "3d8#Slashing", "6d6#Slashing", "9d6#Slashing", "12d6#Slashing", "18d6#Slashing")]
        [TestCase(WeaponConstants.SpikedChain,
            "1d4#Piercing", "1d6#Piercing", "2d4#Piercing", "2d6#Piercing", "3d6#Piercing", "4d6#Piercing", "6d6#Piercing",
            "2d4#Piercing", "2d6#Piercing", "4d4#Piercing", "4d6#Piercing", "6d6#Piercing", "8d6#Piercing", "12d6#Piercing")]
        [TestCase(WeaponConstants.Club,
            "1d3#Bludgeoning", "1d4#Bludgeoning", "1d6#Bludgeoning", "1d8#Bludgeoning", "2d6#Bludgeoning", "3d6#Bludgeoning", "4d6#Bludgeoning",
            "2d3#Bludgeoning", "2d4#Bludgeoning", "2d6#Bludgeoning", "2d8#Bludgeoning", "4d6#Bludgeoning", "6d6#Bludgeoning", "8d6#Bludgeoning")]
        [TestCase(WeaponConstants.HandCrossbow,
            "1d2#Piercing", "1d3#Piercing", "1d4#Piercing", "1d6#Piercing", "1d8#Piercing", "2d6#Piercing", "3d6#Piercing",
            "2d2#Piercing", "2d3#Piercing", "2d4#Piercing", "2d6#Piercing", "2d8#Piercing", "4d6#Piercing", "6d6#Piercing")]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow,
            "1d6#Piercing", "1d8#Piercing", "1d10#Piercing", "2d8#Piercing", "3d8#Piercing", "4d8#Piercing", "6d8#Piercing",
            "2d6#Piercing", "2d8#Piercing", "2d10#Piercing", "4d8#Piercing", "6d8#Piercing", "8d8#Piercing", "12d8#Piercing")]
        [TestCase(WeaponConstants.LightRepeatingCrossbow,
            "1d4#Piercing", "1d6#Piercing", "1d8#Piercing", "2d6#Piercing", "3d6#Piercing", "4d6#Piercing", "6d6#Piercing",
            "2d4#Piercing", "2d6#Piercing", "2d8#Piercing", "4d6#Piercing", "6d6#Piercing", "8d6#Piercing", "12d6#Piercing")]
        [TestCase(WeaponConstants.PunchingDagger,
            "1d2#Piercing", "1d3#Piercing", "1d4#Piercing", "1d6#Piercing", "1d8#Piercing", "2d6#Piercing", "3d6#Piercing",
            "2d2#Piercing", "2d3#Piercing", "2d4#Piercing", "2d6#Piercing", "2d8#Piercing", "4d6#Piercing", "6d6#Piercing")]
        [TestCase(WeaponConstants.Falchion,
            "1d4#Slashing", "1d6#Slashing", "2d4#Slashing", "2d6#Slashing", "3d6#Slashing", "4d6#Slashing", "6d6#Slashing",
            "2d4#Slashing", "2d6#Slashing", "4d4#Slashing", "4d6#Slashing", "6d6#Slashing", "8d6#Slashing", "12d6#Slashing")]
        [TestCase(WeaponConstants.DireFlail,
            "1d4#Bludgeoning,1d4#Bludgeoning", "1d6#Bludgeoning,1d6#Bludgeoning", "1d8#Bludgeoning,1d8#Bludgeoning", "2d6#Bludgeoning,2d6#Bludgeoning", "3d6#Bludgeoning,3d6#Bludgeoning", "4d6#Bludgeoning,4d6#Bludgeoning", "6d6#Bludgeoning,6d6#Bludgeoning",
            "2d4#Bludgeoning,2d4#Bludgeoning", "2d6#Bludgeoning,2d6#Bludgeoning", "2d8#Bludgeoning,2d8#Bludgeoning", "4d6#Bludgeoning,4d6#Bludgeoning", "6d6#Bludgeoning,6d6#Bludgeoning", "8d6#Bludgeoning,8d6#Bludgeoning", "12d6#Bludgeoning,12d6#Bludgeoning")]
        [TestCase(WeaponConstants.HeavyFlail,
            "1d6#Bludgeoning", "1d8#Bludgeoning", "1d10#Bludgeoning", "2d8#Bludgeoning", "3d8#Bludgeoning", "4d8#Bludgeoning", "6d8#Bludgeoning",
            "2d6#Bludgeoning", "2d8#Bludgeoning", "2d10#Bludgeoning", "4d8#Bludgeoning", "6d8#Bludgeoning", "8d8#Bludgeoning", "12d8#Bludgeoning")]
        [TestCase(WeaponConstants.Flail,
            "1d4#Bludgeoning", "1d6#Bludgeoning", "1d8#Bludgeoning", "2d6#Bludgeoning", "3d6#Bludgeoning", "4d6#Bludgeoning", "6d6#Bludgeoning",
            "2d4#Bludgeoning", "2d6#Bludgeoning", "2d8#Bludgeoning", "4d6#Bludgeoning", "6d6#Bludgeoning", "8d6#Bludgeoning", "12d6#Bludgeoning")]
        [TestCase(WeaponConstants.Gauntlet,
            "1#Bludgeoning", "1d2#Bludgeoning", "1d3#Bludgeoning", "1d4#Bludgeoning", "1d6#Bludgeoning", "1d8#Bludgeoning", "2d6#Bludgeoning",
            "2#Bludgeoning", "2d2#Bludgeoning", "2d3#Bludgeoning", "2d4#Bludgeoning", "2d6#Bludgeoning", "2d8#Bludgeoning", "4d6#Bludgeoning")]
        [TestCase(WeaponConstants.SpikedGauntlet,
            "1d2#Piercing", "1d3#Piercing", "1d4#Piercing", "1d6#Piercing", "1d8#Piercing", "2d6#Piercing", "3d6#Piercing",
            "2d2#Piercing", "2d3#Piercing", "2d4#Piercing", "2d6#Piercing", "2d8#Piercing", "4d6#Piercing", "6d6#Piercing")]
        [TestCase(WeaponConstants.Glaive,
            "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8",
            "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.Greatclub,
            "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8",
            "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.Guisarme,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Halberd,
            "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8",
            "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.Spear,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.GnomeHookedHammer,
            "1d4,1d3", "1d6,1d4", "1d8,1d6", "2d6,1d8", "3d6,2d6", "4d6,3d6", "6d6,4d6",
            "1d4,1d3", "1d6,1d4", "1d8,1d6", "2d6,1d8", "3d6,2d6", "4d6,3d6", "6d6,4d6")]
        [TestCase(WeaponConstants.LightHammer,
            "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6",
            "2d2", "2d3", "2d4", "2d6", "2d8", "4d6", "6d6")]
        [TestCase(WeaponConstants.Handaxe,
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6",
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Kukri,
            "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6",
            "2d2", "2d3", "2d4", "2d6", "2d8", "4d6", "6d6")]
        [TestCase(WeaponConstants.Lance,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Longspear,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Morningstar,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Net,
            "0", "0", "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "0", "0", "0")]
        [TestCase(WeaponConstants.HeavyPick,
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6",
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.LightPick,
            "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6",
            "2d2", "2d3", "2d4", "2d6", "2d8", "4d6", "6d6")]
        [TestCase(WeaponConstants.Sai,
            "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6",
            "2d2", "2d3", "2d4", "2d6", "2d8", "4d6", "6d6")]
        [TestCase(WeaponConstants.Bolas,
            "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6",
            "2d2", "2d3", "2d4", "2d6", "2d8", "4d6", "6d6")]
        [TestCase(WeaponConstants.Ranseur,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Sap,
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6",
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Scythe,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Shuriken,
            "0", "1", "1d2", "1d3", "1d4", "1d6", "1d8",
            "0", "1", "1d2", "1d3", "1d4", "1d6", "1d8")]
        [TestCase(WeaponConstants.Sickle,
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6",
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.TwoBladedSword,
            "1d4,1d4", "1d6,1d6", "1d8,1d8", "2d6,2d6", "3d6,3d6", "4d6,4d6", "6d6,6d6",
            "1d4,1d4", "1d6,1d6", "1d8,1d8", "2d6,2d6", "3d6,3d6", "4d6,4d6", "6d6,6d6")]
        [TestCase(WeaponConstants.Trident,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.DwarvenUrgrosh,
            "1d4,1d3", "1d6,1d4", "1d8,1d6", "2d6,1d8", "3d6,2d6", "4d6,3d6", "6d6,4d6",
            "1d4,1d3", "1d6,1d4", "1d8,1d6", "2d6,1d8", "3d6,2d6", "4d6,3d6", "6d6,4d6")]
        [TestCase(WeaponConstants.Warhammer,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Whip,
            "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6",
            "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6")]
        [TestCase(WeaponConstants.ThrowingAxe,
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6",
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.HeavyCrossbow,
            "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8",
            "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.LightCrossbow,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Dart,
            "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6",
            "2d2", "2d3", "2d4", "2d6", "2d8", "4d6", "6d6")]
        [TestCase(WeaponConstants.Javelin,
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6",
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Shortbow,
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6",
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.CompositeShortbow,
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6",
            "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Sling,
            "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6",
            "2d2", "2d3", "2d4", "2d6", "2d8", "4d6", "6d6")]
        [TestCase(WeaponConstants.Longbow,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.CompositeLongbow,
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6",
            "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Arrow,
            "0", "0", "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "0", "0", "0")]
        [TestCase(WeaponConstants.CrossbowBolt,
            "0", "0", "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "0", "0", "0")]
        [TestCase(WeaponConstants.SlingBullet,
            "0", "0", "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "0", "0", "0")]
        [TestCase(WeaponConstants.PincerStaff,
            "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8",
            "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        public void WeaponDamages(string weapon, params string[] damages)
        {
            var sizes = TraitConstants.Sizes.All();
            Assert.That(damages.Length, Is.EqualTo(sizes.Count() * 2));
            Assert.That(damages, Is.All.Not.Empty);

            base.OrderedCollections(weapon, damages);
        }

        [Test]
        public void AllWeaponsAreInTable()
        {
            var weapons = WeaponConstants.GetAllWeapons(false, false);
            var keys = GetKeys();
            AssertCollection(keys, weapons);
        }

        [Test]
        public void AllDamagesAreValid()
        {
            foreach (var kvp in table)
            {
                foreach (var entry in kvp.Value)
                {
                    var damages = damageHelper.ParseEntries(entry);
                    foreach (var damageData in damages)
                    {
                        var damageEntry = damageHelper.BuildEntry(damageData);
                        var isValid = damageHelper.ValidateEntry(damageEntry);

                        Assert.That(isValid, Is.True, kvp.Key);
                    }
                }
            }
        }
    }
}
