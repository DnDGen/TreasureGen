using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class ToolGenerator : IToolGenerator
    {
        private IPercentileResultProvider percentileResultProvider;

        public ToolGenerator(IPercentileResultProvider percentileResultProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
        }

        public Item Generate()
        {
            var result = percentileResultProvider.GetResultFrom("Tools");

            var tool = new Item();
            tool.Name = result;

            return tool;
        }
    }
}