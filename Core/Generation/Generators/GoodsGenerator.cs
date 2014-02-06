using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class GoodsGenerator : IGoodsGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider;
        private IDice dice;

        public GoodsGenerator(IDice dice, ITypeAndAmountPercentileResultProvider typeAndAmountPercentileResultProvider)
        {
            this.dice = dice;
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
        }

        public IEnumerable<Good> GenerateAtLevel(Int32 level)
        {
            var tableName = String.Format("Level{0}Goods", level);
            var typeAndAmountResult = typeAndAmountPercentileResultProvider.GetResultFrom(tableName);

            if (String.IsNullOrEmpty(typeAndAmountResult.Type))
                return Enumerable.Empty<Good>();

            var goods = new List<Good>();
            var amount = typeAndAmountResult.Amount;
            tableName = String.Format("{0}Value", typeAndAmountResult.Type);

            while (amount-- > 0)
            {
                //var valueResult = goodPercentileResultProvider.GetResultFrom(tableName);
                //var roll = String.Format("1d{0}-1", valueResult.Descriptions.Count());
                //var index = dice.Roll(roll);

                //var good = new Good();
                //good.Description = valueResult.Descriptions.ElementAt(index);
                //good.ValueInGold = dice.Roll(valueResult.ValueRoll);

                //goods.Add(good);
            }

            return goods;
        }
    }
}