using System;

namespace EquipmentGen.Common.Items
{
    public static class IntelligenceAlignmentConstants
    {
        public const String Lawful = "Lawful";
        public const String Chaotic = "Chaotic";
        public const String Evil = "Evil";
        public const String Good = "Good";
        public const String Neutral = "Neutral";

        public static String LawfulGood
        {
            get { return String.Format("{0} {1}", Lawful, Good); }
        }

        public static String NeutralGood
        {
            get { return String.Format("{0} {1}", Neutral, Good); }
        }

        public static String ChaoticGood
        {
            get { return String.Format("{0} {1}", Chaotic, Good); }
        }

        public static String LawfulNeutral
        {
            get { return String.Format("{0} {1}", Lawful, Neutral); }
        }

        public static String TrueNeutral
        {
            get { return String.Format("True {1}", Lawful, Neutral); }
        }

        public static String ChaoticNeutral
        {
            get { return String.Format("{0} {1}", Chaotic, Neutral); }
        }

        public static String LawfulEvil
        {
            get { return String.Format("{0} {1}", Lawful, Evil); }
        }

        public static String NeutralEvil
        {
            get { return String.Format("{0} {1}", Neutral, Evil); }
        }

        public static String ChaoticEvil
        {
            get { return String.Format("{0} {1}", Chaotic, Evil); }
        }
    }
}