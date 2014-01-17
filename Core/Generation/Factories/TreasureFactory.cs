using System;
using EquipmentGen.Core.Data;
using EquipmentGen.Core.Generation.Factories.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class TreasureFactory : ITreasureFactory
    {
        private ICoinFactory coinFactory;
        private IGoodsFactory goodsFactory;
        private IItemsFactory itemsFactory;

        public TreasureFactory(ICoinFactory coinFactory, IGoodsFactory goodsFactory, IItemsFactory itemsFactory)
        {
            this.coinFactory = coinFactory;
            this.goodsFactory = goodsFactory;
            this.itemsFactory = itemsFactory;
        }

        public Treasure CreateAtLevel(Int32 level)
        {
            var treasure = new Treasure();

            treasure.Coin = coinFactory.CreateAtLevel(level);
            treasure.Goods = goodsFactory.CreateAtLevel(level);
            treasure.Items = itemsFactory.CreateAtLevel(level);

            return treasure;
        }
    }
}