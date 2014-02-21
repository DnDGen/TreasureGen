using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class WondrousItemGenerator : IMagicalItemGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IMagicalItemTraitsGenerator traitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;

        public WondrousItemGenerator(IPercentileResultProvider percentileResultProvider,
            IMagicalItemTraitsGenerator traitsGenerator, IIntelligenceGenerator intelligenceGenerator)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.traitsGenerator = traitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var tablename = String.Format("{0}WondrousItems", power);
            var result = percentileResultProvider.GetResultFrom(tablename);

            var item = new Item();
            item.Name = result;
            item.Magic[Magic.Intelligence] = intelligenceGenerator.GenerateFor(ItemTypeConstants.WondrousItem);

            var traits = traitsGenerator.GenerateFor(ItemTypeConstants.WondrousItem);
            item.Traits.AddRange(traits);

            return item;
        }
    }
}