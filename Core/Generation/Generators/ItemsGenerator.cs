using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class ItemsGenerator : IItemsGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IMundaneItemGenerator mundaneItemGenerator;
        private IPercentileResultProvider percentileResultProvider;
        private IMagicalGearGeneratorFactory magicalGearGeneratorFactory;
        private IMagicalItemGeneratorFactory magicalItemGeneratorFactory;
        private ICurseGenerator curseGenerator;

        public ItemsGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider,
            IMundaneItemGenerator mundaneItemGenerator, IPercentileResultProvider percentileResultProvider,
            IMagicalGearGeneratorFactory magicalGearGeneratorFactory, IMagicalItemGeneratorFactory magicalItemGeneratorFactory,
            ICurseGenerator curseGenerator)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.mundaneItemGenerator = mundaneItemGenerator;
            this.percentileResultProvider = percentileResultProvider;
            this.magicalGearGeneratorFactory = magicalGearGeneratorFactory;
            this.magicalItemGeneratorFactory = magicalItemGeneratorFactory;
            this.curseGenerator = curseGenerator;
        }

        public IEnumerable<Item> GenerateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Items", level);
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.GetResultFrom(tableName);
            var items = new List<Item>();
            var amount = typeAndAmountResult.Amount;

            while (amount-- > 0)
            {
                var item = GenerateAtPower(typeAndAmountResult.Type);
                items.Add(item);
            }

            return items;
        }

        public Item GenerateAtPower(String power)
        {
            if (power == PowerConstants.Mundane)
                return mundaneItemGenerator.Generate();

            return GenerateMagicalItemAtPower(power);
        }

        private Item GenerateMagicalItemAtPower(String power)
        {
            var tableName = String.Format("{0}Items", power);
            var type = percentileResultProvider.GetResultFrom(tableName);

            TraitItem item;
            if (type == ItemTypeConstants.Armor || type == ItemTypeConstants.Weapon)
                item = GenerateMagicalGearAtPower(type, power);
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

        private TraitItem GenerateMagicalGearAtPower(String type, String power)
        {
            var powerGearGenerator = magicalGearGeneratorFactory.CreateWith(type);
            return powerGearGenerator.GenerateAtPower(power);
        }

        private TraitItem GenerateMagicalItemAtPower(String type, String power)
        {
            var magicalItemGenerator = magicalItemGeneratorFactory.CreateWith(type);
            return magicalItemGenerator.GenerateAtPower(power);
        }
    }
}