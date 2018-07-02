using TreasureGen.Coins;
using TreasureGen.Generators;
using TreasureGen.Goods;
using TreasureGen.Items;

namespace TreasureGen.Generators
{
    internal class TreasureGenerator : ITreasureGenerator
    {
        private readonly ICoinGenerator coinFactory;
        private readonly IGoodsGenerator goodsFactory;
        private readonly IItemsGenerator itemsFactory;

        public TreasureGenerator(ICoinGenerator coinFactory, IGoodsGenerator goodsFactory, IItemsGenerator itemsFactory)
        {
            this.coinFactory = coinFactory;
            this.goodsFactory = goodsFactory;
            this.itemsFactory = itemsFactory;
        }

        public Treasure GenerateAtLevel(int level)
        {
            var treasure = new Treasure();

            treasure.Coin = coinFactory.GenerateAtLevel(level);
            treasure.Goods = goodsFactory.GenerateAtLevel(level);
            treasure.Items = itemsFactory.GenerateAtLevel(level);

            return treasure;
        }
    }
}