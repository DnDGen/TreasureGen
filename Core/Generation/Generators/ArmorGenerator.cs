using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class ArmorGenerator : IGearGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;

        public ArmorGenerator(IPercentileResultProvider percentileResultProvider, ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
        }

        public Gear GenerateAtPower(String power)
        {
            var tableName = String.Format("{0}Armor", power);
            var result = percentileResultProvider.GetPercentileResult(tableName);

            var gear = new Gear();

            if (result == ItemsConstants.Gear.Traits.Darkwood)
            {
                gear.Name = percentileResultProvider.GetPercentileResult("DarkwoodShields");
                gear.Traits.Add(ItemsConstants.Gear.Traits.Darkwood);
            }
            else if (result == "Masterwork shield")
            {
                gear.Name = percentileResultProvider.GetPercentileResult("MasterworkShields");
                gear.Traits.Add(ItemsConstants.Gear.Traits.Masterwork);
            }
            else if (result.StartsWith(ItemsConstants.Gear.Traits.Masterwork, StringComparison.InvariantCultureIgnoreCase))
            {
                gear.Name = result.Replace("Masterwork ", String.Empty).Replace("masterwork ", String.Empty);
                gear.Traits.Add(ItemsConstants.Gear.Traits.Masterwork);
            }
            else
            {
                gear.Name = result;
            }

            var size = percentileResultProvider.GetPercentileResult("ArmorSizes");
            gear.Traits.Add(size);

            return gear;
        }
    }
}