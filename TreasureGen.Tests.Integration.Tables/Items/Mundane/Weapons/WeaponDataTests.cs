using Ninject;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Selectors.Collections;
using TreasureGen.Tables;

namespace TreasureGen.Tests.Integration.Tables.Items.Mundane.Weapons
{
    [TestFixture]
    public class WeaponDataTests : CollectionsTests
    {
        [Inject]
        internal IWeaponDataSelector WeaponDataSelector { get; set; }

        protected override string tableName
        {
            get { return TableNameConstants.Collections.Set.WeaponData; }
        }

        [TestCase(WeaponConstants.Gauntlet, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.Dagger, AttributeConstants.DamageTypes.Piercing + " or " + AttributeConstants.DamageTypes.Slashing, "19-20", "x2", "")]
        [TestCase(WeaponConstants.PunchingDagger, AttributeConstants.DamageTypes.Piercing, "20", "x3", "")]
        [TestCase(WeaponConstants.SpikedGauntlet, AttributeConstants.DamageTypes.Piercing, "20", "x2", "")]
        [TestCase(WeaponConstants.LightMace, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.Sickle, AttributeConstants.DamageTypes.Slashing, "20", "x2", "")]
        [TestCase(WeaponConstants.Club, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.HeavyMace, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.Morningstar, AttributeConstants.DamageTypes.Bludgeoning + " and " + AttributeConstants.DamageTypes.Piercing, "20", "x2", "")]
        [TestCase(WeaponConstants.Shortspear, AttributeConstants.DamageTypes.Piercing, "20", "x2", "")]
        [TestCase(WeaponConstants.Longspear, AttributeConstants.DamageTypes.Piercing, "20", "x3", "")]
        [TestCase(WeaponConstants.Quarterstaff, AttributeConstants.DamageTypes.Bludgeoning + "/" + AttributeConstants.DamageTypes.Bludgeoning, "20/20", "x2/x2", "")]
        [TestCase(WeaponConstants.Spear, AttributeConstants.DamageTypes.Piercing, "20", "x3", "")]
        [TestCase(WeaponConstants.HeavyCrossbow, AttributeConstants.DamageTypes.Piercing, "19-20", "x2", WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.LightCrossbow, AttributeConstants.DamageTypes.Piercing, "19-20", "x2", WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.Dart, AttributeConstants.DamageTypes.Piercing, "20", "x2", "")]
        [TestCase(WeaponConstants.Javelin, AttributeConstants.DamageTypes.Piercing, "20", "x2", "")]
        [TestCase(WeaponConstants.Sling, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", WeaponConstants.SlingBullet)]
        [TestCase(WeaponConstants.ThrowingAxe, AttributeConstants.DamageTypes.Slashing, "20", "x2", "")]
        [TestCase(WeaponConstants.LightHammer, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.Handaxe, AttributeConstants.DamageTypes.Slashing, "20", "x3", "")]
        [TestCase(WeaponConstants.Kukri, AttributeConstants.DamageTypes.Slashing, "18-20", "x2", "")]
        [TestCase(WeaponConstants.LightPick, AttributeConstants.DamageTypes.Piercing, "20", "x4", "")]
        [TestCase(WeaponConstants.Sap, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.ShortSword, AttributeConstants.DamageTypes.Piercing, "19-20", "x2", "")]
        [TestCase(WeaponConstants.Battleaxe, AttributeConstants.DamageTypes.Slashing, "20", "x3", "")]
        [TestCase(WeaponConstants.Flail, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.Longsword, AttributeConstants.DamageTypes.Slashing, "19-20", "x2", "")]
        [TestCase(WeaponConstants.HeavyPick, AttributeConstants.DamageTypes.Piercing, "20", "x4", "")]
        [TestCase(WeaponConstants.Rapier, AttributeConstants.DamageTypes.Piercing, "18-20", "x2", "")]
        [TestCase(WeaponConstants.Scimitar, AttributeConstants.DamageTypes.Slashing, "18-20", "x2", "")]
        [TestCase(WeaponConstants.Trident, AttributeConstants.DamageTypes.Piercing, "20", "x2", "")]
        [TestCase(WeaponConstants.Warhammer, AttributeConstants.DamageTypes.Bludgeoning, "20", "x3", "")]
        [TestCase(WeaponConstants.Falchion, AttributeConstants.DamageTypes.Slashing, "18-20", "x2", "")]
        [TestCase(WeaponConstants.Glaive, AttributeConstants.DamageTypes.Slashing, "20", "x3", "")]
        [TestCase(WeaponConstants.Greataxe, AttributeConstants.DamageTypes.Slashing, "20", "x3", "")]
        [TestCase(WeaponConstants.Greatclub, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.HeavyFlail, AttributeConstants.DamageTypes.Bludgeoning, "19-20", "x2", "")]
        [TestCase(WeaponConstants.Greatsword, AttributeConstants.DamageTypes.Slashing, "19-20", "x2", "")]
        [TestCase(WeaponConstants.Guisarme, AttributeConstants.DamageTypes.Slashing, "20", "x3", "")]
        [TestCase(WeaponConstants.Halberd, AttributeConstants.DamageTypes.Piercing + " or " + AttributeConstants.DamageTypes.Slashing, "20", "x3", "")]
        [TestCase(WeaponConstants.Lance, AttributeConstants.DamageTypes.Piercing, "20", "x3", "")]
        [TestCase(WeaponConstants.Ranseur, AttributeConstants.DamageTypes.Piercing, "20", "x3", "")]
        [TestCase(WeaponConstants.Scythe, AttributeConstants.DamageTypes.Piercing + " or " + AttributeConstants.DamageTypes.Slashing, "20", "x4", "")]
        [TestCase(WeaponConstants.Longbow, AttributeConstants.DamageTypes.Piercing, "20", "x3", WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeLongbow, AttributeConstants.DamageTypes.Piercing, "20", "x3", WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.Shortbow, AttributeConstants.DamageTypes.Piercing, "20", "x3", WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.CompositeShortbow, AttributeConstants.DamageTypes.Piercing, "20", "x3", WeaponConstants.Arrow)]
        [TestCase(WeaponConstants.Kama, AttributeConstants.DamageTypes.Slashing, "20", "x2", "")]
        [TestCase(WeaponConstants.Nunchaku, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.Sai, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.Siangham, AttributeConstants.DamageTypes.Piercing, "20", "x2", "")]
        [TestCase(WeaponConstants.BastardSword, AttributeConstants.DamageTypes.Slashing, "19-20", "x2", "")]
        [TestCase(WeaponConstants.DwarvenWaraxe, AttributeConstants.DamageTypes.Slashing, "20", "x3", "")]
        [TestCase(WeaponConstants.Whip, AttributeConstants.DamageTypes.Slashing, "20", "x2", "")]
        [TestCase(WeaponConstants.OrcDoubleAxe, AttributeConstants.DamageTypes.Slashing + "/" + AttributeConstants.DamageTypes.Slashing, "20/20", "x3/x3", "")]
        [TestCase(WeaponConstants.SpikedChain, AttributeConstants.DamageTypes.Piercing, "20", "x2", "")]
        [TestCase(WeaponConstants.DireFlail, AttributeConstants.DamageTypes.Bludgeoning + "/" + AttributeConstants.DamageTypes.Bludgeoning, "20/20", "x2/x2", "")]
        [TestCase(WeaponConstants.GnomeHookedHammer, AttributeConstants.DamageTypes.Bludgeoning + "/" + AttributeConstants.DamageTypes.Piercing, "20/20", "x3/x4", "")]
        [TestCase(WeaponConstants.TwoBladedSword, AttributeConstants.DamageTypes.Slashing + "/" + AttributeConstants.DamageTypes.Slashing, "19-20/19-20", "x2/x2", "")]
        [TestCase(WeaponConstants.DwarvenUrgrosh, AttributeConstants.DamageTypes.Piercing + " or " + AttributeConstants.DamageTypes.Slashing + "/" + AttributeConstants.DamageTypes.Piercing + " or " + AttributeConstants.DamageTypes.Slashing, "20/20", "x3/x3", "")]
        [TestCase(WeaponConstants.Bolas, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.HandCrossbow, AttributeConstants.DamageTypes.Piercing, "19-20", "x2", WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow, AttributeConstants.DamageTypes.Piercing, "19-20", "x2", WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.LightRepeatingCrossbow, AttributeConstants.DamageTypes.Piercing, "19-20", "x2", WeaponConstants.CrossbowBolt)]
        [TestCase(WeaponConstants.Net, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.Shuriken, AttributeConstants.DamageTypes.Piercing, "20", "x2", "")]
        [TestCase(WeaponConstants.Arrow, AttributeConstants.DamageTypes.Piercing, "20", "x3", "")]
        [TestCase(WeaponConstants.CrossbowBolt, AttributeConstants.DamageTypes.Piercing, "19-20", "x2", "")]
        [TestCase(WeaponConstants.SlingBullet, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        [TestCase(WeaponConstants.PincerStaff, AttributeConstants.DamageTypes.Bludgeoning, "20", "x2", "")]
        public void WeaponData(string weapon, string damageType, string threatRange, string criticalMultiplier, string ammunition)
        {
            var collection = new string[4];
            collection[DataIndexConstants.Weapon.CriticalMultiplier] = criticalMultiplier;
            collection[DataIndexConstants.Weapon.DamageType] = damageType;
            collection[DataIndexConstants.Weapon.ThreatRange] = threatRange;
            collection[DataIndexConstants.Weapon.Ammunition] = ammunition;

            base.OrderedCollections(weapon, collection);
        }

        [Test]
        public void AllWeaponsAreInTable()
        {
            var weapons = WeaponConstants.GetBaseNames();
            var keys = GetKeys();
            AssertCollection(keys, weapons);
        }

        [Test]
        public void BludgeoningWeaponsMatchConstants()
        {
            var weapons = WeaponConstants.GetBaseNames();
            var bludgeoning = WeaponConstants.GetAllBludgeoning();

            foreach (var weapon in weapons)
            {
                var data = WeaponDataSelector.Select(weapon);

                var isBludgeoning = bludgeoning.Contains(weapon);
                var hasBludgeoning = data.DamageType.Contains(AttributeConstants.DamageTypes.Bludgeoning);

                Assert.That(hasBludgeoning, Is.EqualTo(isBludgeoning), weapon);
            }
        }

        [Test]
        public void PiercingWeaponsMatchConstants()
        {
            var weapons = WeaponConstants.GetBaseNames();
            var piercing = WeaponConstants.GetAllPiercing();

            foreach (var weapon in weapons)
            {
                var data = WeaponDataSelector.Select(weapon);

                var isPiercing = piercing.Contains(weapon);
                var hasPiercing = data.DamageType.Contains(AttributeConstants.DamageTypes.Piercing);

                Assert.That(hasPiercing, Is.EqualTo(isPiercing), weapon);
            }
        }

        [Test]
        public void SlashingWeaponsMatchConstants()
        {
            var weapons = WeaponConstants.GetBaseNames();
            var slashing = WeaponConstants.GetAllSlashing();

            foreach (var weapon in weapons)
            {
                var data = WeaponDataSelector.Select(weapon);

                var isSlashing = slashing.Contains(weapon);
                var hasSlashing = data.DamageType.Contains(AttributeConstants.DamageTypes.Slashing);

                Assert.That(hasSlashing, Is.EqualTo(isSlashing), weapon);
            }
        }
    }
}