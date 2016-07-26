using System.Collections.Generic;

namespace TreasureGen.Items.Magical
{
    public static class RodConstants
    {
        public const string Absorption = "Rod of absorption";
        public const string FullAbsorption = "Rod of absorption (max)";
        public const string Alertness = "Rod of alertness";
        public const string Cancellation = "Rod of cancellation";
        public const string EnemyDetection = "Rod of enemy detection";
        public const string Flailing = "Rod of flailing";
        public const string FlameExtinguishing = "Rod of flame extinguishing";
        public const string ImmovableRod = "Immovable rod";
        public const string LordlyMight = "Rod of lordly might";
        public const string MetalAndMineralDetection = "Rod of metal and mineral detection";
        public const string Metamagic_Empower = "Rod of metamagic: Empower";
        public const string Metamagic_Empower_Greater = "Rod of greater metamagic: Empower";
        public const string Metamagic_Empower_Lesser = "Rod of lesser metamagic: Empower";
        public const string Metamagic_Enlarge = "Rod of metamagic: Enlarge";
        public const string Metamagic_Enlarge_Greater = "Rod of greater metamagic: Enlarge";
        public const string Metamagic_Enlarge_Lesser = "Rod of lesser metamagic: Enlarge";
        public const string Metamagic_Extend = "Rod of metamagic: Extend";
        public const string Metamagic_Extend_Greater = "Rod of greater metamagic: Extend";
        public const string Metamagic_Extend_Lesser = "Rod of lesser metamagic: Extend";
        public const string Metamagic_Maximize = "Rod of metamagic: Maximize";
        public const string Metamagic_Maximize_Greater = "Rod of greater metamagic: Maximize";
        public const string Metamagic_Maximize_Lesser = "Rod of lesser metamagic: Maximize";
        public const string Metamagic_Quicken = "Rod of metamagic: Quicken";
        public const string Metamagic_Quicken_Greater = "Rod of greater metamagic: Quicken";
        public const string Metamagic_Quicken_Lesser = "Rod of lesser metamagic: Quicken";
        public const string Metamagic_Silent = "Rod of metamagic: Silent";
        public const string Metamagic_Silent_Greater = "Rod of greater metamagic: Silent";
        public const string Metamagic_Silent_Lesser = "Rod of lesser metamagic: Silent";
        public const string Negation = "Rod of negation";
        public const string Python = "Rod of the python";
        public const string Rulership = "Rod of rulership";
        public const string Security = "Rod of security";
        public const string Splendor = "Rod of splendor";
        public const string ThunderAndLightning = "Rod of thunder and lightning";
        public const string Viper = "Rod of the viper";
        public const string Withering = "Rod of withering";
        public const string Wonder = "Rod of wonder";

        public static IEnumerable<string> GetAllRods()
        {
            return new[]
            {
                Absorption,
                Alertness,
                Cancellation,
                EnemyDetection,
                Flailing,
                FlameExtinguishing,
                ImmovableRod,
                LordlyMight,
                MetalAndMineralDetection,
                Metamagic_Empower,
                Metamagic_Empower_Greater,
                Metamagic_Empower_Lesser,
                Metamagic_Enlarge,
                Metamagic_Enlarge_Greater,
                Metamagic_Enlarge_Lesser,
                Metamagic_Extend,
                Metamagic_Extend_Greater,
                Metamagic_Extend_Lesser,
                Metamagic_Maximize,
                Metamagic_Maximize_Greater,
                Metamagic_Maximize_Lesser,
                Metamagic_Quicken,
                Metamagic_Quicken_Greater,
                Metamagic_Quicken_Lesser,
                Metamagic_Silent,
                Metamagic_Silent_Greater,
                Metamagic_Silent_Lesser,
                Negation,
                Python,
                Rulership,
                Security,
                Splendor,
                ThunderAndLightning,
                Viper,
                Withering,
                Wonder
            };
        }
    }
}