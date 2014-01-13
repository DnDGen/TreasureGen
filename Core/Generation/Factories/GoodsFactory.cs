using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class GoodsFactory : IGoodsFactory
    {
        private IGoodPercentileResultProvider goodPercentileResultProvider;
        private IDice dice;
        private IGemFactory gemFactory;
        private IArtFactory artFactory;

        public GoodsFactory(IGoodPercentileResultProvider goodPercentileResultProvider, IDice dice,
            IGemFactory gemFactory, IArtFactory artFactory)
        {
            this.goodPercentileResultProvider = goodPercentileResultProvider;
            this.dice = dice;
            this.gemFactory = gemFactory;
            this.artFactory = artFactory;
        }

        public IEnumerable<Good> CreateWith(Int32 level)
        {
            var result = goodPercentileResultProvider.GetGoodPercentileResult(level);
            var amount = dice.Roll(result.RollToDetermineAmount);

            var goods = new List<Good>();

            while (amount-- > 0)
            {
                var good = GenerateGood(result.GoodType);
                goods.Add(good);
            }

            return goods;
        }

        private Good GenerateGood(String type)
        {
            switch (type)
            {
                case GoodsConstants.Gem: return gemFactory.Create();
                case GoodsConstants.Art: return artFactory.Create();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}