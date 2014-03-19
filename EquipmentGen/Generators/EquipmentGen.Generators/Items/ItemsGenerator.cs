using System;
using System.Collections.Generic;
using D20Dice;
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
        private IDice dice;

        public ItemsGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider,
            IMundaneItemGenerator mundaneItemGenerator, IPercentileResultProvider percentileResultProvider,
            IMagicalGearGeneratorFactory magicalGearGeneratorFactory, IMagicalItemGeneratorFactory magicalItemGeneratorFactory,
            ICurseGenerator curseGenerator, IDice dice)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.mundaneItemGenerator = mundaneItemGenerator;
            this.percentileResultProvider = percentileResultProvider;
            this.magicalGearGeneratorFactory = magicalGearGeneratorFactory;
            this.magicalItemGeneratorFactory = magicalItemGeneratorFactory;
            this.curseGenerator = curseGenerator;
            this.dice = dice;
        }

        public IEnumerable<Item> GenerateAtLevel(Int32 level)
        {
            var roll = dice.Percentile();
            var tableName = String.Format("Level{0}Items", level);
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.GetResultFrom(tableName, roll);
            var items = new List<Item>();

            if (String.IsNullOrEmpty(typeAndAmountResult.Type))
                return items;

            var amount = dice.Roll(typeAndAmountResult.AmountToRoll);

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
            var roll = dice.Percentile();
            var tableName = String.Format("{0}Items", power);
            var type = percentileResultProvider.GetResultFrom(tableName, roll);

            Item item;
            if (type == ItemTypeConstants.Armor || type == ItemTypeConstants.Weapon)
                item = GenerateMagicalGearAtPower(type, power);
            else
                item = GenerateMagicalItemAtPower(type, power);

            if (curseGenerator.HasCurse(item.Magic))
            {
                var curse = curseGenerator.GenerateCurse();
                if (curse == "SpecificCursedItem")
                    return curseGenerator.GenerateSpecificCursedItem();

                item.Magic.Add(Magic.Curse, curse);
            }

            return item;
        }

        private Item GenerateMagicalGearAtPower(String type, String power)
        {
            var powerGearGenerator = magicalGearGeneratorFactory.CreateWith(type);
            return powerGearGenerator.GenerateAtPower(power);
        }

        private Item GenerateMagicalItemAtPower(String type, String power)
        {
            var magicalItemGenerator = magicalItemGeneratorFactory.CreateWith(type);
            return magicalItemGenerator.GenerateAtPower(power);
        }
    }
}