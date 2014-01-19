using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class ItemsGenerator : IItemsGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IDice dice;
        private IPowerItemGeneratorFactory powerItemGeneratorFactory;

        public ItemsGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider, IDice dice,
            IPowerItemGeneratorFactory powerItemGeneratorFactory)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
            this.powerItemGeneratorFactory = powerItemGeneratorFactory;
        }

        public IEnumerable<Item> GenerateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Items", level);
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult(tableName);

            var amount = dice.Roll(typeAndAmountResult.RollToDetermineAmount);
            var powerItemGenerator = powerItemGeneratorFactory.CreateWith(typeAndAmountResult.Type);

            var items = new List<Item>();

            while (amount-- > 0)
            {
                var item = powerItemGenerator.Generate();
                items.Add(item);
            }

            return items;
        }
    }
}