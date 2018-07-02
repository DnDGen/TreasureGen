using System.Collections.Generic;

namespace TreasureGen.Selectors.Percentiles
{
    internal static class ReplacementStringConstants
    {
        public const string DesignatedFoe = "DESIGNATEDFOE";
        public const string Gender = "GENDER";
        public const string Height = "HEIGHT";
        public const string KnowledgeCategory = "KNOWLEDGECATEGORY";
        public const string Energy = "ENERGY";
        public const string PartialAlignment = "PARTIALALIGNMENT";
        public const string FullAlignment = "FULLALIGNMENT";

        public static IEnumerable<string> GetAll()
        {
            return new[]
            {
                DesignatedFoe,
                Gender,
                Height,
                KnowledgeCategory,
                Energy,
                PartialAlignment,
                FullAlignment
            };
        }
    }
}