using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Generators.Items.Mundane
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