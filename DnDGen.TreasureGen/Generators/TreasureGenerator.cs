using DnDGen.TreasureGen.Coins;
using DnDGen.TreasureGen.Goods;
using DnDGen.TreasureGen.Items;
using System;
using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Generators
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
            if (level < LevelLimits.Minimum || level > LevelLimits.Maximum)
                throw new ArgumentException($"Level {level} is not a valid level for treasure generation");

            var treasure = new Treasure();

            treasure.Coin = coinFactory.GenerateAtLevel(level);
            treasure.Goods = goodsFactory.GenerateAtLevel(level);
            treasure.Items = itemsFactory.GenerateRandomAtLevel(level);

            return treasure;
        }

        public async Task<Treasure> GenerateAtLevelAsync(int level)
        {
            var treasure = new Treasure();

            var coinTask = Task.Run(() => coinFactory.GenerateAtLevel(level));
            var goodsTask = goodsFactory.GenerateAtLevelAsync(level);
            var itemsTask = itemsFactory.GenerateRandomAtLevelAsync(level);

            await Task.WhenAll(coinTask, goodsTask, itemsTask);

            treasure.Coin = coinTask.Result;
            treasure.Goods = goodsTask.Result;
            treasure.Items = itemsTask.Result;

            return treasure;
        }
    }
}