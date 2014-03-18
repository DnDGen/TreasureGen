using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class ToolGenerator : IToolGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IDice dice;

        public ToolGenerator(IPercentileResultProvider percentileResultProvider, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.dice = dice;
        }

        public Item Generate()
        {
            var roll = dice.Percentile();
            var result = percentileResultProvider.GetResultFrom("Tools", roll);

            var tool = new Item();
            tool.Name = result;

            return tool;
        }
    }
}