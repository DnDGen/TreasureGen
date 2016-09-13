using System.Collections.Generic;

namespace TreasureGen.Items
{
    public static class WeaponConstants
    {
        public const string Dagger = "Dagger";
        public const string Greataxe = "Greataxe";
        public const string Greatsword = "Greatsword";
        public const string Kama = "Kama";
        public const string Longsword = "Longsword";
        public const string LightMace = "Light mace";
        public const string HeavyMace = "Heavy mace";
        public const string Nunchaku = "Nunchaku";
        public const string Quarterstaff = "Quarterstaff";
        public const string Rapier = "Rapier";
        public const string Scimitar = "Scimitar";
        public const string Shortspear = "Shortspear";
        public const string Siangham = "Siangham";
        public const string BastardSword = "Bastard sword";
        public const string ShortSword = "Short sword";
        public const string DwarvenWaraxe = "Dwarven waraxe";
        public const string OrcDoubleAxe = "Orc double axe";
        public const string Battleaxe = "Battleaxe";
        public const string SpikedChain = "Spiked chain";
        public const string Club = "Club";
        public const string HandCrossbow = "Hand crossbow";
        public const string HeavyRepeatingCrossbow = "Heavy repeating crossbow";
        public const string LightRepeatingCrossbow = "Light repeating crossbow";
        public const string PunchingDagger = "Punching dagger";
        public const string Falchion = "Falchion";
        public const string DireFlail = "Dire flail";
        public const string HeavyFlail = "Heavy flail";
        public const string LightFlail = "Light flail";
        public const string Gauntlet = "Gauntlet";
        public const string SpikedGauntlet = "Spiked gauntlet";
        public const string Glaive = "Glaive";
        public const string Greatclub = "Greatclub";
        public const string Guisarme = "Guisarme";
        public const string Halberd = "Halberd";
        public const string Halfspear = "Halfspear";
        public const string GnomeHookedHammer = "Gnome hooked hammer";
        public const string LightHammer = "Light hammer";
        public const string Handaxe = "Handaxe";
        public const string Kukri = "Kukri";
        public const string Lance = "Lance";
        public const string Longspear = "Longspear";
        public const string Morningstar = "Morningstar";
        public const string Net = "Net";
        public const string HeavyPick = "Heavy pick";
        public const string LightPick = "Light pick";
        public const string Ranseur = "Ranseur";
        public const string Sap = "Sap";
        public const string Scythe = "Scythe";
        public const string Shuriken = "Shuriken";
        public const string Sickle = "Sickle";
        public const string TwoBladedSword = "Two-bladed sword";
        public const string Trident = "Trident";
        public const string DwarvenUrgrosh = "Dwarven urgrosh";
        public const string Warhammer = "Warhammer";
        public const string Whip = "Whip";
        public const string Arrow = "Arrow";
        public const string CrossbowBolt = "Crossbow bolt";
        public const string SlingBullet = "Sling bullet";
        public const string ThrowingAxe = "Throwing axe";
        public const string HeavyCrossbow = "Heavy crossbow";
        public const string LightCrossbow = "Light crossbow";
        public const string Dart = "Dart";
        public const string Javelin = "Javelin";
        public const string Shortbow = "Shortbow";
        public const string CompositeShortbow = "Composite shortbow";
        public const string CompositePlus0Shortbow = "Composite (+0) shortbow";
        public const string CompositePlus1Shortbow = "Composite (+1) shortbow";
        public const string CompositePlus2Shortbow = "Composite (+2) shortbow";
        public const string Sling = "Sling";
        public const string Longbow = "Longbow";
        public const string CompositeLongbow = "Composite longbow";
        public const string CompositePlus0Longbow = "Composite (+0) longbow";
        public const string CompositePlus1Longbow = "Composite (+1) longbow";
        public const string CompositePlus2Longbow = "Composite (+2) longbow";
        public const string CompositePlus3Longbow = "Composite (+3) longbow";
        public const string CompositePlus4Longbow = "Composite (+4) longbow";
        public const string SleepArrow = "Sleep arrow";
        public const string ScreamingBolt = "Screaming bolt";
        public const string SilverDagger = "Silver dagger";
        public const string JavelinOfLightning = "Javelin of lightning";
        public const string SlayingArrow = "Slaying arrow";
        public const string AssassinsDagger = "Assassin's dagger";
        public const string ShiftersSorrow = "Shifter's sorrow";
        public const string TridentOfFishCommand = "Trident of fish command";
        public const string FlameTongue = "Flame tongue";
        public const string LuckBlade0 = "Luck blade (0 wishes)";
        public const string LuckBlade1 = "Luck blade (1 wish)";
        public const string LuckBlade2 = "Luck blade (2 wishes)";
        public const string LuckBlade3 = "Luck blade (3 wishes)";
        public const string SwordOfSubtlety = "Sword of subtlety";
        public const string SwordOfThePlanes = "Sword of the planes";
        public const string NineLivesStealer = "Nine lives stealer";
        public const string SwordOfLifeStealing = "Sword of life stealing";
        public const string Oathbow = "Oathbow";
        public const string MaceOfTerror = "Mace of terror";
        public const string LifeDrinker = "Life-drinker";
        public const string SylvanScimitar = "Sylvan scimitar";
        public const string RapierOfPuncturing = "Rapier of puncturing";
        public const string SunBlade = "Sun blade";
        public const string FrostBrand = "Frost brand";
        public const string DwarvenThrower = "Dwarven thrower";
        public const string MaceOfSmiting = "Mace of smiting";
        public const string HolyAvenger = "Holy avenger";
        public const string LuckBlade = "Luck blade";
        public const string GreaterSlayingArrow = "Greater slaying arrow";
        public const string Shatterspike = "Shatterspike";
        public const string DaggerOfVenom = "Dagger of venom";
        public const string TridentOfWarning = "Trident of warning";
        public const string CursedMinus2Sword = "Cursed -2 sword";
        public const string CursedBackbiterSpear = "Cursed backbiter spear";
        public const string NetOfSnaring = "Net of snaring";
        public const string MaceOfBlood = "Mace of blood";
        public const string BerserkingSword = "Berserking sword";

