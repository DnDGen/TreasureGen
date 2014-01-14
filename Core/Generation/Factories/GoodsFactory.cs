using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Good> CreateAtLevel(Int32 level)
        {
            var result = goodPercentileResultProvider.GetGoodPercentileResult(level);
            var amount = dice.Roll(result.RollToDetermineAmount);

            return GenerateGoods(result.GoodType, amount);
        }

        private IEnumerable<Good> GenerateGoods(String type, Int32 amount)
        {
            if (String.IsNullOrEmpty(type))
                return Enumerable.Empty<Good>();

            if (type == GoodsConstants.Gem)
                return GenerateGems(amount);

            return GenerateArt(amount);
        }

        private IEnumerable<Good> GenerateGems(Int32 amount)
        {
            var gems = new List<Good>();

            while (amount-- > 0)
            {
                var gem = gemFactory.Create();
                gems.Add(gem);
            }

            return gems;
        }

        private IEnumerable<Good> GenerateArt(Int32 amount)
        {
            var art = new List<Good>();

            while (amount-- > 0)
            {
                var artObject = artFactory.Create();
                art.Add(artObject);
            }

            return art;
        }
    }
}