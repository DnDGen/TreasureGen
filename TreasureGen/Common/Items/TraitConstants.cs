using System;
using System.Collections.Generic;

namespace TreasureGen.Common.Items
{
    public static class TraitConstants
    {
        public const String Masterwork = "Masterwork";
        public const String Darkwood = "Darkwood";
        public const String Small = "Small";
        public const String Medium = "Medium";
        public const String Large = "Large";
        public const String Adamantine = "Adamantine";
        public const String Dragonhide = "Dragonhide";
        public const String ColdIron = "Cold iron";
        public const String Mithral = "Mithral";
        public const String AlchemicalSilver = "Alchemical silver";
        public const String Markings = "Markings provide a clue to its function";
        public const String ShedsLight = "Sheds light";

        public static IEnumerable<String> GetSpecialMaterials()
        {
            return new[]
            {
                Darkwood,
                Adamantine,
                Dragonhide,
                ColdIron,
                Mithral,
                AlchemicalSilver
            };
        }
    }
}