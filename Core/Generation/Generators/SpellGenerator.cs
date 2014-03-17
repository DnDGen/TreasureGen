using System;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class SpellGenerator : ISpellGenerator
    {
        private IPercentileResultProvider percentileResultProvider;

        public SpellGenerator(IPercentileResultProvider percentileResultProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
        }

        public String GenerateType()
        {
            return percentileResultProvider.GetResultFrom("SpellType");
        }

        public Int32 GenerateLevel(String power)
        {
            var tableName = String.Format("{0}SpellLevel", power);
            var result = percentileResultProvider.GetResultFrom(tableName);
            return Convert.ToInt32(result);
        }

        public String Generate(String spellType, Int32 level)
        {
            var tableName = String.Format("Level{0}{1}Spells", level, spellType);
            var spell = percentileResultProvider.GetResultFrom(tableName);
            return String.Format("{0} ({1})", spell, spellType);
        }
    }
}