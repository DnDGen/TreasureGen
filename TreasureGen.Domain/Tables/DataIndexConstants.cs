namespace TreasureGen.Domain.Tables
{
    internal static class DataIndexConstants
    {
        public static class Armor
        {
            public const int ArmorBonus = 0;
            public const int ArmorCheckPenalty = 1;
            public const int MaxDexterityBonus = 2;
        }

        public static class Weapon
        {
            public const int DamageType = 0;
            public const int ThreatRange = 1;
            public const int CriticalMultiplier = 2;
        }

        public static class Intelligence
        {
            public const int GreaterPowersCount = 2;
            public const int LesserPowersCount = 1;
            public const int Senses = 0;
        }

        public static class Range
        {
            public const int Maximum = 1;
            public const int Minimum = 0;
        }

        public static class SpecialAbility
        {
            public const int BaseName = 1;
            public const int BonusEquivalent = 0;
            public const int Power = 2;
        }
    }
}
