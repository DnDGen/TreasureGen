namespace DnDGen.TreasureGen.Tables
{
    internal static class DataIndexConstants
    {
        private static string[] InitializeData(int maxIndex)
        {
            var capacity = maxIndex + 1;
            var data = new string[capacity];

            for (var i = 0; i < data.Length; i++)
                data[i] = string.Empty;

            return data;
        }

        public static class Armor
        {
            public const int ArmorBonus = 0;
            public const int ArmorCheckPenalty = 1;
            public const int MaxDexterityBonus = 2;
        }

        public static class Weapon
        {
            public const int ThreatRange = 0;
            public const int CriticalMultiplier = 1;
            public const int SecondaryCriticalMultiplier = 3;
            public const int Ammunition = 2;

            internal static class DamageData
            {
                public const int RollIndex = 0;
                public const int TypeIndex = 1;
                public const int ConditionIndex = 2;

                public static string[] InitializeData()
                {
                    return DataIndexConstants.InitializeData(ConditionIndex);
                }
            }
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
