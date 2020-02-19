using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Tables;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class WeaponDamagesTests : CollectionsTests
    {
        protected override string tableName
        {
            get { return TableNameConstants.Collections.Set.WeaponDamages; }
        }

        [TestCase(WeaponConstants.Dagger, "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6")]
        [TestCase(WeaponConstants.Greataxe, "1d8", "1d10", "1d12", "3d6", "4d6", "6d6", "8d6")]
        [TestCase(WeaponConstants.Greatsword, "1d8", "1d10", "2d6", "3d6", "4d6", "6d6", "8d6")]
        [TestCase(WeaponConstants.Kama, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Longsword, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.LightMace, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.HeavyMace, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Nunchaku, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Quarterstaff, "1d3/1d3", "1d4/1d4", "1d6/1d6", "1d8/1d8", "2d6/2d6", "3d6/3d6", "4d6/4d6")]
        [TestCase(WeaponConstants.Rapier, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Scimitar, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Shortspear, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Siangham, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.BastardSword, "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.ShortSword, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.DwarvenWaraxe, "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.OrcDoubleAxe, "1d4/1d4", "1d6/1d6", "1d8/1d8", "2d6/2d6", "3d6/3d6", "4d6/4d6", "6d6/6d6")]
        [TestCase(WeaponConstants.Battleaxe, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.SpikedChain, "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Club, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.HandCrossbow, "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6")]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow, "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.LightRepeatingCrossbow, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.PunchingDagger, "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6")]
        [TestCase(WeaponConstants.Falchion, "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.DireFlail, "1d4/1d4", "1d6/1d6", "1d8/1d8", "2d6/2d6", "3d6/3d6", "4d6/4d6", "6d6/6d6")]
        [TestCase(WeaponConstants.HeavyFlail, "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.Flail, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Gauntlet, "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6")]
        [TestCase(WeaponConstants.SpikedGauntlet, "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6")]
        [TestCase(WeaponConstants.Glaive, "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.Greatclub, "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.Guisarme, "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Halberd, "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.Spear, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.GnomeHookedHammer, "1d4/1d3", "1d6/1d4", "1d8/1d6", "2d6/1d8", "3d6/2d6", "4d6/3d6", "6d6/4d6")]
        [TestCase(WeaponConstants.LightHammer, "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6")]
        [TestCase(WeaponConstants.Handaxe, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Kukri, "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6")]
        [TestCase(WeaponConstants.Lance, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Longspear, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Morningstar, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Net, "0", "0", "0", "0", "0", "0", "0")]
        [TestCase(WeaponConstants.HeavyPick, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.LightPick, "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6")]
        [TestCase(WeaponConstants.Sai, "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6")]
        [TestCase(WeaponConstants.Bolas, "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6")]
        [TestCase(WeaponConstants.Ranseur, "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Sap, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Scythe, "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Shuriken, "0", "1", "1d2", "1d3", "1d4", "1d6", "1d8")]
        [TestCase(WeaponConstants.Sickle, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.TwoBladedSword, "1d4/1d4", "1d6/1d6", "1d8/1d8", "2d6/2d6", "3d6/3d6", "4d6/4d6", "6d6/6d6")]
        [TestCase(WeaponConstants.Trident, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.DwarvenUrgrosh, "1d4/1d3", "1d6/1d4", "1d8/1d6", "2d6/1d8", "3d6/2d6", "4d6/3d6", "6d6/4d6")]
        [TestCase(WeaponConstants.Warhammer, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Whip, "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6")]
        [TestCase(WeaponConstants.ThrowingAxe, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.HeavyCrossbow, "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        [TestCase(WeaponConstants.LightCrossbow, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Dart, "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6")]
        [TestCase(WeaponConstants.Javelin, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Shortbow, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.CompositeShortbow, "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6")]
        [TestCase(WeaponConstants.Sling, "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6")]
        [TestCase(WeaponConstants.Longbow, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.CompositeLongbow, "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6")]
        [TestCase(WeaponConstants.Arrow, "0", "0", "0", "0", "0", "0", "0")]
        [TestCase(WeaponConstants.CrossbowBolt, "0", "0", "0", "0", "0", "0", "0")]
        [TestCase(WeaponConstants.SlingBullet, "0", "0", "0", "0", "0", "0", "0")]
        [TestCase(WeaponConstants.PincerStaff, "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8")]
        public void WeaponDamages(string weapon, params string[] damages)
        {
            var sizes = TraitConstants.Sizes.All();
            Assert.That(damages.Length, Is.EqualTo(sizes.Count()));
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
    }
}
