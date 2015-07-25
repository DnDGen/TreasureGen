using System;
using System.Linq;
using TreasureGen.Common.Items;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Common.Items
{
    [TestFixture]
    public class WeaponConstantsTests
    {
        [TestCase(WeaponConstants.Dagger, "Dagger")]
        [TestCase(WeaponConstants.Greataxe, "Greataxe")]
        [TestCase(WeaponConstants.Greatsword, "Greatsword")]
        [TestCase(WeaponConstants.Kama, "Kama")]
        [TestCase(WeaponConstants.Longsword, "Longsword")]
        [TestCase(WeaponConstants.LightMace, "Light mace")]
        [TestCase(WeaponConstants.HeavyMace, "Heavy mace")]
        [TestCase(WeaponConstants.Nunchaku, "Nunchaku")]
        [TestCase(WeaponConstants.Quarterstaff, "Quarterstaff")]
        [TestCase(WeaponConstants.Rapier, "Rapier")]
        [TestCase(WeaponConstants.Scimitar, "Scimitar")]
        [TestCase(WeaponConstants.Shortspear, "Shortspear")]
        [TestCase(WeaponConstants.Siangham, "Siangham")]
        [TestCase(WeaponConstants.BastardSword, "Bastard sword")]
        [TestCase(WeaponConstants.ShortSword, "Short sword")]
        [TestCase(WeaponConstants.DwarvenWaraxe, "Dwarven waraxe")]
        [TestCase(WeaponConstants.OrcDoubleAxe, "Orc double axe")]
        [TestCase(WeaponConstants.Battleaxe, "Battleaxe")]
        [TestCase(WeaponConstants.SpikedChain, "Spiked chain")]
        [TestCase(WeaponConstants.Club, "Club")]
        [TestCase(WeaponConstants.HandCrossbow, "Hand crossbow")]
        [TestCase(WeaponConstants.RepeatingCrossbow, "Repeating crossbow")]
        [TestCase(WeaponConstants.PunchingDagger, "Punching dagger")]
        [TestCase(WeaponConstants.Falchion, "Falchion")]
        [TestCase(WeaponConstants.DireFlail, "Dire flail")]
        [TestCase(WeaponConstants.HeavyFlail, "Heavy flail")]
        [TestCase(WeaponConstants.LightFlail, "Light flail")]
        [TestCase(WeaponConstants.Gauntlet, "Gauntlet")]
        [TestCase(WeaponConstants.SpikedGauntlet, "Spiked gauntlet")]
        [TestCase(WeaponConstants.Glaive, "Glaive")]
        [TestCase(WeaponConstants.Greatclub, "Greatclub")]
        [TestCase(WeaponConstants.Guisarme, "Guisarme")]
        [TestCase(WeaponConstants.Halberd, "Halberd")]
        [TestCase(WeaponConstants.Halfspear, "Halfspear")]
        [TestCase(WeaponConstants.GnomeHookedHammer, "Gnome hooked hammer")]
        [TestCase(WeaponConstants.LightHammer, "Light hammer")]
        [TestCase(WeaponConstants.Handaxe, "Handaxe")]
        [TestCase(WeaponConstants.Kukri, "Kukri")]
        [TestCase(WeaponConstants.Lance, "Lance")]
        [TestCase(WeaponConstants.Longspear, "Longspear")]
        [TestCase(WeaponConstants.Morningstar, "Morningstar")]
        [TestCase(WeaponConstants.Net, "Net")]
        [TestCase(WeaponConstants.HeavyPick, "Heavy pick")]
        [TestCase(WeaponConstants.LightPick, "Light pick")]
        [TestCase(WeaponConstants.Ranseur, "Ranseur")]
        [TestCase(WeaponConstants.Sap, "Sap")]
        [TestCase(WeaponConstants.Scythe, "Scythe")]
        [TestCase(WeaponConstants.Shuriken, "Shuriken")]
        [TestCase(WeaponConstants.Sickle, "Sickle")]
        [TestCase(WeaponConstants.TwoBladedSword, "Two-bladed sword")]
        [TestCase(WeaponConstants.Trident, "Trident")]
        [TestCase(WeaponConstants.DwarvenUrgrosh, "Dwarven urgrosh")]
        [TestCase(WeaponConstants.Warhammer, "Warhammer")]
        [TestCase(WeaponConstants.Whip, "Whip")]
        [TestCase(WeaponConstants.Arrow, "Arrow")]
        [TestCase(WeaponConstants.CrossbowBolt, "Crossbow bolt")]
        [TestCase(WeaponConstants.SlingBullet, "Sling bullet")]
        [TestCase(WeaponConstants.ThrowingAxe, "Throwing axe")]
        [TestCase(WeaponConstants.HeavyCrossbow, "Heavy crossbow")]
        [TestCase(WeaponConstants.LightCrossbow, "Light crossbow")]
        [TestCase(WeaponConstants.Dart, "Dart")]
        [TestCase(WeaponConstants.Javelin, "Javelin")]
        [TestCase(WeaponConstants.Shortbow, "Shortbow")]
        [TestCase(WeaponConstants.CompositePlus0Shortbow, "Composite (+0) shortbow")]
        [TestCase(WeaponConstants.CompositePlus1Shortbow, "Composite (+1) shortbow")]
        [TestCase(WeaponConstants.CompositePlus2Shortbow, "Composite (+2) shortbow")]
        [TestCase(WeaponConstants.Sling, "Sling")]
        [TestCase(WeaponConstants.Longbow, "Longbow")]
        [TestCase(WeaponConstants.CompositePlus0Longbow, "Composite (+0) longbow")]
        [TestCase(WeaponConstants.CompositePlus1Longbow, "Composite (+1) longbow")]
        [TestCase(WeaponConstants.CompositePlus2Longbow, "Composite (+2) longbow")]
        [TestCase(WeaponConstants.CompositePlus3Longbow, "Composite (+3) longbow")]
        [TestCase(WeaponConstants.CompositePlus4Longbow, "Composite (+4) longbow")]
        [TestCase(WeaponConstants.SleepArrow, "Sleep arrow")]
        [TestCase(WeaponConstants.ScreamingBolt, "Screaming bolt")]
        [TestCase(WeaponConstants.SilverDagger, "Silver dagger")]
        [TestCase(WeaponConstants.JavelinOfLightning, "Javelin of lightning")]
        [TestCase(WeaponConstants.SlayingArrow, "Slaying arrow")]
        [TestCase(WeaponConstants.AssassinsDagger, "Assassin's dagger")]
        [TestCase(WeaponConstants.ShiftersSorrow, "Shifter's sorrow")]
        [TestCase(WeaponConstants.TridentOfFishCommand, "Trident of fish command")]
        [TestCase(WeaponConstants.FlameTongue, "Flame tongue")]
        [TestCase(WeaponConstants.LuckBlade0, "Luck blade (0 wishes)")]
        [TestCase(WeaponConstants.LuckBlade1, "Luck blade (1 wish)")]
        [TestCase(WeaponConstants.LuckBlade2, "Luck blade (2 wishes)")]
        [TestCase(WeaponConstants.LuckBlade3, "Luck blade (3 wishes)")]
        [TestCase(WeaponConstants.SwordOfSubtlety, "Sword of subtlety")]
        [TestCase(WeaponConstants.SwordOfThePlanes, "Sword of the planes")]
        [TestCase(WeaponConstants.NineLivesStealer, "Nine lives stealer")]
        [TestCase(WeaponConstants.SwordOfLifeStealing, "Sword of life stealing")]
        [TestCase(WeaponConstants.Oathbow, "Oathbow")]
        [TestCase(WeaponConstants.MaceOfTerror, "Mace of terror")]
        [TestCase(WeaponConstants.LifeDrinker, "Life-drinker")]
        [TestCase(WeaponConstants.SylvanScimitar, "Sylvan scimitar")]
        [TestCase(WeaponConstants.RapierOfPuncturing, "Rapier of puncturing")]
        [TestCase(WeaponConstants.SunBlade, "Sun blade")]
        [TestCase(WeaponConstants.FrostBrand, "Frost brand")]
        [TestCase(WeaponConstants.DwarvenThrower, "Dwarven thrower")]
        [TestCase(WeaponConstants.MaceOfSmiting, "Mace of smiting")]
        [TestCase(WeaponConstants.HolyAvenger, "Holy avenger")]
        [TestCase(WeaponConstants.LuckBlade, "Luck blade")]
        [TestCase(WeaponConstants.GreaterSlayingArrow, "Greater slaying arrow")]
        [TestCase(WeaponConstants.Shatterspike, "Shatterspike")]
        [TestCase(WeaponConstants.DaggerOfVenom, "Dagger of venom")]
        [TestCase(WeaponConstants.TridentOfWarning, "Trident of warning")]
        [TestCase(WeaponConstants.CursedMinus2Sword, "Cursed -2 sword")]
        [TestCase(WeaponConstants.CursedBackbiterSpear, "Cursed backbiter spear")]
        [TestCase(WeaponConstants.NetOfSnaring, "Net of snaring")]
        [TestCase(WeaponConstants.MaceOfBlood, "Mace of blood")]
        [TestCase(WeaponConstants.BerserkingSword, "Berserking sword")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void AllWeapons()
        {
            var weapons = WeaponConstants.GetAllWeapons();

            Assert.That(weapons, Contains.Item(WeaponConstants.Dagger));
            Assert.That(weapons, Contains.Item(WeaponConstants.Greataxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Greatsword));
            Assert.That(weapons, Contains.Item(WeaponConstants.Kama));
            Assert.That(weapons, Contains.Item(WeaponConstants.Longsword));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightMace));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyMace));
            Assert.That(weapons, Contains.Item(WeaponConstants.Nunchaku));
            Assert.That(weapons, Contains.Item(WeaponConstants.Quarterstaff));
            Assert.That(weapons, Contains.Item(WeaponConstants.Rapier));
            Assert.That(weapons, Contains.Item(WeaponConstants.Scimitar));
            Assert.That(weapons, Contains.Item(WeaponConstants.Shortspear));
            Assert.That(weapons, Contains.Item(WeaponConstants.Siangham));
            Assert.That(weapons, Contains.Item(WeaponConstants.BastardSword));
            Assert.That(weapons, Contains.Item(WeaponConstants.ShortSword));
            Assert.That(weapons, Contains.Item(WeaponConstants.DwarvenWaraxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.OrcDoubleAxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Battleaxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.SpikedChain));
            Assert.That(weapons, Contains.Item(WeaponConstants.Club));
            Assert.That(weapons, Contains.Item(WeaponConstants.HandCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.RepeatingCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.PunchingDagger));
            Assert.That(weapons, Contains.Item(WeaponConstants.Falchion));
            Assert.That(weapons, Contains.Item(WeaponConstants.DireFlail));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyFlail));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightFlail));
            Assert.That(weapons, Contains.Item(WeaponConstants.Gauntlet));
            Assert.That(weapons, Contains.Item(WeaponConstants.SpikedGauntlet));
            Assert.That(weapons, Contains.Item(WeaponConstants.Glaive));
            Assert.That(weapons, Contains.Item(WeaponConstants.Greatclub));
            Assert.That(weapons, Contains.Item(WeaponConstants.Guisarme));
            Assert.That(weapons, Contains.Item(WeaponConstants.Halberd));
            Assert.That(weapons, Contains.Item(WeaponConstants.Halfspear));
            Assert.That(weapons, Contains.Item(WeaponConstants.GnomeHookedHammer));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightHammer));
            Assert.That(weapons, Contains.Item(WeaponConstants.Handaxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Kukri));
            Assert.That(weapons, Contains.Item(WeaponConstants.Lance));
            Assert.That(weapons, Contains.Item(WeaponConstants.Longspear));
            Assert.That(weapons, Contains.Item(WeaponConstants.Morningstar));
            Assert.That(weapons, Contains.Item(WeaponConstants.Net));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyPick));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightPick));
            Assert.That(weapons, Contains.Item(WeaponConstants.Ranseur));
            Assert.That(weapons, Contains.Item(WeaponConstants.Sap));
            Assert.That(weapons, Contains.Item(WeaponConstants.Scythe));
            Assert.That(weapons, Contains.Item(WeaponConstants.Shuriken));
            Assert.That(weapons, Contains.Item(WeaponConstants.Sickle));
            Assert.That(weapons, Contains.Item(WeaponConstants.TwoBladedSword));
            Assert.That(weapons, Contains.Item(WeaponConstants.Trident));
            Assert.That(weapons, Contains.Item(WeaponConstants.DwarvenUrgrosh));
            Assert.That(weapons, Contains.Item(WeaponConstants.Warhammer));
            Assert.That(weapons, Contains.Item(WeaponConstants.Whip));
            Assert.That(weapons, Contains.Item(WeaponConstants.Arrow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CrossbowBolt));
            Assert.That(weapons, Contains.Item(WeaponConstants.SlingBullet));
            Assert.That(weapons, Contains.Item(WeaponConstants.ThrowingAxe));
            Assert.That(weapons, Contains.Item(WeaponConstants.HeavyCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.LightCrossbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Dart));
            Assert.That(weapons, Contains.Item(WeaponConstants.Javelin));
            Assert.That(weapons, Contains.Item(WeaponConstants.Shortbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositePlus0Shortbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositePlus1Shortbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositePlus2Shortbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Sling));
            Assert.That(weapons, Contains.Item(WeaponConstants.Longbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositePlus0Longbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositePlus1Longbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositePlus2Longbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositePlus3Longbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.CompositePlus4Longbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.SleepArrow));
            Assert.That(weapons, Contains.Item(WeaponConstants.ScreamingBolt));
            Assert.That(weapons, Is.Not.Contains(WeaponConstants.SilverDagger));
            Assert.That(weapons, Contains.Item(WeaponConstants.JavelinOfLightning));
            Assert.That(weapons, Contains.Item(WeaponConstants.SlayingArrow));
            Assert.That(weapons, Contains.Item(WeaponConstants.AssassinsDagger));
            Assert.That(weapons, Contains.Item(WeaponConstants.ShiftersSorrow));
            Assert.That(weapons, Contains.Item(WeaponConstants.TridentOfFishCommand));
            Assert.That(weapons, Contains.Item(WeaponConstants.FlameTongue));
            Assert.That(weapons, Is.Not.Contains(WeaponConstants.LuckBlade0));
            Assert.That(weapons, Is.Not.Contains(WeaponConstants.LuckBlade1));
            Assert.That(weapons, Is.Not.Contains(WeaponConstants.LuckBlade2));
            Assert.That(weapons, Is.Not.Contains(WeaponConstants.LuckBlade3));
            Assert.That(weapons, Contains.Item(WeaponConstants.SwordOfSubtlety));
            Assert.That(weapons, Contains.Item(WeaponConstants.SwordOfThePlanes));
            Assert.That(weapons, Contains.Item(WeaponConstants.NineLivesStealer));
            Assert.That(weapons, Contains.Item(WeaponConstants.SwordOfLifeStealing));
            Assert.That(weapons, Contains.Item(WeaponConstants.Oathbow));
            Assert.That(weapons, Contains.Item(WeaponConstants.MaceOfTerror));
            Assert.That(weapons, Contains.Item(WeaponConstants.LifeDrinker));
            Assert.That(weapons, Contains.Item(WeaponConstants.SylvanScimitar));
            Assert.That(weapons, Contains.Item(WeaponConstants.RapierOfPuncturing));
            Assert.That(weapons, Contains.Item(WeaponConstants.SunBlade));
            Assert.That(weapons, Contains.Item(WeaponConstants.FrostBrand));
            Assert.That(weapons, Contains.Item(WeaponConstants.DwarvenThrower));
            Assert.That(weapons, Contains.Item(WeaponConstants.MaceOfSmiting));
            Assert.That(weapons, Contains.Item(WeaponConstants.HolyAvenger));
            Assert.That(weapons, Contains.Item(WeaponConstants.LuckBlade));
            Assert.That(weapons, Contains.Item(WeaponConstants.GreaterSlayingArrow));
            Assert.That(weapons, Contains.Item(WeaponConstants.Shatterspike));
            Assert.That(weapons, Contains.Item(WeaponConstants.DaggerOfVenom));
            Assert.That(weapons, Contains.Item(WeaponConstants.TridentOfWarning));
            Assert.That(weapons, Contains.Item(WeaponConstants.CursedBackbiterSpear));
            Assert.That(weapons, Contains.Item(WeaponConstants.CursedMinus2Sword));
            Assert.That(weapons, Contains.Item(WeaponConstants.NetOfSnaring));
            Assert.That(weapons, Contains.Item(WeaponConstants.MaceOfBlood));
            Assert.That(weapons, Contains.Item(WeaponConstants.BerserkingSword));
            Assert.That(weapons.Count(), Is.EqualTo(105));
        }
    }
}