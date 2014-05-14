using System;
using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class SpellGenerator : ISpellGenerator
    {
        private IPercentileSelector percentileSelector;
        private IDice dice;

        public SpellGenerator(IPercentileSelector percentileSelector, IDice dice)
        {
            this.percentileSelector = percentileSelector;
            this.dice = dice;
        }

        public String GenerateType()
        {
            return percentileSelector.SelectFrom("SpellTypes");
        }

        public Int32 GenerateLevel(String power)
        {
            var tableName = String.Format("{0}SpellLevels", power);
            var level = percentileSelector.SelectFrom(tableName);
            return Convert.ToInt32(level);
        }

        public String Generate(String spellType, Int32 level)
        {
            var tableName = String.Format("Level{0}{1}Spells", level, spellType);
            return percentileSelector.SelectFrom(tableName);
        }
    }
}