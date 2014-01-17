using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class ItemsFactory : IItemsFactory
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;

        public ItemsFactory(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
        }

        public IEnumerable<Item> CreateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Items", level);
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult(tableName);

            var items = new List<Item>();

            return items;
        }
    }
}