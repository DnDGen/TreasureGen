using System;
using System.Collections.Generic;

namespace TreasureGen.Selectors.Domain.Decorators
{
    public static class ReplacementStringConstants
    {
        public const String DesignatedFoe = "DESIGNATEDFOE";
        public const String Gender = "GENDER";
        public const String Height = "HEIGHT";
        public const String KnowledgeCategory = "KNOWLEDGECATEGORY";
        public const String Energy = "ENERGY";
        public const String PartialAlignment = "PARTIALALIGNMENT";
        public const String FullAlignment = "FULLALIGNMENT";

        public static IEnumerable<String> GetAll()
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