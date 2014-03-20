using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class ToolGenerator : IToolGenerator
    {
        private IPercentileSelector percentileSelector;
        private IDice dice;

        public ToolGenerator(IPercentileSelector percentileSelector, IDice dice)
        {
            this.percentileSelector = percentileSelector;
            this.dice = dice;
        }

        public Item Generate()
        {
            var roll = dice.Percentile();
            var result = percentileSelector.SelectFrom("Tools", roll);

            var tool = new Item();
            tool.Name = result;

            return tool;
        }
    }
}