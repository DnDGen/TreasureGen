using System;
using TreasureGen.Selectors.Percentiles;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Items.Magical
{
    internal class SpellGenerator : ISpellGenerator
    {
        private readonly ITreasurePercentileSelector percentileSelector;

        public SpellGenerator(ITreasurePercentileSelector percentileSelector)
        {
            this.percentileSelector = percentileSelector;
        }

        public string GenerateType()
        {
            return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.SpellTypes);
        }

        public int GenerateLevel(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpellLevels, power);
            var level = percentileSelector.SelectFrom(tableName);
            return Convert.ToInt32(level);
        }

        public string Generate(string spellType, int level)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, level, spellType);
            return percentileSelector.SelectFrom(tableName);
        }
    }
}