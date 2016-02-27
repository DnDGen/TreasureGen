using TreasureGen.Common;
using TreasureGen.Generators.Coins;
using TreasureGen.Generators.Goods;
using TreasureGen.Generators.Items;

namespace TreasureGen.Generators.Domain
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