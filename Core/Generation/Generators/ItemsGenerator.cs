using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class ItemsGenerator : IItemsGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IDice dice;
        private IPowerItemGenerator powerItemGenerator;

        public ItemsGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider, IDice dice,
            IPowerItemGenerator powerItemGenerator)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
            this.powerItemGenerator = powerItemGenerator;
        }

        public IEnumerable<Item> GenerateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Items", level);
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult(tableName);

            var amount = dice.Roll(typeAndAmountResult.RollToDetermineAmount);
            var items = new List<Item>();

            while (amount-- > 0)
            {
                var item = powerItemGenerator.GenerateAtPower(typeAndAmountResult.Type);
                items.Add(item);
            }

            return items;
        }
    }
}