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
        private ICurseGenerator curseGenerator;

        public PowerItemGenerator(IMundaneItemGenerator mundaneItemGenerator, IPercentileResultProvider percentileResultProvider,
            IPowerGearGeneratorFactory powerGearGeneratorFactory, IMagicalItemGeneratorFactory magicalItemGeneratorFactory,
            ICurseGenerator curseGenerator)
        {
            this.mundaneItemGenerator = mundaneItemGenerator;
            this.percentileResultProvider = percentileResultProvider;
            this.powerGearGeneratorFactory = powerGearGeneratorFactory;
            this.magicalItemGeneratorFactory = magicalItemGeneratorFactory;
            this.curseGenerator = curseGenerator;
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

            TraitItem item;
            if (type == ItemsConstants.ItemTypes.Armor || type == ItemsConstants.ItemTypes.Weapon)
                item = GeneratePowerGearAtPower(type, power);
            else
                item = GenerateMagicalItemAtPower(type, power);

            if (curseGenerator.HasCurse())
            {
                var curse = curseGenerator.GenerateCurseTrait();
                if (curse == "SpecificCursedItem")
                    return curseGenerator.GenerateSpecificCursedItem();

                item.Traits.Add(curse);
            }

            return item;
        }

        private TraitItem GeneratePowerGearAtPower(String type, String power)
        {
            var powerGearGenerator = powerGearGeneratorFactory.CreateWith(type);
            return powerGearGenerator.GenerateAtPower(power);
        }

        private TraitItem GenerateMagicalItemAtPower(String type, String power)
        {
            var magicalItemGenerator = magicalItemGeneratorFactory.CreateWith(type);
            return magicalItemGenerator.GenerateAtPower(power);
        }
    }
}