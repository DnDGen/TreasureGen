using DnDGen.TreasureGen.Items;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items
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
        [TestCase(WeaponConstants.Dagger_Silver, "Silver dagger")]
        [TestCase(WeaponConstants.Dagger_Adamantine, "Adamantine dagger")]
        [TestCase(WeaponConstants.Battleaxe_Adamantine, "Adamantine battleaxe")]
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

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void AllWeapons(bool specific, bool template)
        {
            var ranged = WeaponConstants.GetAllRanged(specific, template);
            var melee = WeaponConstants.GetAllMelee(specific, template);
            var simple = WeaponConstants.GetAllSimple(specific, template);
            var martial = WeaponConstants.GetAllMartial(specific, template);
            var exotic = WeaponConstants.GetAllExotic(specific, template);
            var piercing = WeaponConstants.GetAllPiercing(specific, template);
            var bludgeoning = WeaponConstants.GetAllBludgeoning(specific, template);
            var slashing = WeaponConstants.GetAllSlashing(specific, template);

            var weapons = WeaponConstants.GetAllWeapons(specific, template);

            Assert.That(weapons, Is.EquivalentTo(melee.Union(ranged)));
            Assert.That(weapons, Is.EquivalentTo(simple.Union(martial).Union(exotic)));
            Assert.That(weapons, Is.EquivalentTo(piercing.Union(bludgeoning).Union(slashing)));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void AllMeleeWeapons(bool specific, bool template)
        {
            var light = WeaponConstants.GetAllLightMelee(specific, template);
            var oneHanded = WeaponConstants.GetAllOneHandedMelee(specific, template);
            var twoHanded = WeaponConstants.GetAllTwoHandedMelee(specific, template);
            var melee = WeaponConstants.GetAllMelee(specific, template);

            Assert.That(melee, Is.EquivalentTo(light.Union(oneHanded).Union(twoHanded)));

            var ranged = WeaponConstants.GetAllRanged(specific, template);
            var intersection = melee.Intersect(ranged);

            Assert.That(intersection, Is.SupersetOf(new[]
                {
                    WeaponConstants.Dagger,
                    WeaponConstants.Club,
                    WeaponConstants.Shortspear,
                    WeaponConstants.Spear,
                    WeaponConstants.LightHammer,
                    WeaponConstants.Trident,
                    WeaponConstants.Sai,
                    WeaponConstants.ThrowingAxe,
                }));

            if (specific)
                Assert.That(intersection, Is.SupersetOf(new[]
                {
                    WeaponConstants.AssassinsDagger,
                    WeaponConstants.DaggerOfVenom,
                    WeaponConstants.TridentOfFishCommand,
                    WeaponConstants.TridentOfWarning,
                    WeaponConstants.CursedBackbiterSpear,
                }));

            if (template)
                Assert.That(intersection, Is.SupersetOf(new[]
                {
                    WeaponConstants.Dagger_Adamantine,
                    WeaponConstants.Dagger_Silver,
                }));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void AllRangedWeapons(bool specific, bool template)
        {
            var ranged = WeaponConstants.GetAllRanged(specific, template);

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

            var total = 26;

            if (specific)
            {
                Assert.That(ranged, Contains.Item(WeaponConstants.SleepArrow));
                Assert.That(ranged, Contains.Item(WeaponConstants.SlayingArrow));
                Assert.That(ranged, Contains.Item(WeaponConstants.GreaterSlayingArrow));
                Assert.That(ranged, Contains.Item(WeaponConstants.ScreamingBolt));
                Assert.That(ranged, Contains.Item(WeaponConstants.JavelinOfLightning));
                Assert.That(ranged, Contains.Item(WeaponConstants.Oathbow));
                Assert.That(ranged, Contains.Item(WeaponConstants.NetOfSnaring));
                Assert.That(ranged, Contains.Item(WeaponConstants.AssassinsDagger));
                Assert.That(ranged, Contains.Item(WeaponConstants.DaggerOfVenom));
                Assert.That(ranged, Contains.Item(WeaponConstants.TridentOfFishCommand));
                Assert.That(ranged, Contains.Item(WeaponConstants.TridentOfWarning));
                Assert.That(ranged, Contains.Item(WeaponConstants.CursedBackbiterSpear));

                total += 12;
            }
            else
            {
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.SleepArrow));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.SlayingArrow));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.GreaterSlayingArrow));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.ScreamingBolt));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.JavelinOfLightning));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.Oathbow));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.NetOfSnaring));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.AssassinsDagger));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.DaggerOfVenom));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.TridentOfFishCommand));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.TridentOfWarning));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.CursedBackbiterSpear));
            }

            if (template)
            {
                Assert.That(ranged, Contains.Item(WeaponConstants.Dagger_Adamantine));
                Assert.That(ranged, Contains.Item(WeaponConstants.Dagger_Silver));
                Assert.That(ranged, Contains.Item(WeaponConstants.CompositePlus0Longbow));
                Assert.That(ranged, Contains.Item(WeaponConstants.CompositePlus0Shortbow));
                Assert.That(ranged, Contains.Item(WeaponConstants.CompositePlus1Longbow));
                Assert.That(ranged, Contains.Item(WeaponConstants.CompositePlus1Shortbow));
                Assert.That(ranged, Contains.Item(WeaponConstants.CompositePlus2Longbow));
                Assert.That(ranged, Contains.Item(WeaponConstants.CompositePlus2Shortbow));
                Assert.That(ranged, Contains.Item(WeaponConstants.CompositePlus3Longbow));
                Assert.That(ranged, Contains.Item(WeaponConstants.CompositePlus4Longbow));

                total += 10;
            }
            else
            {
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.Dagger_Adamantine));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.Dagger_Silver));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.CompositePlus0Longbow));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.CompositePlus0Shortbow));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.CompositePlus1Longbow));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.CompositePlus1Shortbow));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.CompositePlus2Longbow));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.CompositePlus2Shortbow));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.CompositePlus3Longbow));
                Assert.That(ranged, Does.Not.Contain(WeaponConstants.CompositePlus4Longbow));
            }

            Assert.That(ranged.Count(), Is.EqualTo(total));

            var melee = WeaponConstants.GetAllMelee(specific, template);
            var intersection = ranged.Intersect(melee);

            Assert.That(intersection, Is.SupersetOf(new[]
                {
                    WeaponConstants.Dagger,
                    WeaponConstants.Club,
                    WeaponConstants.Shortspear,
                    WeaponConstants.Spear,
                    WeaponConstants.LightHammer,
                    WeaponConstants.Trident,
                    WeaponConstants.Sai,
                    WeaponConstants.ThrowingAxe,
                }));

            if (specific)
                Assert.That(intersection, Is.SupersetOf(new[]
                {
                    WeaponConstants.AssassinsDagger,
                    WeaponConstants.DaggerOfVenom,
                    WeaponConstants.TridentOfFishCommand,
                    WeaponConstants.TridentOfWarning,
                    WeaponConstants.CursedBackbiterSpear,
                }));

            if (template)
                Assert.That(intersection, Is.SupersetOf(new[]
                {
                    WeaponConstants.Dagger_Adamantine,
                    WeaponConstants.Dagger_Silver,
                }));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void AllSimpleWeapons(bool specific, bool template)
        {
            var simple = WeaponConstants.GetAllSimple(specific, template);

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

            var total = 20;

            if (specific)
            {
                Assert.That(simple, Contains.Item(WeaponConstants.ScreamingBolt));
                Assert.That(simple, Contains.Item(WeaponConstants.JavelinOfLightning));
                Assert.That(simple, Contains.Item(WeaponConstants.AssassinsDagger));
                Assert.That(simple, Contains.Item(WeaponConstants.MaceOfTerror));
                Assert.That(simple, Contains.Item(WeaponConstants.MaceOfSmiting));
                Assert.That(simple, Contains.Item(WeaponConstants.DaggerOfVenom));
                Assert.That(simple, Contains.Item(WeaponConstants.CursedBackbiterSpear));
                Assert.That(simple, Contains.Item(WeaponConstants.MaceOfBlood));

                total += 8;
            }
            else
            {
                Assert.That(simple, Does.Not.Contain(WeaponConstants.ScreamingBolt));
                Assert.That(simple, Does.Not.Contain(WeaponConstants.JavelinOfLightning));
                Assert.That(simple, Does.Not.Contain(WeaponConstants.AssassinsDagger));
                Assert.That(simple, Does.Not.Contain(WeaponConstants.MaceOfTerror));
                Assert.That(simple, Does.Not.Contain(WeaponConstants.MaceOfSmiting));
                Assert.That(simple, Does.Not.Contain(WeaponConstants.DaggerOfVenom));
                Assert.That(simple, Does.Not.Contain(WeaponConstants.CursedBackbiterSpear));
                Assert.That(simple, Does.Not.Contain(WeaponConstants.MaceOfBlood));
            }

            if (template)
            {
                Assert.That(simple, Contains.Item(WeaponConstants.Dagger_Adamantine));
                Assert.That(simple, Contains.Item(WeaponConstants.Dagger_Silver));

                total += 2;
            }
            else
            {
                Assert.That(simple, Does.Not.Contain(WeaponConstants.Dagger_Adamantine));
                Assert.That(simple, Does.Not.Contain(WeaponConstants.Dagger_Silver));
            }

            Assert.That(simple.Count(), Is.EqualTo(total));

            var martial = WeaponConstants.GetAllMartial(specific, template);
            Assert.That(simple.Intersect(martial), Is.Empty);

            var exotic = WeaponConstants.GetAllExotic(specific, template);
            Assert.That(simple.Intersect(exotic), Is.Empty);
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void AllMartialWeapons(bool specific, bool template)
        {
            var martial = WeaponConstants.GetAllMartial(specific, template);

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

            var total = 31;

            if (specific)
            {
                Assert.That(martial, Contains.Item(WeaponConstants.SleepArrow));
                Assert.That(martial, Contains.Item(WeaponConstants.SlayingArrow));
                Assert.That(martial, Contains.Item(WeaponConstants.TridentOfFishCommand));
                Assert.That(martial, Contains.Item(WeaponConstants.FlameTongue));
                Assert.That(martial, Contains.Item(WeaponConstants.SwordOfSubtlety));
                Assert.That(martial, Contains.Item(WeaponConstants.SwordOfThePlanes));
                Assert.That(martial, Contains.Item(WeaponConstants.NineLivesStealer));
                Assert.That(martial, Contains.Item(WeaponConstants.SwordOfLifeStealing));
                Assert.That(martial, Contains.Item(WeaponConstants.Oathbow));
                Assert.That(martial, Contains.Item(WeaponConstants.LifeDrinker));
                Assert.That(martial, Contains.Item(WeaponConstants.SylvanScimitar));
                Assert.That(martial, Contains.Item(WeaponConstants.RapierOfPuncturing));
                Assert.That(martial, Contains.Item(WeaponConstants.SunBlade));
                Assert.That(martial, Contains.Item(WeaponConstants.FrostBrand));
                Assert.That(martial, Contains.Item(WeaponConstants.DwarvenThrower));
                Assert.That(martial, Contains.Item(WeaponConstants.HolyAvenger));
                Assert.That(martial, Contains.Item(WeaponConstants.LuckBlade));
                Assert.That(martial, Contains.Item(WeaponConstants.GreaterSlayingArrow));
                Assert.That(martial, Contains.Item(WeaponConstants.Shatterspike));
                Assert.That(martial, Contains.Item(WeaponConstants.TridentOfWarning));
                Assert.That(martial, Contains.Item(WeaponConstants.BerserkingSword));
                Assert.That(martial, Contains.Item(WeaponConstants.CursedMinus2Sword));

                total += 22;
            }
            else
            {
                Assert.That(martial, Does.Not.Contain(WeaponConstants.SleepArrow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.SlayingArrow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.TridentOfFishCommand));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.FlameTongue));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.SwordOfSubtlety));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.SwordOfThePlanes));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.NineLivesStealer));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.SwordOfLifeStealing));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.Oathbow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.LifeDrinker));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.SylvanScimitar));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.RapierOfPuncturing));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.SunBlade));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.FrostBrand));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.DwarvenThrower));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.HolyAvenger));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.LuckBlade));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.GreaterSlayingArrow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.Shatterspike));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.TridentOfWarning));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.BerserkingSword));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.CursedMinus2Sword));
            }

            if (template)
            {
                Assert.That(martial, Contains.Item(WeaponConstants.Battleaxe_Adamantine));
                Assert.That(martial, Contains.Item(WeaponConstants.CompositePlus0Longbow));
                Assert.That(martial, Contains.Item(WeaponConstants.CompositePlus0Shortbow));
                Assert.That(martial, Contains.Item(WeaponConstants.CompositePlus1Longbow));
                Assert.That(martial, Contains.Item(WeaponConstants.CompositePlus1Shortbow));
                Assert.That(martial, Contains.Item(WeaponConstants.CompositePlus2Longbow));
                Assert.That(martial, Contains.Item(WeaponConstants.CompositePlus2Shortbow));
                Assert.That(martial, Contains.Item(WeaponConstants.CompositePlus3Longbow));
                Assert.That(martial, Contains.Item(WeaponConstants.CompositePlus4Longbow));
                Assert.That(martial, Contains.Item(WeaponConstants.LuckBlade0));
                Assert.That(martial, Contains.Item(WeaponConstants.LuckBlade1));
                Assert.That(martial, Contains.Item(WeaponConstants.LuckBlade2));
                Assert.That(martial, Contains.Item(WeaponConstants.LuckBlade3));

                total += 13;
            }
            else
            {
                Assert.That(martial, Does.Not.Contain(WeaponConstants.Battleaxe_Adamantine));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.CompositePlus0Longbow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.CompositePlus0Shortbow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.CompositePlus1Longbow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.CompositePlus1Shortbow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.CompositePlus2Longbow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.CompositePlus2Shortbow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.CompositePlus3Longbow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.CompositePlus4Longbow));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.LuckBlade0));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.LuckBlade1));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.LuckBlade2));
                Assert.That(martial, Does.Not.Contain(WeaponConstants.LuckBlade3));
            }

            Assert.That(martial.Count(), Is.EqualTo(total));

            var simple = WeaponConstants.GetAllSimple(specific, template);
            Assert.That(martial.Intersect(simple), Is.Empty);

            var exotic = WeaponConstants.GetAllExotic(specific, template);
            Assert.That(martial.Intersect(exotic), Is.Empty.Or.EqualTo(new[] { WeaponConstants.SunBlade }));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void AllExoticWeapons(bool specific, bool template)
        {
            var exotic = WeaponConstants.GetAllExotic(specific, template);

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

            var total = 20;

            if (specific)
            {
                Assert.That(exotic, Contains.Item(WeaponConstants.ShiftersSorrow));
                Assert.That(exotic, Contains.Item(WeaponConstants.SunBlade));
                Assert.That(exotic, Contains.Item(WeaponConstants.NetOfSnaring));

                total += 3;
            }
            else
            {
                Assert.That(exotic, Does.Not.Contain(WeaponConstants.ShiftersSorrow));
                Assert.That(exotic, Does.Not.Contain(WeaponConstants.SunBlade));
                Assert.That(exotic, Does.Not.Contain(WeaponConstants.NetOfSnaring));
            }

            Assert.That(exotic.Count(), Is.EqualTo(total));

            var simple = WeaponConstants.GetAllSimple(specific, template);
            Assert.That(exotic.Intersect(simple), Is.Empty);

            var martial = WeaponConstants.GetAllMartial(specific, template);
            Assert.That(exotic.Intersect(martial), Is.Empty.Or.EqualTo(new[] { WeaponConstants.SunBlade }));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void AllLightWeapons(bool specific, bool template)
        {
            var light = WeaponConstants.GetAllLightMelee(specific, template);

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

            var total = 17;

            if (specific)
            {
                Assert.That(light, Contains.Item(WeaponConstants.AssassinsDagger));
                Assert.That(light, Contains.Item(WeaponConstants.SwordOfSubtlety));
                Assert.That(light, Contains.Item(WeaponConstants.SunBlade));
                Assert.That(light, Contains.Item(WeaponConstants.LuckBlade));
                Assert.That(light, Contains.Item(WeaponConstants.DaggerOfVenom));

                total += 5;
            }
            else
            {
                Assert.That(light, Does.Not.Contain(WeaponConstants.AssassinsDagger));
                Assert.That(light, Does.Not.Contain(WeaponConstants.SwordOfSubtlety));
                Assert.That(light, Does.Not.Contain(WeaponConstants.SunBlade));
                Assert.That(light, Does.Not.Contain(WeaponConstants.LuckBlade));
                Assert.That(light, Does.Not.Contain(WeaponConstants.DaggerOfVenom));
            }

            if (template)
            {
                Assert.That(light, Contains.Item(WeaponConstants.Dagger_Adamantine));
                Assert.That(light, Contains.Item(WeaponConstants.Dagger_Silver));
                Assert.That(light, Contains.Item(WeaponConstants.LuckBlade0));
                Assert.That(light, Contains.Item(WeaponConstants.LuckBlade1));
                Assert.That(light, Contains.Item(WeaponConstants.LuckBlade2));
                Assert.That(light, Contains.Item(WeaponConstants.LuckBlade3));

                total += 6;
            }
            else
            {
                Assert.That(light, Does.Not.Contain(WeaponConstants.Dagger_Adamantine));
                Assert.That(light, Does.Not.Contain(WeaponConstants.Dagger_Silver));
                Assert.That(light, Does.Not.Contain(WeaponConstants.LuckBlade0));
                Assert.That(light, Does.Not.Contain(WeaponConstants.LuckBlade1));
                Assert.That(light, Does.Not.Contain(WeaponConstants.LuckBlade2));
                Assert.That(light, Does.Not.Contain(WeaponConstants.LuckBlade3));
            }

            Assert.That(light.Count(), Is.EqualTo(total));

            var melee = WeaponConstants.GetAllMelee(specific, template);
            Assert.That(light, Is.SubsetOf(melee));

            var oneHanded = WeaponConstants.GetAllOneHandedMelee(specific, template);
            Assert.That(light.Intersect(oneHanded), Is.Empty.Or.EqualTo(new[] { WeaponConstants.SunBlade }));

            var twoHanded = WeaponConstants.GetAllTwoHandedMelee(specific, template);
            Assert.That(light.Intersect(twoHanded), Is.Empty.Or.EqualTo(new[] { WeaponConstants.SunBlade }));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void AllOneHandedWeapons(bool specific, bool template)
        {
            var oneHanded = WeaponConstants.GetAllOneHandedMelee(specific, template);

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

            var total = 15;

            if (specific)
            {
                Assert.That(oneHanded, Contains.Item(WeaponConstants.TridentOfFishCommand));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.FlameTongue));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.SwordOfThePlanes));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.NineLivesStealer));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.SwordOfLifeStealing));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.MaceOfTerror));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.SylvanScimitar));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.RapierOfPuncturing));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.SunBlade));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.DwarvenThrower));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.MaceOfSmiting));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.HolyAvenger));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.Shatterspike));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.TridentOfWarning));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.CursedBackbiterSpear));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.CursedMinus2Sword));
                Assert.That(oneHanded, Contains.Item(WeaponConstants.MaceOfBlood));

                total += 17;
            }
            else
            {
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.TridentOfFishCommand));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.FlameTongue));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.SwordOfThePlanes));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.NineLivesStealer));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.SwordOfLifeStealing));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.MaceOfTerror));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.SylvanScimitar));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.RapierOfPuncturing));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.SunBlade));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.DwarvenThrower));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.MaceOfSmiting));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.HolyAvenger));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.Shatterspike));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.TridentOfWarning));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.CursedBackbiterSpear));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.CursedMinus2Sword));
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.MaceOfBlood));
            }

            if (template)
            {
                Assert.That(oneHanded, Contains.Item(WeaponConstants.Battleaxe_Adamantine));

                total += 1;
            }
            else
            {
                Assert.That(oneHanded, Does.Not.Contain(WeaponConstants.Battleaxe_Adamantine));
            }

            Assert.That(oneHanded.Count(), Is.EqualTo(total));

            var melee = WeaponConstants.GetAllMelee(specific, template);
            Assert.That(oneHanded, Is.SubsetOf(melee));

            var light = WeaponConstants.GetAllLightMelee(specific, template);
            Assert.That(oneHanded.Intersect(light), Is.Empty.Or.EqualTo(new[] { WeaponConstants.SunBlade }));

            var twoHanded = WeaponConstants.GetAllTwoHandedMelee(specific, template);

            if (specific)
                Assert.That(oneHanded.Intersect(twoHanded), Is.EquivalentTo(new[] { WeaponConstants.BastardSword, WeaponConstants.SunBlade }));
            else
                Assert.That(oneHanded.Intersect(twoHanded), Is.EquivalentTo(new[] { WeaponConstants.BastardSword }));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void TwoHandedWeapons(bool specific, bool template)
        {
            var twoHanded = WeaponConstants.GetAllTwoHandedMelee(specific, template);

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

            var total = 22;

            if (specific)
            {
                Assert.That(twoHanded, Contains.Item(WeaponConstants.ShiftersSorrow));
                Assert.That(twoHanded, Contains.Item(WeaponConstants.LifeDrinker));
                Assert.That(twoHanded, Contains.Item(WeaponConstants.SunBlade));
                Assert.That(twoHanded, Contains.Item(WeaponConstants.FrostBrand));
                Assert.That(twoHanded, Contains.Item(WeaponConstants.BerserkingSword));

                total += 5;
            }
            else
            {
                Assert.That(twoHanded, Does.Not.Contain(WeaponConstants.ShiftersSorrow));
                Assert.That(twoHanded, Does.Not.Contain(WeaponConstants.LifeDrinker));
                Assert.That(twoHanded, Does.Not.Contain(WeaponConstants.SunBlade));
                Assert.That(twoHanded, Does.Not.Contain(WeaponConstants.FrostBrand));
                Assert.That(twoHanded, Does.Not.Contain(WeaponConstants.BerserkingSword));
            }

            Assert.That(twoHanded.Count(), Is.EqualTo(total));

            var melee = WeaponConstants.GetAllMelee(specific, template);
            Assert.That(twoHanded, Is.SubsetOf(melee));

            var light = WeaponConstants.GetAllLightMelee(specific, template);
            Assert.That(twoHanded.Intersect(light), Is.Empty.Or.EqualTo(new[] { WeaponConstants.SunBlade }));

            var oneHanded = WeaponConstants.GetAllOneHandedMelee(specific, template);

            if (specific)
                Assert.That(twoHanded.Intersect(oneHanded), Is.EquivalentTo(new[] { WeaponConstants.BastardSword, WeaponConstants.SunBlade }));
            else
                Assert.That(twoHanded.Intersect(oneHanded), Is.EquivalentTo(new[] { WeaponConstants.BastardSword }));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void DoubleWeapons(bool specific, bool template)
        {
            var doubleWeapons = WeaponConstants.GetAllDouble(specific, template);

            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.Quarterstaff));
            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.OrcDoubleAxe));
            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.DireFlail));
            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.GnomeHookedHammer));
            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.TwoBladedSword));
            Assert.That(doubleWeapons, Contains.Item(WeaponConstants.DwarvenUrgrosh));

            var total = 6;

            if (specific)
            {
                Assert.That(doubleWeapons, Contains.Item(WeaponConstants.ShiftersSorrow));

                total += 1;
            }
            else
            {
                Assert.That(doubleWeapons, Does.Not.Contain(WeaponConstants.ShiftersSorrow));
            }

            Assert.That(doubleWeapons.Count(), Is.EqualTo(total));

            var melee = WeaponConstants.GetAllMelee(specific, template);
            Assert.That(doubleWeapons, Is.SubsetOf(melee));

            var twoHanded = WeaponConstants.GetAllTwoHandedMelee(specific, template);
            Assert.That(doubleWeapons, Is.SubsetOf(twoHanded));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void ReachWeapons(bool specific, bool template)
        {
            var reach = WeaponConstants.GetAllReach(specific, template);

            Assert.That(reach, Contains.Item(WeaponConstants.Longspear));
            Assert.That(reach, Contains.Item(WeaponConstants.Glaive));
            Assert.That(reach, Contains.Item(WeaponConstants.Guisarme));
            Assert.That(reach, Contains.Item(WeaponConstants.Lance));
            Assert.That(reach, Contains.Item(WeaponConstants.Ranseur));
            Assert.That(reach, Contains.Item(WeaponConstants.Whip));
            Assert.That(reach, Contains.Item(WeaponConstants.SpikedChain));
            Assert.That(reach, Contains.Item(WeaponConstants.PincerStaff));

            Assert.That(reach.Count(), Is.EqualTo(8));

            var melee = WeaponConstants.GetAllMelee(specific, template);
            Assert.That(reach, Is.SubsetOf(melee));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void ThrownWeapons(bool specific, bool template)
        {
            var thrown = WeaponConstants.GetAllThrown(specific, template);

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

            var total = 13;

            if (specific)
            {
                Assert.That(thrown, Contains.Item(WeaponConstants.JavelinOfLightning));
                Assert.That(thrown, Contains.Item(WeaponConstants.AssassinsDagger));
                Assert.That(thrown, Contains.Item(WeaponConstants.TridentOfFishCommand));
                Assert.That(thrown, Contains.Item(WeaponConstants.DaggerOfVenom));
                Assert.That(thrown, Contains.Item(WeaponConstants.TridentOfWarning));
                Assert.That(thrown, Contains.Item(WeaponConstants.CursedBackbiterSpear));
                Assert.That(thrown, Contains.Item(WeaponConstants.NetOfSnaring));

                total += 7;
            }
            else
            {
                Assert.That(thrown, Does.Not.Contain(WeaponConstants.JavelinOfLightning));
                Assert.That(thrown, Does.Not.Contain(WeaponConstants.AssassinsDagger));
                Assert.That(thrown, Does.Not.Contain(WeaponConstants.TridentOfFishCommand));
                Assert.That(thrown, Does.Not.Contain(WeaponConstants.DaggerOfVenom));
                Assert.That(thrown, Does.Not.Contain(WeaponConstants.TridentOfWarning));
                Assert.That(thrown, Does.Not.Contain(WeaponConstants.CursedBackbiterSpear));
                Assert.That(thrown, Does.Not.Contain(WeaponConstants.NetOfSnaring));
            }

            if (template)
            {
                Assert.That(thrown, Contains.Item(WeaponConstants.Dagger_Adamantine));
                Assert.That(thrown, Contains.Item(WeaponConstants.Dagger_Silver));

                total += 2;
            }
            else
            {
                Assert.That(thrown, Does.Not.Contain(WeaponConstants.Dagger_Adamantine));
                Assert.That(thrown, Does.Not.Contain(WeaponConstants.Dagger_Silver));
            }

            Assert.That(thrown.Count(), Is.EqualTo(total));

            var ranged = WeaponConstants.GetAllRanged(specific, template);
            Assert.That(thrown.Intersect(ranged), Is.EquivalentTo(thrown));
            Assert.That(thrown, Is.SubsetOf(ranged));

            var projectile = WeaponConstants.GetAllProjectile(specific, template);
            Assert.That(thrown.Intersect(projectile), Is.Empty);

            var ammunition = WeaponConstants.GetAllAmmunition(specific, template);
            Assert.That(thrown.Intersect(ammunition), Is.EqualTo(new[] { WeaponConstants.Shuriken }));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void ProjectileWeapons(bool specific, bool template)
        {
            var projectile = WeaponConstants.GetAllProjectile(specific, template);

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

            var total = 10;

            if (specific)
            {
                Assert.That(projectile, Contains.Item(WeaponConstants.Oathbow));

                total += 1;
            }
            else
            {
                Assert.That(projectile, Does.Not.Contain(WeaponConstants.Oathbow));
            }

            if (template)
            {
                Assert.That(projectile, Contains.Item(WeaponConstants.CompositePlus0Longbow));
                Assert.That(projectile, Contains.Item(WeaponConstants.CompositePlus0Shortbow));
                Assert.That(projectile, Contains.Item(WeaponConstants.CompositePlus1Longbow));
                Assert.That(projectile, Contains.Item(WeaponConstants.CompositePlus1Shortbow));
                Assert.That(projectile, Contains.Item(WeaponConstants.CompositePlus2Longbow));
                Assert.That(projectile, Contains.Item(WeaponConstants.CompositePlus2Shortbow));
                Assert.That(projectile, Contains.Item(WeaponConstants.CompositePlus3Longbow));
                Assert.That(projectile, Contains.Item(WeaponConstants.CompositePlus4Longbow));

                total += 8;
            }
            else
            {
                Assert.That(projectile, Does.Not.Contain(WeaponConstants.CompositePlus0Longbow));
                Assert.That(projectile, Does.Not.Contain(WeaponConstants.CompositePlus0Shortbow));
                Assert.That(projectile, Does.Not.Contain(WeaponConstants.CompositePlus1Longbow));
                Assert.That(projectile, Does.Not.Contain(WeaponConstants.CompositePlus1Shortbow));
                Assert.That(projectile, Does.Not.Contain(WeaponConstants.CompositePlus2Longbow));
                Assert.That(projectile, Does.Not.Contain(WeaponConstants.CompositePlus2Shortbow));
                Assert.That(projectile, Does.Not.Contain(WeaponConstants.CompositePlus3Longbow));
                Assert.That(projectile, Does.Not.Contain(WeaponConstants.CompositePlus4Longbow));
            }

            Assert.That(projectile.Count(), Is.EqualTo(total));

            var ranged = WeaponConstants.GetAllRanged(specific, template);
            Assert.That(projectile, Is.SubsetOf(ranged));

            var thrown = WeaponConstants.GetAllThrown(specific, template);
            Assert.That(projectile.Intersect(thrown), Is.Empty);

            var ammunition = WeaponConstants.GetAllAmmunition(specific, template);
            Assert.That(projectile.Intersect(ammunition), Is.Empty);
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void AmmunitionWeapons(bool specific, bool template)
        {
            var ammunition = WeaponConstants.GetAllAmmunition(specific, template);

            Assert.That(ammunition, Contains.Item(WeaponConstants.CrossbowBolt));
            Assert.That(ammunition, Contains.Item(WeaponConstants.SlingBullet));
            Assert.That(ammunition, Contains.Item(WeaponConstants.Arrow));
            Assert.That(ammunition, Contains.Item(WeaponConstants.Shuriken));

            var total = 4;

            if (specific)
            {
                Assert.That(ammunition, Contains.Item(WeaponConstants.SleepArrow));
                Assert.That(ammunition, Contains.Item(WeaponConstants.ScreamingBolt));
                Assert.That(ammunition, Contains.Item(WeaponConstants.SlayingArrow));
                Assert.That(ammunition, Contains.Item(WeaponConstants.GreaterSlayingArrow));

                total += 4;
            }
            else
            {
                Assert.That(ammunition, Does.Not.Contain(WeaponConstants.SleepArrow));
                Assert.That(ammunition, Does.Not.Contain(WeaponConstants.ScreamingBolt));
                Assert.That(ammunition, Does.Not.Contain(WeaponConstants.SlayingArrow));
                Assert.That(ammunition, Does.Not.Contain(WeaponConstants.GreaterSlayingArrow));
            }

            Assert.That(ammunition.Count(), Is.EqualTo(total));

            var ranged = WeaponConstants.GetAllRanged(specific, template);
            Assert.That(ammunition, Is.SubsetOf(ranged));

            var projectile = WeaponConstants.GetAllProjectile(specific, template);
            Assert.That(ammunition.Intersect(projectile), Is.Empty);
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void BludgeoningWeapons(bool specific, bool template)
        {
            var bludgeoning = WeaponConstants.GetAllBludgeoning(specific, template);

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

            var total = 21;

            if (specific)
            {
                Assert.That(bludgeoning, Contains.Item(WeaponConstants.MaceOfTerror));
                Assert.That(bludgeoning, Contains.Item(WeaponConstants.DwarvenThrower));
                Assert.That(bludgeoning, Contains.Item(WeaponConstants.MaceOfSmiting));
                Assert.That(bludgeoning, Contains.Item(WeaponConstants.NetOfSnaring));
                Assert.That(bludgeoning, Contains.Item(WeaponConstants.MaceOfBlood));

                total += 5;
            }
            else
            {
                Assert.That(bludgeoning, Does.Not.Contain(WeaponConstants.MaceOfTerror));
                Assert.That(bludgeoning, Does.Not.Contain(WeaponConstants.DwarvenThrower));
                Assert.That(bludgeoning, Does.Not.Contain(WeaponConstants.MaceOfSmiting));
                Assert.That(bludgeoning, Does.Not.Contain(WeaponConstants.NetOfSnaring));
                Assert.That(bludgeoning, Does.Not.Contain(WeaponConstants.MaceOfBlood));
            }

            Assert.That(bludgeoning.Count(), Is.EqualTo(total));
        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void PiercingWeapons(bool specific, bool template)
        {
            var piercing = WeaponConstants.GetAllPiercing(specific, template);

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

            var total = 34;

            if (specific)
            {
                Assert.That(piercing, Contains.Item(WeaponConstants.SleepArrow));
                Assert.That(piercing, Contains.Item(WeaponConstants.ScreamingBolt));
                Assert.That(piercing, Contains.Item(WeaponConstants.JavelinOfLightning));
                Assert.That(piercing, Contains.Item(WeaponConstants.SlayingArrow));
                Assert.That(piercing, Contains.Item(WeaponConstants.AssassinsDagger));
                Assert.That(piercing, Contains.Item(WeaponConstants.TridentOfFishCommand));
                Assert.That(piercing, Contains.Item(WeaponConstants.SwordOfSubtlety));
                Assert.That(piercing, Contains.Item(WeaponConstants.Oathbow));
                Assert.That(piercing, Contains.Item(WeaponConstants.RapierOfPuncturing));
                Assert.That(piercing, Contains.Item(WeaponConstants.LuckBlade));
                Assert.That(piercing, Contains.Item(WeaponConstants.GreaterSlayingArrow));
                Assert.That(piercing, Contains.Item(WeaponConstants.DaggerOfVenom));
                Assert.That(piercing, Contains.Item(WeaponConstants.TridentOfWarning));
                Assert.That(piercing, Contains.Item(WeaponConstants.CursedBackbiterSpear));

                total += 14;
            }
            else
            {
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.SleepArrow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.ScreamingBolt));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.JavelinOfLightning));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.SlayingArrow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.AssassinsDagger));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.TridentOfFishCommand));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.SwordOfSubtlety));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.Oathbow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.RapierOfPuncturing));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.LuckBlade));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.GreaterSlayingArrow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.DaggerOfVenom));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.TridentOfWarning));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.CursedBackbiterSpear));
            }

            if (template)
            {
                Assert.That(piercing, Contains.Item(WeaponConstants.Dagger_Adamantine));
                Assert.That(piercing, Contains.Item(WeaponConstants.Dagger_Silver));
                Assert.That(piercing, Contains.Item(WeaponConstants.CompositePlus0Longbow));
                Assert.That(piercing, Contains.Item(WeaponConstants.CompositePlus0Shortbow));
                Assert.That(piercing, Contains.Item(WeaponConstants.CompositePlus1Longbow));
                Assert.That(piercing, Contains.Item(WeaponConstants.CompositePlus1Shortbow));
                Assert.That(piercing, Contains.Item(WeaponConstants.CompositePlus2Longbow));
                Assert.That(piercing, Contains.Item(WeaponConstants.CompositePlus2Shortbow));
                Assert.That(piercing, Contains.Item(WeaponConstants.CompositePlus3Longbow));
                Assert.That(piercing, Contains.Item(WeaponConstants.CompositePlus4Longbow));
                Assert.That(piercing, Contains.Item(WeaponConstants.LuckBlade0));
                Assert.That(piercing, Contains.Item(WeaponConstants.LuckBlade1));
                Assert.That(piercing, Contains.Item(WeaponConstants.LuckBlade2));
                Assert.That(piercing, Contains.Item(WeaponConstants.LuckBlade3));

                total += 14;
            }
            else
            {
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.Dagger_Adamantine));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.Dagger_Silver));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.CompositePlus0Longbow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.CompositePlus0Shortbow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.CompositePlus1Longbow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.CompositePlus1Shortbow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.CompositePlus2Longbow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.CompositePlus2Shortbow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.CompositePlus3Longbow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.CompositePlus4Longbow));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.LuckBlade0));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.LuckBlade1));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.LuckBlade2));
                Assert.That(piercing, Does.Not.Contain(WeaponConstants.LuckBlade3));
            }

            Assert.That(piercing.Count(), Is.EqualTo(total));

        }

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void SlashingWeapons(bool specific, bool template)
        {
            var slashing = WeaponConstants.GetAllSlashing(specific, template);

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

            var total = 22;

            if (specific)
            {
                Assert.That(slashing, Contains.Item(WeaponConstants.AssassinsDagger));
                Assert.That(slashing, Contains.Item(WeaponConstants.ShiftersSorrow));
                Assert.That(slashing, Contains.Item(WeaponConstants.FlameTongue));
                Assert.That(slashing, Contains.Item(WeaponConstants.SwordOfThePlanes));
                Assert.That(slashing, Contains.Item(WeaponConstants.NineLivesStealer));
                Assert.That(slashing, Contains.Item(WeaponConstants.SwordOfLifeStealing));
                Assert.That(slashing, Contains.Item(WeaponConstants.LifeDrinker));
                Assert.That(slashing, Contains.Item(WeaponConstants.SylvanScimitar));
                Assert.That(slashing, Contains.Item(WeaponConstants.SunBlade));
                Assert.That(slashing, Contains.Item(WeaponConstants.FrostBrand));
                Assert.That(slashing, Contains.Item(WeaponConstants.HolyAvenger));
                Assert.That(slashing, Contains.Item(WeaponConstants.LuckBlade));
                Assert.That(slashing, Contains.Item(WeaponConstants.Shatterspike));
                Assert.That(slashing, Contains.Item(WeaponConstants.DaggerOfVenom));
                Assert.That(slashing, Contains.Item(WeaponConstants.BerserkingSword));
                Assert.That(slashing, Contains.Item(WeaponConstants.CursedMinus2Sword));

                total += 16;
            }
            else
            {
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.AssassinsDagger));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.ShiftersSorrow));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.FlameTongue));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.SwordOfThePlanes));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.NineLivesStealer));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.SwordOfLifeStealing));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.LifeDrinker));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.SylvanScimitar));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.SunBlade));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.FrostBrand));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.HolyAvenger));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.LuckBlade));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.Shatterspike));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.DaggerOfVenom));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.BerserkingSword));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.CursedMinus2Sword));
            }

            if (template)
            {
                Assert.That(slashing, Contains.Item(WeaponConstants.Dagger_Adamantine));
                Assert.That(slashing, Contains.Item(WeaponConstants.Dagger_Silver));
                Assert.That(slashing, Contains.Item(WeaponConstants.Battleaxe_Adamantine));

                total += 3;
            }
            else
            {
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.Dagger_Adamantine));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.Dagger_Silver));
                Assert.That(slashing, Does.Not.Contain(WeaponConstants.Battleaxe_Adamantine));
            }

            Assert.That(slashing.Count(), Is.EqualTo(total));

        }
    }
}