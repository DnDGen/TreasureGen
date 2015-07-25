using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Items.Mundane
{
    public class ToolGenerator : IMundaneItemGenerator
    {
        private IPercentileSelector percentileSelector;

        public ToolGenerator(IPercentileSelector percentileSelector)
        {
            this.percentileSelector = percentileSelector;
        }

        public Item Generate()
        {
            var tool = new Item();
            tool.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.Tools);
            tool.ItemType = ItemTypeConstants.Tool;

            return tool;
        }
    }
}