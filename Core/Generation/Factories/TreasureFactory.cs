using System;
using D20Dice;
using EquipmentGen.Core.Data;
using EquipmentGen.Core.Generation.Factories.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class TreasureFactory : ITreasureFactory
    {
        private IDice dice;
        private ICoinFactory coinFactory;
        private IGoodsFactory goodsFactory;

        public TreasureFactory(IDice dice, ICoinFactory coinFactory, IGoodsFactory goodsFactory)
        {
            this.dice = dice;
            this.coinFactory = coinFactory;
            this.goodsFactory = goodsFactory;
        }

        public Treasure CreateWith(Int32 level)
        {
            var treasure = new Treasure();

            treasure.Coin = coinFactory.CreateWith(level);
            treasure.Goods = goodsFactory.CreateWith(level);

            return treasure;
        }
    }
}