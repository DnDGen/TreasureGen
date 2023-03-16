using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Items.Magical
{
    public static class SpecialAbilityConstants
    {
        public const string Glamered = "Glamered";
        public const string LightFortification = "Light Fortification";
        public const string Fortification = "Fortification";
        public const string ModerateFortification = "Moderate Fortification";
        public const string HeavyFortification = "Heavy Fortification";
        public const string Slick = "Slick";
        public const string Shadow = "Shadow";
        public const string SilentMoves = "Silent Moves";
        public const string ImprovedSlick = "Improved Slick";
        public const string ImprovedShadow = "Improved Shadow";
        public const string ImprovedSilentMoves = "Improved Silent Moves";
        public const string GreaterSlick = "Greater Slick";
        public const string GreaterShadow = "Greater Shadow";
        public const string GreaterSilentMoves = "Greater Silent Moves";
        public const string SpellResistance = "Spell Resistance";
        public const string SpellResistance13 = "Spell Resistance (13)";
        public const string SpellResistance15 = "Spell Resistance (15)";
        public const string SpellResistance17 = "Spell Resistance (17)";
        public const string SpellResistance19 = "Spell Resistance (19)";
        public const string AcidResistance = "Acid Resistance";
        public const string ColdResistance = "Cold Resistance";
        public const string ElectricityResistance = "Electricity Resistance";
        public const string FireResistance = "Fire Resistance";
        public const string SonicResistance = "Sonic Resistance";
        public const string ImprovedAcidResistance = "Improved Acid Resistance";
        public const string ImprovedColdResistance = "Improved Cold Resistance";
        public const string ImprovedElectricityResistance = "Improved Electricity Resistance";
        public const string ImprovedFireResistance = "Improved Fire Resistance";
        public const string ImprovedSonicResistance = "Improved Sonic Resistance";
        public const string GreaterAcidResistance = "Greater Acid Resistance";
        public const string GreaterColdResistance = "Greater Cold Resistance";
        public const string GreaterElectricityResistance = "Greater Electricity Resistance";
        public const string GreaterFireResistance = "Greater Fire Resistance";
        public const string GreaterSonicResistance = "Greater Sonic Resistance";
        public const string GhostTouch = "Ghost Touch";
        public const string GhostTouchWeapon = "Ghost Touch (weapon)";
        public const string GhostTouchArmor = "Ghost Touch (armor)";
        public const string Invulnerability = "Invulnerability";
        public const string Wild = "Wild";
        public const string Etherealness = "Etherealness";
        public const string UndeadControlling = "Undead Controlling";
        public const string ArrowCatching = "Arrow Catching";
        public const string ArrowDeflection = "Arrow Deflection";
        public const string Bashing = "Bashing";
        public const string Blinding = "Blinding";
        public const string Animated = "Animated";
        public const string Bane = "Bane";
        public const string DESIGNATEDFOEbane = "DESIGNATEDFOEbane";
        public const string Aberrationbane = "Aberrationbane";
        public const string Animalbane = "Animalbane";
        public const string Constructbane = "Constructbane";
        public const string Dragonbane = "Dragonbane";
        public const string Elementalbane = "Elementalbane";
        public const string Feybane = "Feybane";
        public const string Giantbane = "Giantbane";
        public const string AquaticHumanoidbane = "Aquatic-humanoidbane";
        public const string Dwarfbane = "Dwarfbane";
        public const string Elfbane = "Elfbane";
        public const string Gnollbane = "Gnollbane";
        public const string Gnomebane = "Gnomebane";
        public const string Goblinoidbane = "Goblinoidbane";
        public const string Halflingbane = "Halflingbane";
        public const string Humanbane = "Humanbane";
        public const string ReptilianHumanoidbane = "Reptilian-humanoidbane";
        public const string MagicalBeastbane = "Magical-beastbane";
        public const string Orcbane = "Orcbane";
        public const string MonstrousHumanoidbane = "Monstrous-humanoidbane";
        public const string Oozebane = "Oozebane";
        public const string AirOutsiderbane = "Air-outsiderbane";
        public const string ChaoticOutsiderbane = "Chaotic-outsiderbane";
        public const string EarthOutsiderbane = "Earth-outsiderbane";
        public const string FireOutsiderbane = "Fire-outsiderbane";
        public const string LawfulOutsiderbane = "Lawful-outsiderbane";
        public const string GoodOutsiderbane = "Good-outsiderbane";
        public const string EvilOutsiderbane = "Evil-outsiderbane";
        public const string WaterOutsiderbane = "Water-outsiderbane";
        public const string Plantbane = "Plantbane";
        public const string Undeadbane = "Undeadbane";
        public const string Verminbane = "Verminbane";
        public const string Reflecting = "Reflecting";
        public const string Distance = "Distance";
        public const string Flaming = "Flaming";
        public const string Frost = "Frost";
        public const string Shock = "Shock";
        public const string Merciful = "Merciful";
        public const string Returning = "Returning";
        public const string Seeking = "Seeking";
        public const string Thundering = "Thundering";
        public const string Anarchic = "Anarchic";
        public const string Axiomatic = "Axiomatic";
        public const string Disruption = "Disruption";
        public const string FlamingBurst = "Flaming Burst";
        public const string IcyBurst = "Icy Burst";
        public const string ShockingBurst = "Shocking Burst";
        public const string Holy = "Holy";
        public const string Unholy = "Unholy";
        public const string Wounding = "Wounding";
        public const string Speed = "Speed";
        public const string Dancing = "Dancing";
        public const string Vorpal = "Vorpal";
        public const string BrilliantEnergy = "Brilliant Energy";
        public const string Defending = "Defending";
        public const string Keen = "Keen";
        public const string KiFocus = "Ki Focus";
        public const string MightyCleaving = "Mighty Cleaving";
        public const string SpellStoring = "Spell Storing";
        public const string Vicious = "Vicious";
        public const string Throwing = "Throwing";
        public const string Shapeshifterbane = "Shapeshifterbane";

        public static IEnumerable<string> GetAllAbilities(bool withAlternateNames)
        {
            var abilities = new[]
            {
                Glamered,
                LightFortification,
                ModerateFortification,
                HeavyFortification,
                Slick,
                Shadow,
                SilentMoves,
                ImprovedSlick,
                ImprovedShadow,
                ImprovedSilentMoves,
                GreaterSlick,
                GreaterShadow,
                GreaterSilentMoves,
                SpellResistance13,
                SpellResistance15,
                SpellResistance17,
                SpellResistance19,
                AcidResistance,
                ColdResistance,
                ElectricityResistance,
                FireResistance,
                SonicResistance,
                ImprovedAcidResistance,
                ImprovedColdResistance,
                ImprovedElectricityResistance,
                ImprovedFireResistance,
                ImprovedSonicResistance,
                GreaterAcidResistance,
                GreaterColdResistance,
                GreaterElectricityResistance,
                GreaterFireResistance,
                GreaterSonicResistance,
                GhostTouchWeapon,
                GhostTouchArmor,
                Invulnerability,
                Wild,
                Etherealness,
                UndeadControlling,
                ArrowCatching,
                ArrowDeflection,
                Bashing,
                Blinding,
                Animated,
                Aberrationbane,
                Animalbane,
                Constructbane,
                Dragonbane,
                Elementalbane,
                Feybane,
                Giantbane,
                AquaticHumanoidbane,
                Dwarfbane,
                Elfbane,
                Gnollbane,
                Gnomebane,
                Goblinoidbane,
                Halflingbane,
                Humanbane,
                ReptilianHumanoidbane,
                MagicalBeastbane,
                Orcbane,
                MonstrousHumanoidbane,
                Oozebane,
                AirOutsiderbane,
                ChaoticOutsiderbane,
                EarthOutsiderbane,
                FireOutsiderbane,
                LawfulOutsiderbane,
                GoodOutsiderbane,
                EvilOutsiderbane,
                WaterOutsiderbane,
                Plantbane,
                Undeadbane,
                Verminbane,
                Reflecting,
                Distance,
                Flaming,
                Frost,
                Shock,
                Merciful,
                Returning,
                Seeking,
                Thundering,
                Anarchic,
                Axiomatic,
                Disruption,
                FlamingBurst,
                IcyBurst,
                ShockingBurst,
                Holy,
                Unholy,
                Wounding,
                Speed,
                Dancing,
                Vorpal,
                BrilliantEnergy,
                Defending,
                Keen,
                KiFocus,
                MightyCleaving,
                SpellStoring,
                Vicious,
                Throwing,
                Shapeshifterbane,
            };

            if (!withAlternateNames)
                return abilities;

            var alternates = new[]
            {
                SpellResistance,
                GhostTouch,
                Bane,
                DESIGNATEDFOEbane,
                Fortification,
            };

            return abilities.Union(alternates);
        }
    }
}