        public static IEnumerable<string> GetAllWeapons()
        {
            return new[]
            {
                Dagger,
                Greataxe,
                Greatsword,
                Kama,
                Longsword,
                LightMace,
                HeavyMace,
                Nunchaku,
                Quarterstaff,
                Rapier,
                Scimitar,
                Shortspear,
                Siangham,
                BastardSword,
                ShortSword,
                DwarvenWaraxe,
                OrcDoubleAxe,
                Battleaxe,
                SpikedChain,
                Club,
                HandCrossbow,
                HeavyRepeatingCrossbow,
                LightRepeatingCrossbow,
                PunchingDagger,
                Falchion,
                DireFlail,
                HeavyFlail,
                LightFlail,
                Gauntlet,
                SpikedGauntlet,
                Glaive,
                Greatclub,
                Guisarme,
                Halberd,
                Halfspear,
                GnomeHookedHammer,
                LightHammer,
                Handaxe,
                Kukri,
                Lance,
                Longspear,
                Morningstar,
                Net,
                HeavyPick,
                LightPick,
                Ranseur,
                Sap,
                Scythe,
                Shuriken,
                Sickle,
                TwoBladedSword,
                Trident,
                DwarvenUrgrosh,
                Warhammer,
                Whip,
                Arrow,
                CrossbowBolt,
                SlingBullet,
                ThrowingAxe,
                HeavyCrossbow,
                LightCrossbow,
                Dart,
                Javelin,
                Shortbow,
                CompositeShortbow,
                Sling,
                Longbow,
                CompositeLongbow,
                SleepArrow,
                ScreamingBolt,
                JavelinOfLightning,
                SlayingArrow,
                AssassinsDagger,
                ShiftersSorrow,
                TridentOfFishCommand,
                FlameTongue,
                SwordOfSubtlety,
                SwordOfThePlanes,
                NineLivesStealer,
                SwordOfLifeStealing,
                Oathbow,
                MaceOfTerror,
                LifeDrinker,
                SylvanScimitar,
                RapierOfPuncturing,
                SunBlade,
                FrostBrand,
                DwarvenThrower,
                MaceOfSmiting,
                HolyAvenger,
                LuckBlade,
                GreaterSlayingArrow,
                Shatterspike,
                DaggerOfVenom,
                TridentOfWarning,
                BerserkingSword,
                CursedBackbiterSpear,
                CursedMinus2Sword,
                NetOfSnaring,
                MaceOfBlood
            };
        }
    }
}