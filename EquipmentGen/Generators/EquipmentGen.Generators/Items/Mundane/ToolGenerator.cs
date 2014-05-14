using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
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
            tool.Name = percentileSelector.SelectFrom("Tools");
            tool.ItemType = ItemTypeConstants.Tool;

            return tool;
        }
    }
}