using System;
using D20Dice;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.Items.Magical
{
    public class SpellGenerator : ISpellGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IDice dice;

        public SpellGenerator(IPercentileResultProvider percentileResultProvider, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.dice = dice;
        }

        public String GenerateType()
        {
            var roll = dice.Percentile();
            return percentileResultProvider.GetResultFrom("SpellTypes", roll);
        }

        public Int32 GenerateLevel(String power)
        {
            var tableName = String.Format("{0}SpellLevels", power);
            var roll = dice.Percentile();
            var result = percentileResultProvider.GetResultFrom(tableName, roll);
            return Convert.ToInt32(result);
        }

        public String Generate(String spellType, Int32 level)
        {
            var tableName = String.Format("Level{0}{1}Spells", level, spellType);
            var roll = dice.Percentile();
            var spell = percentileResultProvider.GetResultFrom(tableName, roll);
            return String.Format("{0} ({1})", spell, spellType);
        }
    }
}