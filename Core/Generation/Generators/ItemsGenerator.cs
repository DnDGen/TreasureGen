using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class ItemsGenerator : IItemsGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IPowerItemGenerator powerItemGenerator;

        public ItemsGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider,
            IPowerItemGenerator powerItemGenerator)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.powerItemGenerator = powerItemGenerator;
        }

        public IEnumerable<Item> GenerateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Items", level);
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult(tableName);

            var items = new List<Item>();
            if (typeAndAmountResult.Amount == 0)
                return items;

            var amount = typeAndAmountResult.Amount;
            while (amount-- > 0)
            {
                var item = powerItemGenerator.GenerateAtPower(typeAndAmountResult.Type);
                items.Add(item);
            }

            return items;
        }
    }
}