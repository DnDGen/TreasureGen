using System;
using EquipmentGen.Core.Data;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class TreasureGenerator : ITreasureGenerator
    {
        private ICoinGenerator coinFactory;
        private IGoodsGenerator goodsFactory;
        private IItemsGenerator itemsFactory;

        public TreasureGenerator(ICoinGenerator coinFactory, IGoodsGenerator goodsFactory, IItemsGenerator itemsFactory)
        {
            this.coinFactory = coinFactory;
            this.goodsFactory = goodsFactory;
            this.itemsFactory = itemsFactory;
        }

        public Treasure GenerateAtLevel(Int32 level)
        {
            var treasure = new Treasure();

            treasure.Coin = coinFactory.GenerateAtLevel(level);
            treasure.Goods = goodsFactory.GenerateAtLevel(level);
            treasure.Items = itemsFactory.GenerateAtLevel(level);

            return treasure;
        }
    }
}