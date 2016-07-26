using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class ToolGenerator : MundaneItemGenerator
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

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var tool = template.CopyWithoutMagic();
            tool.ItemType = ItemTypeConstants.Tool;
            tool.Quantity = 1;

            return tool;
        }
    }
}