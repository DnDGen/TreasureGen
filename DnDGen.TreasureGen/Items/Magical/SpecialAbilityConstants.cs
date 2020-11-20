using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Items.Magical
{
    public static class SpecialAbilityConstants
    {
        public const string Glamered = "Glamered";
        public const string LightFortification = "Light fortification";
        public const string Fortification = "Fortification";
        public const string ModerateFortification = "Moderate fortification";
        public const string HeavyFortification = "Heavy fortification";
        public const string Slick = "Slick";
        public const string Shadow = "Shadow";
        public const string SilentMoves = "Silent moves";
        public const string ImprovedSlick = "Improved slick";
        public const string ImprovedShadow = "Improved shadow";
        public const string ImprovedSilentMoves = "Improved silent moves";
        public const string GreaterSlick = "Greater slick";
        public const string GreaterShadow = "Greater shadow";
        public const string GreaterSilentMoves = "Greater silent moves";
        public const string SpellResistance = "Spell resistance";
        public const string SpellResistance13 = "Spell resistance (13)";
        public const string SpellResistance15 = "Spell resistance (15)";
        public const string SpellResistance17 = "Spell resistance (17)";
        public const string SpellResistance19 = "Spell resistance (19)";
        public const string AcidResistance = "Acid resistance";
        public const string ColdResistance = "Cold resistance";
        public const string ElectricityResistance = "Electricity resistance";
        public const string FireResistance = "Fire resistance";
        public const string SonicResistance = "Sonic resistance";
        public const string ImprovedAcidResistance = "Improved acid resistance";
        public const string ImprovedColdResistance = "Improved cold resistance";
        public const string ImprovedElectricityResistance = "Improved electricity resistance";
        public const string ImprovedFireResistance = "Improved fire resistance";
        public const string ImprovedSonicResistance = "Improved sonic resistance";
        public const string GreaterAcidResistance = "Greater acid resistance";
        public const string GreaterColdResistance = "Greater cold resistance";
        public const string GreaterElectricityResistance = "Greater electricity resistance";
        public const string GreaterFireResistance = "Greater fire resistance";
        public const string GreaterSonicResistance = "Greater sonic resistance";
        public const string GhostTouch = "Ghost touch";
        public const string GhostTouchWeapon = "Ghost touch (weapon)";
        public const string GhostTouchArmor = "Ghost touch (armor)";
        public const string Invulnerability = "Invulnerability";
        public const string Wild = "Wild";
        public const string Etherealness = "Etherealness";
        public const string UndeadControlling = "Undead controlling";
        public const string ArrowCatching = "Arrow catching";
        public const string ArrowDeflection = "Arrow deflection";
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
        public const string FlamingBurst = "Flaming burst";
        public const string IcyBurst = "Icy burst";
        public const string ShockingBurst = "Shocking burst";
        public const string Holy = "Holy";
        public const string Unholy = "Unholy";
        public const string Wounding = "Wounding";
        public const string Speed = "Speed";
        public const string Dancing = "Dancing";
        public const string Vorpal = "Vorpal";
        public const string BrilliantEnergy = "Brilliant energy";
        public const string Defending = "Defending";
        public const string Keen = "Keen";
        public const string KiFocus = "Ki focus";
        public const string MightyCleaving = "Mighty cleaving";
        public const string SpellStoring = "Spell storing";
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