using System.Collections.Generic;

namespace TreasureGen.Items
{
    public static class TraitConstants
    {
        public const string Masterwork = "Masterwork";
        public const string Darkwood = "Darkwood";
        public const string Small = "Small";
        public const string Medium = "Medium";
        public const string Large = "Large";
        public const string Adamantine = "Adamantine";
        public const string Dragonhide = "Dragonhide";
        public const string ColdIron = "Cold iron";
        public const string Mithral = "Mithral";
        public const string AlchemicalSilver = "Alchemical silver";
        public const string Markings = "Markings provide a clue to its function";
        public const string ShedsLight = "Sheds light";

        public static IEnumerable<string> GetSpecialMaterials()
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