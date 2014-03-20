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
            var roll = dice.Percentile();
            return percentileSelector.SelectFrom("SpellTypes", roll);
        }

        public Int32 GenerateLevel(String power)
        {
            var tableName = String.Format("{0}SpellLevels", power);
            var roll = dice.Percentile();
            var result = percentileSelector.SelectFrom(tableName, roll);
            return Convert.ToInt32(result);
        }

        public String Generate(String spellType, Int32 level)
        {
            var tableName = String.Format("Level{0}{1}Spells", level, spellType);
            var roll = dice.Percentile();
            var spell = percentileSelector.SelectFrom(tableName, roll);
            return String.Format("{0} ({1})", spell, spellType);
        }
    }
}