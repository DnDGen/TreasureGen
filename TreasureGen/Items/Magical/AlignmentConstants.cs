using System.Collections.Generic;

namespace TreasureGen.Items.Magical
{
    public static class AlignmentConstants
    {
        public const string Lawful = "Lawful";
        public const string Chaotic = "Chaotic";
        public const string Evil = "Evil";
        public const string Good = "Good";
        public const string Neutral = "Neutral";

        public static string LawfulGood
        {
            get { return string.Format("{0} {1}", Lawful, Good); }
        }

        public static string NeutralGood
        {
            get { return string.Format("{0} {1}", Neutral, Good); }
        }

        public static string ChaoticGood
        {
            get { return string.Format("{0} {1}", Chaotic, Good); }
        }

        public static string LawfulNeutral
        {
            get { return string.Format("{0} {1}", Lawful, Neutral); }
        }

        public static string TrueNeutral
        {
            get { return string.Format("True {1}", Lawful, Neutral); }
        }

        public static string ChaoticNeutral
        {
            get { return string.Format("{0} {1}", Chaotic, Neutral); }
        }

        public static string LawfulEvil
        {
            get { return string.Format("{0} {1}", Lawful, Evil); }
        }

        public static string NeutralEvil
        {
            get { return string.Format("{0} {1}", Neutral, Evil); }
        }

        public static string ChaoticEvil
        {
            get { return string.Format("{0} {1}", Chaotic, Evil); }
        }

        public static IEnumerable<string> GetAllAlignments()
        {
            return new[]
            {
                LawfulGood,
                NeutralGood,
                ChaoticGood,
                LawfulNeutral,
                TrueNeutral,
                ChaoticNeutral,
                LawfulEvil,
                NeutralEvil,
                ChaoticEvil
            };
        }

        public static IEnumerable<string> GetAllPartialAlignments()
        {
            return new[]
            {
                Lawful,
                Chaotic,
                Evil,
                Good,
                Neutral
            };
        }
    }
}