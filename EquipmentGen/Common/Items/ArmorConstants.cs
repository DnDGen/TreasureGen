using System;
using System.Collections.Generic;

namespace EquipmentGen.Common.Items
{
    public static class ArmorConstants
    {
        public const String PaddedArmor = "Padded armor";
        public const String LeatherArmor = "Leather armor";
        public const String StuddedLeatherArmor = "Studded leather armor";
        public const String ChainShirt = "Chain shirt";
        public const String HideArmor = "Hide armor";
        public const String ScaleMail = "Scale mail";
        public const String Chainmail = "Chainmail";
        public const String Breastplate = "Breastplate";
        public const String SplintMail = "Splint mail";
        public const String BandedMail = "Banded mail";
        public const String HalfPlate = "Half-plate";
        public const String FullPlate = "Full plate";
        public const String Buckler = "Buckler";
        public const String LightWoodenShield = "Light wooden shield";
        public const String LightSteelShield = "Light steel shield";
        public const String HeavyWoodenShield = "Heavy wooden shield";
        public const String HeavySteelShield = "Heavy steel shield";
        public const String TowerShield = "Tower shield";
        public const String ElvenChain = "Elven chain";
        public const String RhinoHide = "Rhino hide";
        public const String DwarvenPlate = "Dwarven plate";
        public const String BandedMailOfLuck = "Banded mail of luck";
        public const String CelestialArmor = "Celestial armor";
        public const String PlateArmorOfTheDeep = "Plate armor of the deep";
        public const String BreastplateOfCommand = "Breastplate of command";
        public const String FullPlateOfSpeed = "Full plate of speed";
        public const String DemonArmor = "Demon armor";
        public const String CastersShield = "Caster's shield";
        public const String SpinedShield = "Spined shield";
        public const String LionsShield = "Lion's shield";
        public const String WingedShield = "Winged shield";
        public const String AbsorbingShield = "Absorbing shield";
        public const String ArmorOfRage = "Armor of rage";
        public const String ArmorOfArrowAttraction = "Armor of arrow attraction";

        public static IEnumerable<String> GetAllArmors()
        {
            return new[]
            {
                PaddedArmor,
                LeatherArmor,
                StuddedLeatherArmor,
                ChainShirt,
                HideArmor,
                ScaleMail,
                Chainmail,
                Breastplate,
                SplintMail,
                BandedMail,
                HalfPlate,
                FullPlate,
                Buckler,
                LightWoodenShield,
                LightSteelShield,
                HeavyWoodenShield,
                HeavySteelShield,
                TowerShield,
                ElvenChain,
                RhinoHide,
                DwarvenPlate,
                BandedMailOfLuck,
                CelestialArmor,
                PlateArmorOfTheDeep, 
                BreastplateOfCommand,
                FullPlateOfSpeed,
                DemonArmor,
                CastersShield,
                SpinedShield,
                LionsShield,
                WingedShield,
                AbsorbingShield,
                ArmorOfArrowAttraction,
                ArmorOfRage
            };
        }
    }
}