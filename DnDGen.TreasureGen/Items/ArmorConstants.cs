using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Items
{
    public static class ArmorConstants
    {
        public const string PaddedArmor = "Padded armor";
        public const string LeatherArmor = "Leather armor";
        public const string StuddedLeatherArmor = "Studded leather armor";
        public const string ChainShirt = "Chain shirt";
        public const string HideArmor = "Hide armor";
        public const string ScaleMail = "Scale mail";
        public const string Chainmail = "Chainmail";
        public const string Breastplate = "Breastplate";
        public const string SplintMail = "Splint mail";
        public const string BandedMail = "Banded mail";
        public const string HalfPlate = "Half-plate";
        public const string FullPlate = "Full plate";
        public const string Buckler = "Buckler";
        public const string LightWoodenShield = "Light wooden shield";
        public const string LightSteelShield = "Light steel shield";
        public const string HeavyWoodenShield = "Heavy wooden shield";
        public const string HeavySteelShield = "Heavy steel shield";
        public const string TowerShield = "Tower shield";
        public const string ElvenChain = "Elven chain";
        public const string RhinoHide = "Rhino hide";
        public const string DwarvenPlate = "Dwarven plate";
        public const string BandedMailOfLuck = "Banded mail of luck";
        public const string CelestialArmor = "Celestial armor";
        public const string PlateArmorOfTheDeep = "Plate armor of the deep";
        public const string BreastplateOfCommand = "Breastplate of command";
        public const string FullPlateOfSpeed = "Full plate of speed";
        public const string DemonArmor = "Demon armor";
        public const string CastersShield = "Caster's shield";
        public const string SpinedShield = "Spined shield";
        public const string LionsShield = "Lion's shield";
        public const string WingedShield = "Winged shield";
        public const string AbsorbingShield = "Absorbing shield";
        public const string ArmorOfRage = "Armor of rage";
        public const string ArmorOfArrowAttraction = "Armor of arrow attraction";

        public static IEnumerable<string> GetAllArmorsAndShields(bool includeSpecific)
        {
            var armors = GetAllArmors(includeSpecific);
            var shields = GetAllShields(includeSpecific);

            return armors.Union(shields);
        }

        public static IEnumerable<string> GetAllSpecificArmorsAndShields()
        {
            var armors = GetAllSpecificArmors();
            var shields = GetAllSpecificShields();

            return armors.Union(shields);
        }

        public static IEnumerable<string> GetAllSpecificArmors()
        {
            return new[]
            {
                ElvenChain,
                CelestialArmor,
                RhinoHide,
                BreastplateOfCommand,
                DwarvenPlate,
                BandedMailOfLuck,
                PlateArmorOfTheDeep,
                FullPlateOfSpeed,
                DemonArmor,
                ArmorOfArrowAttraction,
                ArmorOfRage
            };
        }

        public static IEnumerable<string> GetAllSpecificShields()
        {
            return new[]
            {
                CastersShield,
                SpinedShield,
                LionsShield,
                WingedShield,
                AbsorbingShield,
            };
        }

        public static IEnumerable<string> GetAllShields(bool includeSpecific)
        {
            IEnumerable<string> shields = new[]
            {
                Buckler,
                LightWoodenShield,
                LightSteelShield,
                HeavyWoodenShield,
                HeavySteelShield,
                TowerShield,
                CastersShield,
                SpinedShield,
                LionsShield,
                WingedShield,
                AbsorbingShield,
            };

            if (!includeSpecific)
            {
                var specific = GetAllSpecificShields();
                shields = shields.Except(specific);
            }

            return shields;
        }

        public static IEnumerable<string> GetAllArmors(bool includeSpecific)
        {
            var light = GetAllLightArmors(includeSpecific);
            var medium = GetAllMediumArmors(includeSpecific);
            var heavy = GetAllHeavyArmors(includeSpecific);

            return light.Union(medium).Union(heavy);
        }

        public static IEnumerable<string> GetAllLightArmors(bool includeSpecific)
        {
            IEnumerable<string> armors = new[]
            {
                PaddedArmor,
                LeatherArmor,
                StuddedLeatherArmor,
                ChainShirt,
                ElvenChain,
                CelestialArmor,
            };

            if (!includeSpecific)
            {
                var specific = GetAllSpecificArmors();
                armors = armors.Except(specific);
            }

            return armors;
        }

        public static IEnumerable<string> GetAllMediumArmors(bool includeSpecific)
        {
            IEnumerable<string> armors = new[]
            {
                HideArmor,
                ScaleMail,
                Chainmail,
                Breastplate,
                RhinoHide,
                BreastplateOfCommand,
            };

            if (!includeSpecific)
            {
                var specific = GetAllSpecificArmors();
                armors = armors.Except(specific);
            }

            return armors;
        }

        public static IEnumerable<string> GetAllHeavyArmors(bool includeSpecific)
        {
            IEnumerable<string> armors = new[]
            {
                SplintMail,
                BandedMail,
                HalfPlate,
                FullPlate,
                DwarvenPlate,
                BandedMailOfLuck,
                PlateArmorOfTheDeep,
                FullPlateOfSpeed,
                DemonArmor,
                ArmorOfArrowAttraction,
                ArmorOfRage
            };

            if (!includeSpecific)
            {
                var specific = GetAllSpecificArmors();
                armors = armors.Except(specific);
            }

            return armors;
        }
    }
}