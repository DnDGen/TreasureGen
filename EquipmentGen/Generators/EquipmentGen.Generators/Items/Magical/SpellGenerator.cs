using System;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class SpellGenerator : ISpellGenerator
    {
        private IPercentileSelector percentileSelector;

        public SpellGenerator(IPercentileSelector percentileSelector)
        {
            this.percentileSelector = percentileSelector;
        }

        public String GenerateType()
        {
            return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.SpellTypes);
        }

        public Int32 GenerateLevel(String power)
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERSpellLevels, power);
            var level = percentileSelector.SelectFrom(tableName);
            return Convert.ToInt32(level);
        }

        public String Generate(String spellType, Int32 level)
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, level, spellType);
            return percentileSelector.SelectFrom(tableName);
        }
    }
}