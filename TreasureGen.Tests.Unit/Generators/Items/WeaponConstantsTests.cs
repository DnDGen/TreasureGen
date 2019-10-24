using NUnit.Framework;
using System.Linq;
using TreasureGen.Items;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class WeaponConstantsTests
    {
        [TestCase(WeaponConstants.Arrow, "Arrow")]
        [TestCase(WeaponConstants.AssassinsDagger, "Assassin's dagger")]
        [TestCase(WeaponConstants.BastardSword, "Bastard sword")]
        [TestCase(WeaponConstants.Battleaxe, "Battleaxe")]
        [TestCase(WeaponConstants.BerserkingSword, "Berserking sword")]
        [TestCase(WeaponConstants.Bolas, "Bolas")]
        [TestCase(WeaponConstants.Club, "Club")]
        [TestCase(WeaponConstants.CompositeShortbow, "Composite shortbow")]
        [TestCase(WeaponConstants.CompositePlus0Shortbow, "Composite (+0) shortbow")]
        [TestCase(WeaponConstants.CompositePlus1Shortbow, "Composite (+1) shortbow")]
        [TestCase(WeaponConstants.CompositePlus2Shortbow, "Composite (+2) shortbow")]
        [TestCase(WeaponConstants.CompositeLongbow, "Composite longbow")]
        [TestCase(WeaponConstants.CompositePlus0Longbow, "Composite (+0) longbow")]
        [TestCase(WeaponConstants.CompositePlus1Longbow, "Composite (+1) longbow")]
        [TestCase(WeaponConstants.CompositePlus2Longbow, "Composite (+2) longbow")]
        [TestCase(WeaponConstants.CompositePlus3Longbow, "Composite (+3) longbow")]
        [TestCase(WeaponConstants.CompositePlus4Longbow, "Composite (+4) longbow")]
        [TestCase(WeaponConstants.CrossbowBolt, "Crossbow bolt")]
        [TestCase(WeaponConstants.CursedBackbiterSpear, "Cursed backbiter spear")]
        [TestCase(WeaponConstants.CursedMinus2Sword, "Cursed -2 sword")]
        [TestCase(WeaponConstants.Dagger, "Dagger")]
        [TestCase(WeaponConstants.DaggerOfVenom, "Dagger of venom")]
        [TestCase(WeaponConstants.Dart, "Dart")]
        [TestCase(WeaponConstants.DireFlail, "Dire flail")]
        [TestCase(WeaponConstants.DwarvenThrower, "Dwarven thrower")]
        [TestCase(WeaponConstants.DwarvenUrgrosh, "Dwarven urgrosh")]
        [TestCase(WeaponConstants.DwarvenWaraxe, "Dwarven waraxe")]
        [TestCase(WeaponConstants.Falchion, "Falchion")]
        [TestCase(WeaponConstants.Flail, "Flail")]
        [TestCase(WeaponConstants.FlameTongue, "Flame tongue")]
        [TestCase(WeaponConstants.FrostBrand, "Frost brand")]
        [TestCase(WeaponConstants.Gauntlet, "Gauntlet")]
        [TestCase(WeaponConstants.Glaive, "Glaive")]
        [TestCase(WeaponConstants.GnomeHookedHammer, "Gnome hooked hammer")]
        [TestCase(WeaponConstants.Greataxe, "Greataxe")]
        [TestCase(WeaponConstants.Greatclub, "Greatclub")]
        [TestCase(WeaponConstants.GreaterSlayingArrow, "Greater slaying arrow")]
        [TestCase(WeaponConstants.Greatsword, "Greatsword")]
        [TestCase(WeaponConstants.Guisarme, "Guisarme")]
        [TestCase(WeaponConstants.Halberd, "Halberd")]
        [TestCase(WeaponConstants.Handaxe, "Handaxe")]
        [TestCase(WeaponConstants.HandCrossbow, "Hand crossbow")]
        [TestCase(WeaponConstants.HeavyCrossbow, "Heavy crossbow")]
        [TestCase(WeaponConstants.HeavyFlail, "Heavy flail")]
        [TestCase(WeaponConstants.HeavyMace, "Heavy mace")]
        [TestCase(WeaponConstants.HeavyPick, "Heavy pick")]
        [TestCase(WeaponConstants.HeavyRepeatingCrossbow, "Heavy repeating crossbow")]
        [TestCase(WeaponConstants.HolyAvenger, "Holy avenger")]
        [TestCase(WeaponConstants.Javelin, "Javelin")]
        [TestCase(WeaponConstants.JavelinOfLightning, "Javelin of lightning")]
        [TestCase(WeaponConstants.Kama, "Kama")]
        [TestCase(WeaponConstants.Kukri, "Kukri")]
        [TestCase(WeaponConstants.Lance, "Lance")]
        [TestCase(WeaponConstants.LightCrossbow, "Light crossbow")]
        [TestCase(WeaponConstants.LightHammer, "Light hammer")]
        [TestCase(WeaponConstants.LightMace, "Light mace")]
        [TestCase(WeaponConstants.LightPick, "Light pick")]
        [TestCase(WeaponConstants.LightRepeatingCrossbow, "Light repeating crossbow")]
        [TestCase(WeaponConstants.LifeDrinker, "Life-drinker")]
        [TestCase(WeaponConstants.Longbow, "Longbow")]
        [TestCase(WeaponConstants.Longspear, "Longspear")]
        [TestCase(WeaponConstants.Longsword, "Longsword")]
        [TestCase(WeaponConstants.LuckBlade, "Luck blade")]
        [TestCase(WeaponConstants.LuckBlade0, "Luck blade (0 wishes)")]
        [TestCase(WeaponConstants.LuckBlade1, "Luck blade (1 wish)")]
        [TestCase(WeaponConstants.LuckBlade2, "Luck blade (2 wishes)")]
        [TestCase(WeaponConstants.LuckBlade3, "Luck blade (3 wishes)")]
        [TestCase(WeaponConstants.MaceOfBlood, "Mace of blood")]
        [TestCase(WeaponConstants.MaceOfSmiting, "Mace of smiting")]
        [TestCase(WeaponConstants.MaceOfTerror, "Mace of terror")]
        [TestCase(WeaponConstants.Morningstar, "Morningstar")]
        [TestCase(WeaponConstants.Net, "Net")]
        [TestCase(WeaponConstants.NetOfSnaring, "Net of snaring")]
        [TestCase(WeaponConstants.NineLivesStealer, "Nine lives stealer")]
        [TestCase(WeaponConstants.Nunchaku, "Nunchaku")]
        [TestCase(WeaponConstants.Oathbow, "Oathbow")]
        [TestCase(WeaponConstants.OrcDoubleAxe, "Orc double axe")]
        [TestCase(WeaponConstants.PunchingDagger, "Punching dagger")]
        [TestCase(WeaponConstants.Quarterstaff, "Quarterstaff")]
        [TestCase(WeaponConstants.Ranseur, "Ranseur")]
        [TestCase(WeaponConstants.Rapier, "Rapier")]
        [TestCase(WeaponConstants.RapierOfPuncturing, "Rapier of puncturing")]
        [TestCase(WeaponConstants.Sai, "Sai")]
        [TestCase(WeaponConstants.Sap, "Sap")]
        [TestCase(WeaponConstants.Scimitar, "Scimitar")]
        [TestCase(WeaponConstants.ScreamingBolt, "Screaming bolt")]
        [TestCase(WeaponConstants.Scythe, "Scythe")]
        [TestCase(WeaponConstants.Shatterspike, "Shatterspike")]
        [TestCase(WeaponConstants.ShiftersSorrow, "Shifter's sorrow")]
        [TestCase(WeaponConstants.Shortbow, "Shortbow")]
        [TestCase(WeaponConstants.Shortspear, "Shortspear")]
        [TestCase(WeaponConstants.ShortSword, "Short sword")]
        [TestCase(WeaponConstants.Shuriken, "Shuriken")]
        [TestCase(WeaponConstants.Siangham, "Siangham")]
        [TestCase(WeaponConstants.Sickle, "Sickle")]
        [TestCase(WeaponConstants.SilverDagger, "Silver dagger")]
        [TestCase(WeaponConstants.SlayingArrow, "Slaying arrow")]
        [TestCase(WeaponConstants.SleepArrow, "Sleep arrow")]
        [TestCase(WeaponConstants.Sling, "Sling")]
        [TestCase(WeaponConstants.SlingBullet, "Sling bullet")]
        [TestCase(WeaponConstants.Spear, "Spear")]
        [TestCase(WeaponConstants.SpikedChain, "Spiked chain")]
        [TestCase(WeaponConstants.SpikedGauntlet, "Spiked gauntlet")]
        [TestCase(WeaponConstants.SunBlade, "Sun blade")]
        [TestCase(WeaponConstants.SwordOfLifeStealing, "Sword of life stealing")]
        [TestCase(WeaponConstants.SwordOfSubtlety, "Sword of subtlety")]
        [TestCase(WeaponConstants.SwordOfThePlanes, "Sword of the planes")]
        [TestCase(WeaponConstants.SylvanScimitar, "Sylvan scimitar")]
        [TestCase(WeaponConstants.ThrowingAxe, "Throwing axe")]
        [TestCase(WeaponConstants.Trident, "Trident")]
        [TestCase(WeaponConstants.TridentOfFishCommand, "Trident of fish command")]
        [TestCase(WeaponConstants.TridentOfWarning, "Trident of warning")]
        [TestCase(WeaponConstants.TwoBladedSword, "Two-bladed sword")]
        [TestCase(WeaponConstants.Warhammer, "Warhammer")]
        [TestCase(WeaponConstants.Whip, "Whip")]
        [TestCase(WeaponConstants.PincerStaff, "Pincer staff")]
        public void WeaponConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllWeapons()
        {
            var weapons = WeaponConstants.GetAllWeapons();

            Assert.That(weapons, Contains.Item(WeaponConstants.Sai));
            Assert.That(weapons, Contains.Item(WeaponConstants.Bolas));
            Assert.That(weapons, Contains.Item(WeaponConstants.Arrow));
            Assert.That(weapons, Contains.Item(WeaponConstants.AssassinsDagger));
            Assert.That(weapons, Contains.Item(WeaponConstants.BastardSword));
            Assert.That(weapons, Contains.Item(WeaponConstants.Battleaxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Club));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositeLongbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositeShortbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CrossbowBolt));
            Assert.That(weapons, Contains.Item(WeaponConstants.Dagger));
            Assert.That(weapons, Contains.Item(WeaponConstants.DaggerOfVenom));
            Assert.That(weapons, Contains.Item(WeaponConstants.Dart));
            Assert.That(weapons, Contains.Item(WeaponConstants.DireFlail));
            Assert.That(weapons, Contains.Item(WeaponConstants.DwarvenThrower));
            Assert.That(weapons, Contains.Item(WeaponConstants.DwarvenUrgrosh));
            Assert.That(weapons, Contains.Item(WeaponConstants.DwarvenWaraxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Falchion));
            Assert.That(weapons, Contains.Item(WeaponConstants.FlameTongue));
            Assert.That(weapons, Contains.Item(WeaponConstants.FrostBrand));
            Assert.That(weapons, Contains.Item(WeaponConstants.Gauntlet));
            Assert.That(weapons, Contains.Item(WeaponConstants.Glaive));
            Assert.That(weapons, Contains.Item(WeaponConstants.GnomeHookedHammer));
            Assert.That(weapons, Contains.Item(WeaponConstants.Greataxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Greatclub));
            Assert.That(weapons, Contains.Item(WeaponConstants.GreaterSlayingArrow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Greatsword));
            Assert.That(weapons, Contains.Item(WeaponConstants.Guisarme));
            Assert.That(weapons, Contains.Item(WeaponConstants.Halberd));
            Assert.That(weapons, Contains.Item(WeaponConstants.Spear));
            Assert.That(weapons, Contains.Item(WeaponConstants.Handaxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.HandCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyFlail));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyMace));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyPick));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyRepeatingCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.HolyAvenger));
            Assert.That(weapons, Contains.Item(WeaponConstants.Javelin));
            Assert.That(weapons, Contains.Item(WeaponConstants.JavelinOfLightning));
            Assert.That(weapons, Contains.Item(WeaponConstants.Kama));
            Assert.That(weapons, Contains.Item(WeaponConstants.Kukri));
            Assert.That(weapons, Contains.Item(WeaponConstants.Lance));
            Assert.That(weapons, Contains.Item(WeaponConstants.LifeDrinker));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Flail));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightHammer));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightMace));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightPick));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightRepeatingCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Longbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Longspear));
            Assert.That(weapons, Contains.Item(WeaponConstants.Longsword));
            Assert.That(weapons, Contains.Item(WeaponConstants.LuckBlade));
            Assert.That(weapons, Contains.Item(WeaponConstants.MaceOfSmiting));
            Assert.That(weapons, Contains.Item(WeaponConstants.MaceOfTerror));
            Assert.That(weapons, Contains.Item(WeaponConstants.Morningstar));
            Assert.That(weapons, Contains.Item(WeaponConstants.Net));
            Assert.That(weapons, Contains.Item(WeaponConstants.NineLivesStealer));
            Assert.That(weapons, Contains.Item(WeaponConstants.Nunchaku));
            Assert.That(weapons, Contains.Item(WeaponConstants.Oathbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.OrcDoubleAxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.PunchingDagger));
            Assert.That(weapons, Contains.Item(WeaponConstants.Quarterstaff));
            Assert.That(weapons, Contains.Item(WeaponConstants.Ranseur));
            Assert.That(weapons, Contains.Item(WeaponConstants.Rapier));
            Assert.That(weapons, Contains.Item(WeaponConstants.RapierOfPuncturing));
            Assert.That(weapons, Contains.Item(WeaponConstants.Sap));
            Assert.That(weapons, Contains.Item(WeaponConstants.Scimitar));
            Assert.That(weapons, Contains.Item(WeaponConstants.ScreamingBolt));
            Assert.That(weapons, Contains.Item(WeaponConstants.Scythe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Shatterspike));
            Assert.That(weapons, Contains.Item(WeaponConstants.ShiftersSorrow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Shortbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Shortspear));
            Assert.That(weapons, Contains.Item(WeaponConstants.ShortSword));
            Assert.That(weapons, Contains.Item(WeaponConstants.Shuriken));
            Assert.That(weapons, Contains.Item(WeaponConstants.Siangham));
            Assert.That(weapons, Contains.Item(WeaponConstants.Sickle));
            Assert.That(weapons, Contains.Item(WeaponConstants.SlayingArrow));
            Assert.That(weapons, Contains.Item(WeaponConstants.SleepArrow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Sling));
            Assert.That(weapons, Contains.Item(WeaponConstants.SlingBullet));
            Assert.That(weapons, Contains.Item(WeaponConstants.SpikedChain));
            Assert.That(weapons, Contains.Item(WeaponConstants.SpikedGauntlet));
            Assert.That(weapons, Contains.Item(WeaponConstants.SunBlade));
            Assert.That(weapons, Contains.Item(WeaponConstants.SwordOfLifeStealing));
            Assert.That(weapons, Contains.Item(WeaponConstants.SwordOfSubtlety));
            Assert.That(weapons, Contains.Item(WeaponConstants.SwordOfThePlanes));
            Assert.That(weapons, Contains.Item(WeaponConstants.SylvanScimitar));
            Assert.That(weapons, Contains.Item(WeaponConstants.ThrowingAxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Trident));
            Assert.That(weapons, Contains.Item(WeaponConstants.TridentOfFishCommand));
            Assert.That(weapons, Contains.Item(WeaponConstants.TridentOfWarning));
            Assert.That(weapons, Contains.Item(WeaponConstants.TwoBladedSword));
            Assert.That(weapons, Contains.Item(WeaponConstants.Warhammer));
            Assert.That(weapons, Contains.Item(WeaponConstants.Whip));
            Assert.That(weapons, Contains.Item(WeaponConstants.BerserkingSword));
            Assert.That(weapons, Contains.Item(WeaponConstants.CursedBackbiterSpear));
            Assert.That(weapons, Contains.Item(WeaponConstants.CursedMinus2Sword));
            Assert.That(weapons, Contains.Item(WeaponConstants.MaceOfBlood));
            Assert.That(weapons, Contains.Item(WeaponConstants.NetOfSnaring));
            Assert.That(weapons, Contains.Item(WeaponConstants.PincerStaff));

            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.SilverDagger));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.LuckBlade0));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.LuckBlade1));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.LuckBlade2));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.LuckBlade3));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.CompositePlus0Longbow));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.CompositePlus0Shortbow));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.CompositePlus1Longbow));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.CompositePlus1Shortbow));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.CompositePlus2Longbow));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.CompositePlus2Shortbow));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.CompositePlus3Longbow));
            Assert.That(weapons, Is.All.Not.EqualTo(WeaponConstants.CompositePlus4Longbow));

            Assert.That(weapons.Count(), Is.EqualTo(103));
        }

        [Test]
        public void GetBaseNames()
        {
            var weapons = WeaponConstants.GetBaseNames();

            Assert.That(weapons, Contains.Item(WeaponConstants.Gauntlet));
            Assert.That(weapons, Contains.Item(WeaponConstants.Dagger));
            Assert.That(weapons, Contains.Item(WeaponConstants.PunchingDagger));
            Assert.That(weapons, Contains.Item(WeaponConstants.SpikedGauntlet));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightMace));
            Assert.That(weapons, Contains.Item(WeaponConstants.Sickle));
            Assert.That(weapons, Contains.Item(WeaponConstants.Club));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyMace));
            Assert.That(weapons, Contains.Item(WeaponConstants.Morningstar));
            Assert.That(weapons, Contains.Item(WeaponConstants.Shortspear));
            Assert.That(weapons, Contains.Item(WeaponConstants.Longspear));
            Assert.That(weapons, Contains.Item(WeaponConstants.Spear));
            Assert.That(weapons, Contains.Item(WeaponConstants.Quarterstaff));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CrossbowBolt));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Dart));
            Assert.That(weapons, Contains.Item(WeaponConstants.Javelin));
            Assert.That(weapons, Contains.Item(WeaponConstants.Sling));
            Assert.That(weapons, Contains.Item(WeaponConstants.SlingBullet));
            Assert.That(weapons, Contains.Item(WeaponConstants.ThrowingAxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightHammer));
            Assert.That(weapons, Contains.Item(WeaponConstants.Handaxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Kukri));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightPick));
            Assert.That(weapons, Contains.Item(WeaponConstants.Sap));
            Assert.That(weapons, Contains.Item(WeaponConstants.ShortSword));
            Assert.That(weapons, Contains.Item(WeaponConstants.Battleaxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Flail));
            Assert.That(weapons, Contains.Item(WeaponConstants.Longsword));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyPick));
            Assert.That(weapons, Contains.Item(WeaponConstants.Rapier));
            Assert.That(weapons, Contains.Item(WeaponConstants.Scimitar));
            Assert.That(weapons, Contains.Item(WeaponConstants.Trident));
            Assert.That(weapons, Contains.Item(WeaponConstants.Warhammer));
            Assert.That(weapons, Contains.Item(WeaponConstants.Falchion));
            Assert.That(weapons, Contains.Item(WeaponConstants.Glaive));
            Assert.That(weapons, Contains.Item(WeaponConstants.Greataxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Greatclub));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyFlail));
            Assert.That(weapons, Contains.Item(WeaponConstants.Greatsword));
            Assert.That(weapons, Contains.Item(WeaponConstants.Guisarme));
            Assert.That(weapons, Contains.Item(WeaponConstants.Halberd));
            Assert.That(weapons, Contains.Item(WeaponConstants.Lance));
            Assert.That(weapons, Contains.Item(WeaponConstants.Ranseur));
            Assert.That(weapons, Contains.Item(WeaponConstants.Scythe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Longbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Arrow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositeLongbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Shortbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositeShortbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Kama));
            Assert.That(weapons, Contains.Item(WeaponConstants.Nunchaku));
            Assert.That(weapons, Contains.Item(WeaponConstants.Sai));
            Assert.That(weapons, Contains.Item(WeaponConstants.Siangham));
            Assert.That(weapons, Contains.Item(WeaponConstants.BastardSword));
            Assert.That(weapons, Contains.Item(WeaponConstants.DwarvenWaraxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Whip));
            Assert.That(weapons, Contains.Item(WeaponConstants.OrcDoubleAxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.SpikedChain));
            Assert.That(weapons, Contains.Item(WeaponConstants.DireFlail));
            Assert.That(weapons, Contains.Item(WeaponConstants.GnomeHookedHammer));
            Assert.That(weapons, Contains.Item(WeaponConstants.TwoBladedSword));
            Assert.That(weapons, Contains.Item(WeaponConstants.DwarvenUrgrosh));
            Assert.That(weapons, Contains.Item(WeaponConstants.Bolas));
            Assert.That(weapons, Contains.Item(WeaponConstants.HandCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyRepeatingCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightRepeatingCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Net));
            Assert.That(weapons, Contains.Item(WeaponConstants.Shuriken));
            Assert.That(weapons, Contains.Item(WeaponConstants.PincerStaff));

            Assert.That(weapons.Count(), Is.EqualTo(71));
        }

        [Test]
        public void MeleeWeapons()
        {
            var melee = WeaponConstants.GetAllMelee();

            Assert.That(melee, Contains.Item(WeaponConstants.Gauntlet));
            Assert.That(melee, Contains.Item(WeaponConstants.Dagger));
            Assert.That(melee, Contains.Item(WeaponConstants.PunchingDagger));
            Assert.That(melee, Contains.Item(WeaponConstants.SpikedGauntlet));
            Assert.That(melee, Contains.Item(WeaponConstants.LightMace));
            Assert.That(melee, Contains.Item(WeaponConstants.Sickle));
            Assert.That(melee, Contains.Item(WeaponConstants.Club));
            Assert.That(melee, Contains.Item(WeaponConstants.HeavyMace));
            Assert.That(melee, Contains.Item(WeaponConstants.Morningstar));
            Assert.That(melee, Contains.Item(WeaponConstants.Shortspear));
            Assert.That(melee, Contains.Item(WeaponConstants.Longspear));
            Assert.That(melee, Contains.Item(WeaponConstants.Spear));
            Assert.That(melee, Contains.Item(WeaponConstants.Quarterstaff));
            Assert.That(melee, Contains.Item(WeaponConstants.ThrowingAxe));
            Assert.That(melee, Contains.Item(WeaponConstants.LightHammer));
            Assert.That(melee, Contains.Item(WeaponConstants.Handaxe));
            Assert.That(melee, Contains.Item(WeaponConstants.Kukri));
            Assert.That(melee, Contains.Item(WeaponConstants.LightPick));
            Assert.That(melee, Contains.Item(WeaponConstants.Sap));
            Assert.That(melee, Contains.Item(WeaponConstants.ShortSword));
            Assert.That(melee, Contains.Item(WeaponConstants.Battleaxe));
            Assert.That(melee, Contains.Item(WeaponConstants.Flail));
            Assert.That(melee, Contains.Item(WeaponConstants.Longsword));
            Assert.That(melee, Contains.Item(WeaponConstants.HeavyPick));
            Assert.That(melee, Contains.Item(WeaponConstants.Rapier));
            Assert.That(melee, Contains.Item(WeaponConstants.Scimitar));
            Assert.That(melee, Contains.Item(WeaponConstants.Trident));
            Assert.That(melee, Contains.Item(WeaponConstants.Warhammer));
            Assert.That(melee, Contains.Item(WeaponConstants.Falchion));
            Assert.That(melee, Contains.Item(WeaponConstants.Glaive));
            Assert.That(melee, Contains.Item(WeaponConstants.Greataxe));
            Assert.That(melee, Contains.Item(WeaponConstants.Greatclub));
            Assert.That(melee, Contains.Item(WeaponConstants.HeavyFlail));
            Assert.That(melee, Contains.Item(WeaponConstants.Greatsword));
            Assert.That(melee, Contains.Item(WeaponConstants.Guisarme));
            Assert.That(melee, Contains.Item(WeaponConstants.Halberd));
            Assert.That(melee, Contains.Item(WeaponConstants.Lance));
            Assert.That(melee, Contains.Item(WeaponConstants.Ranseur));
            Assert.That(melee, Contains.Item(WeaponConstants.Scythe));
            Assert.That(melee, Contains.Item(WeaponConstants.Kama));
            Assert.That(melee, Contains.Item(WeaponConstants.Nunchaku));
            Assert.That(melee, Contains.Item(WeaponConstants.Sai));
            Assert.That(melee, Contains.Item(WeaponConstants.Siangham));
            Assert.That(melee, Contains.Item(WeaponConstants.BastardSword));
            Assert.That(melee, Contains.Item(WeaponConstants.DwarvenWaraxe));
            Assert.That(melee, Contains.Item(WeaponConstants.Whip));
            Assert.That(melee, Contains.Item(WeaponConstants.OrcDoubleAxe));
            Assert.That(melee, Contains.Item(WeaponConstants.SpikedChain));
            Assert.That(melee, Contains.Item(WeaponConstants.DireFlail));
            Assert.That(melee, Contains.Item(WeaponConstants.GnomeHookedHammer));
            Assert.That(melee, Contains.Item(WeaponConstants.TwoBladedSword));
            Assert.That(melee, Contains.Item(WeaponConstants.DwarvenUrgrosh));
            Assert.That(melee, Contains.Item(WeaponConstants.PincerStaff));

            Assert.That(melee.Count(), Is.EqualTo(53));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(melee, Is.SubsetOf(weapons));
        }

        [Test]
        public void RangedWeapons()
        {
            var ranged = WeaponConstants.GetAllRanged();

            Assert.That(ranged, Contains.Item(WeaponConstants.Dagger));
            Assert.That(ranged, Contains.Item(WeaponConstants.Club));
            Assert.That(ranged, Contains.Item(WeaponConstants.Shortspear));
            Assert.That(ranged, Contains.Item(WeaponConstants.Spear));
            Assert.That(ranged, Contains.Item(WeaponConstants.HeavyCrossbow));
            Assert.That(ranged, Contains.Item(WeaponConstants.CrossbowBolt));
            Assert.That(ranged, Contains.Item(WeaponConstants.LightCrossbow));
            Assert.That(ranged, Contains.Item(WeaponConstants.Dart));
            Assert.That(ranged, Contains.Item(WeaponConstants.Javelin));
            Assert.That(ranged, Contains.Item(WeaponConstants.Sling));
            Assert.That(ranged, Contains.Item(WeaponConstants.SlingBullet));
            Assert.That(ranged, Contains.Item(WeaponConstants.ThrowingAxe));
            Assert.That(ranged, Contains.Item(WeaponConstants.LightHammer));
            Assert.That(ranged, Contains.Item(WeaponConstants.Trident));
            Assert.That(ranged, Contains.Item(WeaponConstants.Longbow));
            Assert.That(ranged, Contains.Item(WeaponConstants.Arrow));
            Assert.That(ranged, Contains.Item(WeaponConstants.CompositeLongbow));
            Assert.That(ranged, Contains.Item(WeaponConstants.Shortbow));
            Assert.That(ranged, Contains.Item(WeaponConstants.CompositeShortbow));
            Assert.That(ranged, Contains.Item(WeaponConstants.Sai));
            Assert.That(ranged, Contains.Item(WeaponConstants.Bolas));
            Assert.That(ranged, Contains.Item(WeaponConstants.HandCrossbow));
            Assert.That(ranged, Contains.Item(WeaponConstants.HeavyRepeatingCrossbow));
            Assert.That(ranged, Contains.Item(WeaponConstants.LightRepeatingCrossbow));
            Assert.That(ranged, Contains.Item(WeaponConstants.Net));
            Assert.That(ranged, Contains.Item(WeaponConstants.Shuriken));

            Assert.That(ranged.Count(), Is.EqualTo(26));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(ranged, Is.SubsetOf(weapons));
        }

        [Test]
        public void SimpleWeapons()
        {
            var simple = WeaponConstants.GetAllSimple();

            Assert.That(simple, Contains.Item(WeaponConstants.Gauntlet));
            Assert.That(simple, Contains.Item(WeaponConstants.Dagger));
            Assert.That(simple, Contains.Item(WeaponConstants.PunchingDagger));
            Assert.That(simple, Contains.Item(WeaponConstants.SpikedGauntlet));
            Assert.That(simple, Contains.Item(WeaponConstants.LightMace));
            Assert.That(simple, Contains.Item(WeaponConstants.Sickle));
            Assert.That(simple, Contains.Item(WeaponConstants.Club));
            Assert.That(simple, Contains.Item(WeaponConstants.HeavyMace));
            Assert.That(simple, Contains.Item(WeaponConstants.Morningstar));
            Assert.That(simple, Contains.Item(WeaponConstants.Shortspear));
            Assert.That(simple, Contains.Item(WeaponConstants.Longspear));
            Assert.That(simple, Contains.Item(WeaponConstants.Spear));
            Assert.That(simple, Contains.Item(WeaponConstants.Quarterstaff));
            Assert.That(simple, Contains.Item(WeaponConstants.HeavyCrossbow));
            Assert.That(simple, Contains.Item(WeaponConstants.CrossbowBolt));
            Assert.That(simple, Contains.Item(WeaponConstants.LightCrossbow));
            Assert.That(simple, Contains.Item(WeaponConstants.Dart));
            Assert.That(simple, Contains.Item(WeaponConstants.Javelin));
            Assert.That(simple, Contains.Item(WeaponConstants.Sling));
            Assert.That(simple, Contains.Item(WeaponConstants.SlingBullet));

            Assert.That(simple.Count(), Is.EqualTo(20));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(simple, Is.SubsetOf(weapons));

            var martial = WeaponConstants.GetAllMartial();
            Assert.That(simple.Intersect(martial), Is.Empty);

            var exotic = WeaponConstants.GetAllExotic();
            Assert.That(simple.Intersect(exotic), Is.Empty);
        }

        [Test]
        public void MartialWeapons()
        {
            var martial = WeaponConstants.GetAllMartial();

            Assert.That(martial, Contains.Item(WeaponConstants.ThrowingAxe));
            Assert.That(martial, Contains.Item(WeaponConstants.LightHammer));
            Assert.That(martial, Contains.Item(WeaponConstants.Handaxe));
            Assert.That(martial, Contains.Item(WeaponConstants.Kukri));
            Assert.That(martial, Contains.Item(WeaponConstants.LightPick));
            Assert.That(martial, Contains.Item(WeaponConstants.Sap));
            Assert.That(martial, Contains.Item(WeaponConstants.ShortSword));
            Assert.That(martial, Contains.Item(WeaponConstants.Battleaxe));
            Assert.That(martial, Contains.Item(WeaponConstants.Flail));
            Assert.That(martial, Contains.Item(WeaponConstants.Longsword));
            Assert.That(martial, Contains.Item(WeaponConstants.HeavyPick));
            Assert.That(martial, Contains.Item(WeaponConstants.Rapier));
            Assert.That(martial, Contains.Item(WeaponConstants.Scimitar));
            Assert.That(martial, Contains.Item(WeaponConstants.Trident));
            Assert.That(martial, Contains.Item(WeaponConstants.Warhammer));
            Assert.That(martial, Contains.Item(WeaponConstants.Falchion));
            Assert.That(martial, Contains.Item(WeaponConstants.Glaive));
            Assert.That(martial, Contains.Item(WeaponConstants.Greataxe));
            Assert.That(martial, Contains.Item(WeaponConstants.Greatclub));
            Assert.That(martial, Contains.Item(WeaponConstants.HeavyFlail));
            Assert.That(martial, Contains.Item(WeaponConstants.Greatsword));
            Assert.That(martial, Contains.Item(WeaponConstants.Guisarme));
            Assert.That(martial, Contains.Item(WeaponConstants.Halberd));
            Assert.That(martial, Contains.Item(WeaponConstants.Lance));
            Assert.That(martial, Contains.Item(WeaponConstants.Ranseur));
            Assert.That(martial, Contains.Item(WeaponConstants.Scythe));
            Assert.That(martial, Contains.Item(WeaponConstants.Longbow));
            Assert.That(martial, Contains.Item(WeaponConstants.Arrow));
            Assert.That(martial, Contains.Item(WeaponConstants.CompositeLongbow));
            Assert.That(martial, Contains.Item(WeaponConstants.Shortbow));
            Assert.That(martial, Contains.Item(WeaponConstants.CompositeShortbow));

            Assert.That(martial.Count(), Is.EqualTo(31));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(martial, Is.SubsetOf(weapons));

            var simple = WeaponConstants.GetAllSimple();
            Assert.That(martial.Intersect(simple), Is.Empty);

            var exotic = WeaponConstants.GetAllExotic();
            Assert.That(martial.Intersect(exotic), Is.Empty);
        }

        [Test]
        public void ExoticWeapons()
        {
            var exotic = WeaponConstants.GetAllExotic();

            Assert.That(exotic, Contains.Item(WeaponConstants.Kama));
            Assert.That(exotic, Contains.Item(WeaponConstants.Nunchaku));
            Assert.That(exotic, Contains.Item(WeaponConstants.Sai));
            Assert.That(exotic, Contains.Item(WeaponConstants.Siangham));
            Assert.That(exotic, Contains.Item(WeaponConstants.BastardSword));
            Assert.That(exotic, Contains.Item(WeaponConstants.DwarvenWaraxe));
            Assert.That(exotic, Contains.Item(WeaponConstants.Whip));
            Assert.That(exotic, Contains.Item(WeaponConstants.OrcDoubleAxe));
            Assert.That(exotic, Contains.Item(WeaponConstants.SpikedChain));
            Assert.That(exotic, Contains.Item(WeaponConstants.DireFlail));
            Assert.That(exotic, Contains.Item(WeaponConstants.GnomeHookedHammer));
            Assert.That(exotic, Contains.Item(WeaponConstants.TwoBladedSword));
            Assert.That(exotic, Contains.Item(WeaponConstants.DwarvenUrgrosh));
            Assert.That(exotic, Contains.Item(WeaponConstants.Bolas));
            Assert.That(exotic, Contains.Item(WeaponConstants.HandCrossbow));
            Assert.That(exotic, Contains.Item(WeaponConstants.HeavyRepeatingCrossbow));
            Assert.That(exotic, Contains.Item(WeaponConstants.LightRepeatingCrossbow));
            Assert.That(exotic, Contains.Item(WeaponConstants.Net));
            Assert.That(exotic, Contains.Item(WeaponConstants.Shuriken));
            Assert.That(exotic, Contains.Item(WeaponConstants.PincerStaff));

            Assert.That(exotic.Count(), Is.EqualTo(20));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(exotic, Is.SubsetOf(weapons));

            var simple = WeaponConstants.GetAllSimple();
            Assert.That(exotic.Intersect(simple), Is.Empty);

            var martial = WeaponConstants.GetAllMartial();
            Assert.That(exotic.Intersect(martial), Is.Empty);
        }

        [Test]
        public void LightWeapons()
        {
            var light = WeaponConstants.GetAllLight();

            Assert.That(light, Contains.Item(WeaponConstants.Gauntlet));
            Assert.That(light, Contains.Item(WeaponConstants.Dagger));
            Assert.That(light, Contains.Item(WeaponConstants.PunchingDagger));
            Assert.That(light, Contains.Item(WeaponConstants.SpikedGauntlet));
            Assert.That(light, Contains.Item(WeaponConstants.LightMace));
            Assert.That(light, Contains.Item(WeaponConstants.Sickle));
            Assert.That(light, Contains.Item(WeaponConstants.ThrowingAxe));
            Assert.That(light, Contains.Item(WeaponConstants.LightHammer));
            Assert.That(light, Contains.Item(WeaponConstants.Handaxe));
            Assert.That(light, Contains.Item(WeaponConstants.Kukri));
            Assert.That(light, Contains.Item(WeaponConstants.LightPick));
            Assert.That(light, Contains.Item(WeaponConstants.Sap));
            Assert.That(light, Contains.Item(WeaponConstants.ShortSword));
            Assert.That(light, Contains.Item(WeaponConstants.Kama));
            Assert.That(light, Contains.Item(WeaponConstants.Nunchaku));
            Assert.That(light, Contains.Item(WeaponConstants.Sai));
            Assert.That(light, Contains.Item(WeaponConstants.Siangham));

            Assert.That(light.Count(), Is.EqualTo(17));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(light, Is.SubsetOf(weapons));

            var melee = WeaponConstants.GetAllMelee();
            Assert.That(light, Is.SubsetOf(melee));

            var oneHanded = WeaponConstants.GetAllOneHanded();
            Assert.That(light.Intersect(oneHanded), Is.Empty);

            var twoHanded = WeaponConstants.GetAllTwoHanded();
            Assert.That(light.Intersect(twoHanded), Is.Empty);
        }

        [Test]
        public void OneHandedWeapons()
        {
            var oneHanded = WeaponConstants.GetAllOneHanded();

            Assert.That(oneHanded, Contains.Item(WeaponConstants.Club));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.HeavyMace));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.Morningstar));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.Shortspear));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.Battleaxe));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.Flail));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.Longsword));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.HeavyPick));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.Rapier));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.Scimitar));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.Trident));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.Warhammer));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.BastardSword));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.DwarvenWaraxe));
            Assert.That(oneHanded, Contains.Item(WeaponConstants.Whip));

            Assert.That(oneHanded.Count(), Is.EqualTo(15));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(oneHanded, Is.SubsetOf(weapons));

            var melee = WeaponConstants.GetAllMelee();
            Assert.That(oneHanded, Is.SubsetOf(melee));

            var light = WeaponConstants.GetAllLight();
            Assert.That(oneHanded.Intersect(light), Is.Empty);
        }

        [Test]
        public void TwoHandedWeapons()
        {
            var twoHanded = WeaponConstants.GetAllTwoHanded();

            Assert.That(twoHanded, Contains.Item(WeaponConstants.Longspear));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Quarterstaff));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Spear));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Falchion));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Glaive));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Greataxe));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Greatclub));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.HeavyFlail));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Greatsword));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Guisarme));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Halberd));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Lance));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Ranseur));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.Scythe));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.BastardSword));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.OrcDoubleAxe));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.SpikedChain));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.DireFlail));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.GnomeHookedHammer));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.TwoBladedSword));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.DwarvenUrgrosh));
            Assert.That(twoHanded, Contains.Item(WeaponConstants.PincerStaff));

            Assert.That(twoHanded.Count(), Is.EqualTo(22));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(twoHanded, Is.SubsetOf(weapons));

            var melee = WeaponConstants.GetAllMelee();
            Assert.That(twoHanded, Is.SubsetOf(melee));

            var light = WeaponConstants.GetAllLight();
            Assert.That(twoHanded.Intersect(light), Is.Empty);
        }

        [Test]
        public void DoubleWeapons()
        {
            var doubleWeapons = WeaponConstants.GetAllDouble();

            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.Quarterstaff));
            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.OrcDoubleAxe));
            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.DireFlail));
            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.GnomeHookedHammer));
            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.TwoBladedSword));
            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.DwarvenUrgrosh));

            Assert.That(doubleWeapons.Count(), Is.EqualTo(6));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(doubleWeapons, Is.SubsetOf(weapons));

            var melee = WeaponConstants.GetAllMelee();
            Assert.That(doubleWeapons, Is.SubsetOf(melee));

            var twoHanded = WeaponConstants.GetAllTwoHanded();
            Assert.That(doubleWeapons, Is.SubsetOf(twoHanded));
        }

        [Test]
        public void ReachWeapons()
        {
            var reach = WeaponConstants.GetAllReach();

            Assert.That(reach, Contains.Item(WeaponConstants.Longspear));
            Assert.That(reach, Contains.Item(WeaponConstants.Glaive));
            Assert.That(reach, Contains.Item(WeaponConstants.Guisarme));
            Assert.That(reach, Contains.Item(WeaponConstants.Lance));
            Assert.That(reach, Contains.Item(WeaponConstants.Ranseur));
            Assert.That(reach, Contains.Item(WeaponConstants.Whip));
            Assert.That(reach, Contains.Item(WeaponConstants.SpikedChain));
            Assert.That(reach, Contains.Item(WeaponConstants.PincerStaff));

            Assert.That(reach.Count(), Is.EqualTo(8));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(reach, Is.SubsetOf(weapons));

            var melee = WeaponConstants.GetAllMelee();
            Assert.That(reach, Is.SubsetOf(melee));
        }

        [Test]
        public void ThrownWeapons()
        {
            var thrown = WeaponConstants.GetAllThrown();

            Assert.That(thrown, Contains.Item(WeaponConstants.Dagger));
            Assert.That(thrown, Contains.Item(WeaponConstants.Club));
            Assert.That(thrown, Contains.Item(WeaponConstants.Shortspear));
            Assert.That(thrown, Contains.Item(WeaponConstants.Spear));
            Assert.That(thrown, Contains.Item(WeaponConstants.Dart));
            Assert.That(thrown, Contains.Item(WeaponConstants.Javelin));
            Assert.That(thrown, Contains.Item(WeaponConstants.ThrowingAxe));
            Assert.That(thrown, Contains.Item(WeaponConstants.LightHammer));
            Assert.That(thrown, Contains.Item(WeaponConstants.Trident));
            Assert.That(thrown, Contains.Item(WeaponConstants.Sai));
            Assert.That(thrown, Contains.Item(WeaponConstants.Bolas));
            Assert.That(thrown, Contains.Item(WeaponConstants.Net));
            Assert.That(thrown, Contains.Item(WeaponConstants.Shuriken));

            Assert.That(thrown.Count(), Is.EqualTo(13));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(thrown, Is.SubsetOf(weapons));

            var ranged = WeaponConstants.GetAllRanged();
            Assert.That(thrown, Is.SubsetOf(ranged));

            var projectile = WeaponConstants.GetAllProjectile();
            Assert.That(thrown.Intersect(projectile), Is.Empty);
        }

        [Test]
        public void ProjectileWeapons()
        {
            var projectile = WeaponConstants.GetAllProjectile();

            Assert.That(projectile, Contains.Item(WeaponConstants.HeavyCrossbow));
            Assert.That(projectile, Contains.Item(WeaponConstants.LightCrossbow));
            Assert.That(projectile, Contains.Item(WeaponConstants.Sling));
            Assert.That(projectile, Contains.Item(WeaponConstants.Longbow));
            Assert.That(projectile, Contains.Item(WeaponConstants.CompositeLongbow));
            Assert.That(projectile, Contains.Item(WeaponConstants.Shortbow));
            Assert.That(projectile, Contains.Item(WeaponConstants.CompositeShortbow));
            Assert.That(projectile, Contains.Item(WeaponConstants.HandCrossbow));
            Assert.That(projectile, Contains.Item(WeaponConstants.HeavyRepeatingCrossbow));
            Assert.That(projectile, Contains.Item(WeaponConstants.LightRepeatingCrossbow));

            Assert.That(projectile.Count(), Is.EqualTo(10));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(projectile, Is.SubsetOf(weapons));

            var ranged = WeaponConstants.GetAllRanged();
            Assert.That(projectile, Is.SubsetOf(ranged));

            var thrown = WeaponConstants.GetAllThrown();
            Assert.That(projectile.Intersect(thrown), Is.Empty);

            var ammunition = WeaponConstants.GetAllAmmunition();
            Assert.That(projectile.Intersect(ammunition), Is.Empty);
        }

        [Test]
        public void AmmunitionWeapons()
        {
            var ammunition = WeaponConstants.GetAllAmmunition();

            Assert.That(ammunition, Contains.Item(WeaponConstants.CrossbowBolt));
            Assert.That(ammunition, Contains.Item(WeaponConstants.SlingBullet));
            Assert.That(ammunition, Contains.Item(WeaponConstants.Arrow));
            Assert.That(ammunition, Contains.Item(WeaponConstants.Shuriken));

            Assert.That(ammunition.Count(), Is.EqualTo(4));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(ammunition, Is.SubsetOf(weapons));

            var ranged = WeaponConstants.GetAllRanged();
            Assert.That(ammunition, Is.SubsetOf(ranged));

            var projectile = WeaponConstants.GetAllProjectile();
            Assert.That(ammunition.Intersect(projectile), Is.Empty);
        }

        [Test]
        public void BludgeoningWeapons()
        {
            var bludgeoning = WeaponConstants.GetAllBludgeoning();

            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Gauntlet));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.LightMace));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Club));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.HeavyMace));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Morningstar));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Quarterstaff));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Sling));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.SlingBullet));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.LightHammer));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Sap));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Flail));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Warhammer));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Greatclub));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.HeavyFlail));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Nunchaku));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Sai));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.DireFlail));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.GnomeHookedHammer));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Bolas));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.Net));
            Assert.That(bludgeoning, Contains.Item(WeaponConstants.PincerStaff));

            Assert.That(bludgeoning.Count(), Is.EqualTo(21));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(bludgeoning, Is.SubsetOf(weapons));
        }

        [Test]
        public void PiercingWeapons()
        {
            var piercing = WeaponConstants.GetAllPiercing();

            Assert.That(piercing, Contains.Item(WeaponConstants.Dagger));
            Assert.That(piercing, Contains.Item(WeaponConstants.PunchingDagger));
            Assert.That(piercing, Contains.Item(WeaponConstants.SpikedGauntlet));
            Assert.That(piercing, Contains.Item(WeaponConstants.Morningstar));
            Assert.That(piercing, Contains.Item(WeaponConstants.Shortspear));
            Assert.That(piercing, Contains.Item(WeaponConstants.Longspear));
            Assert.That(piercing, Contains.Item(WeaponConstants.Spear));
            Assert.That(piercing, Contains.Item(WeaponConstants.HeavyCrossbow));
            Assert.That(piercing, Contains.Item(WeaponConstants.CrossbowBolt));
            Assert.That(piercing, Contains.Item(WeaponConstants.LightCrossbow));
            Assert.That(piercing, Contains.Item(WeaponConstants.Dart));
            Assert.That(piercing, Contains.Item(WeaponConstants.Javelin));
            Assert.That(piercing, Contains.Item(WeaponConstants.LightPick));
            Assert.That(piercing, Contains.Item(WeaponConstants.ShortSword));
            Assert.That(piercing, Contains.Item(WeaponConstants.HeavyPick));
            Assert.That(piercing, Contains.Item(WeaponConstants.Rapier));
            Assert.That(piercing, Contains.Item(WeaponConstants.Trident));
            Assert.That(piercing, Contains.Item(WeaponConstants.Halberd));
            Assert.That(piercing, Contains.Item(WeaponConstants.Lance));
            Assert.That(piercing, Contains.Item(WeaponConstants.Ranseur));
            Assert.That(piercing, Contains.Item(WeaponConstants.Scythe));
            Assert.That(piercing, Contains.Item(WeaponConstants.Longbow));
            Assert.That(piercing, Contains.Item(WeaponConstants.Arrow));
            Assert.That(piercing, Contains.Item(WeaponConstants.CompositeLongbow));
            Assert.That(piercing, Contains.Item(WeaponConstants.Shortbow));
            Assert.That(piercing, Contains.Item(WeaponConstants.CompositeShortbow));
            Assert.That(piercing, Contains.Item(WeaponConstants.Siangham));
            Assert.That(piercing, Contains.Item(WeaponConstants.SpikedChain));
            Assert.That(piercing, Contains.Item(WeaponConstants.GnomeHookedHammer));
            Assert.That(piercing, Contains.Item(WeaponConstants.DwarvenUrgrosh));
            Assert.That(piercing, Contains.Item(WeaponConstants.HandCrossbow));
            Assert.That(piercing, Contains.Item(WeaponConstants.HeavyRepeatingCrossbow));
            Assert.That(piercing, Contains.Item(WeaponConstants.LightRepeatingCrossbow));
            Assert.That(piercing, Contains.Item(WeaponConstants.Shuriken));

            Assert.That(piercing.Count(), Is.EqualTo(34));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(piercing, Is.SubsetOf(weapons));
        }

        [Test]
        public void SlashingWeapons()
        {
            var slashing = WeaponConstants.GetAllSlashing();

            Assert.That(slashing, Contains.Item(WeaponConstants.Dagger));
            Assert.That(slashing, Contains.Item(WeaponConstants.Sickle));
            Assert.That(slashing, Contains.Item(WeaponConstants.ThrowingAxe));
            Assert.That(slashing, Contains.Item(WeaponConstants.Handaxe));
            Assert.That(slashing, Contains.Item(WeaponConstants.Kukri));
            Assert.That(slashing, Contains.Item(WeaponConstants.Battleaxe));
            Assert.That(slashing, Contains.Item(WeaponConstants.Longsword));
            Assert.That(slashing, Contains.Item(WeaponConstants.Scimitar));
            Assert.That(slashing, Contains.Item(WeaponConstants.Falchion));
            Assert.That(slashing, Contains.Item(WeaponConstants.Glaive));
            Assert.That(slashing, Contains.Item(WeaponConstants.Greataxe));
            Assert.That(slashing, Contains.Item(WeaponConstants.Greatsword));
            Assert.That(slashing, Contains.Item(WeaponConstants.Guisarme));
            Assert.That(slashing, Contains.Item(WeaponConstants.Halberd));
            Assert.That(slashing, Contains.Item(WeaponConstants.Scythe));
            Assert.That(slashing, Contains.Item(WeaponConstants.Kama));
            Assert.That(slashing, Contains.Item(WeaponConstants.BastardSword));
            Assert.That(slashing, Contains.Item(WeaponConstants.DwarvenWaraxe));
            Assert.That(slashing, Contains.Item(WeaponConstants.Whip));
            Assert.That(slashing, Contains.Item(WeaponConstants.OrcDoubleAxe));
            Assert.That(slashing, Contains.Item(WeaponConstants.TwoBladedSword));
            Assert.That(slashing, Contains.Item(WeaponConstants.DwarvenUrgrosh));

            Assert.That(slashing.Count(), Is.EqualTo(22));

            var weapons = WeaponConstants.GetBaseNames();
            Assert.That(slashing, Is.SubsetOf(weapons));
        }
    }
}