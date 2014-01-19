using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class ItemsFactory : IItemsFactory
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IDice dice;
        private IPowerFactoryFactory powerFactoryFactory;

        public ItemsFactory(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider, IDice dice,
            IPowerFactoryFactory powerFactoryFactory)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
            this.powerFactoryFactory = powerFactoryFactory;
        }

        public IEnumerable<Item> CreateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Items", level);
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.GetTypeAndAmountPercentileResult(tableName);

            var amount = dice.Roll(typeAndAmountResult.RollToDetermineAmount);
            var powerFactory = powerFactoryFactory.CreateWith(typeAndAmountResult.Type);

            var items = new List<Item>();

            while (amount-- > 0)
            {
                var item = powerFactory.Create();
                items.Add(item);
            }

            return items;
        }
    }
}