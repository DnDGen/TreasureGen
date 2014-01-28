using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class PowerArmorGenerator : IPowerGearGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider;
        private IPercentileResultProvider percentileResultProvider;
        private IGearTypesProvider gearTypesProvider;

        public PowerArmorGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider,
            IPercentileResultProvider percentileResultProvider, IGearTypesProvider gearTypesProvider)
        {
            this.typeAndAmountPercentileProvider = typeAndAmountPercentileProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.gearTypesProvider = gearTypesProvider;
        }

        public Gear GenerateAtPower(String power)
        {
            var tableName = String.Format("{0}Armor", power);
            var result = typeAndAmountPercentileProvider.GetTypeAndAmountPercentileResult(tableName);

            var armor = new Gear();
            tableName = String.Format("{0}Type", result.Type);

            armor.Name = percentileResultProvider.GetPercentileResult(tableName);
            armor.MagicalBonus = Convert.ToInt32(result.RollToDetermineAmount);
            armor.Types = gearTypesProvider.GetGearTypesFor(armor.Name);

            return armor;
        }
    }
}