using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class PowerItemGenerator : IPowerItemGenerator
    {
        private IMundaneItemGenerator mundaneItemGenerator;
        private IPercentileResultProvider percentileResultProvider;
        private IPowerGearGeneratorFactory powerGearGeneratorFactory;
        private IMagicalItemGeneratorFactory magicalItemGeneratorFactory;

        public PowerItemGenerator(IMundaneItemGenerator mundaneItemGenerator, IPercentileResultProvider percentileResultProvider,
            IPowerGearGeneratorFactory powerGearGeneratorFactory, IMagicalItemGeneratorFactory magicalItemGeneratorFactory)
        {
            this.mundaneItemGenerator = mundaneItemGenerator;
            this.percentileResultProvider = percentileResultProvider;
            this.powerGearGeneratorFactory = powerGearGeneratorFactory;
            this.magicalItemGeneratorFactory = magicalItemGeneratorFactory;
        }

        public Item GenerateAtPower(String power)
        {
            if (power == ItemsConstants.Power.Mundane)
                return mundaneItemGenerator.Generate();

            return GeneratePowerItemAtPower(power);
        }

        private Item GeneratePowerItemAtPower(String power)
        {
            var tableName = String.Format("{0}Items", power);
            var type = percentileResultProvider.GetPercentileResult(tableName);

            if (type == ItemsConstants.ItemTypes.Armor || type == ItemsConstants.ItemTypes.Weapon)
                return GeneratePowerGearAtPower(type, power);

            return GenerateMagicalItemAtPower(type, power);
        }

        private Item GeneratePowerGearAtPower(String type, String power)
        {
            var powerGearGenerator = powerGearGeneratorFactory.CreateWith(type);
            return powerGearGenerator.GenerateAtPower(power);
        }

        private Item GenerateMagicalItemAtPower(String type, String power)
        {
            var magicalItemGenerator = magicalItemGeneratorFactory.CreateWith(type);
            return magicalItemGenerator.GenerateAtPower(power);
        }
    }
}