using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class ToolGenerator : IToolGenerator
    {
        private IPercentileSelector percentileResultProvider;
        private IDice dice;

        public ToolGenerator(IPercentileSelector percentileResultProvider, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.dice = dice;
        }

        public Item Generate()
        {
            var roll = dice.Percentile();
            var result = percentileResultProvider.SelectFrom("Tools", roll);

            var tool = new Item();
            tool.Name = result;

            return tool;
        }
    }
}