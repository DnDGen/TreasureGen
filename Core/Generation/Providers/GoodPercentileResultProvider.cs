using System;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers
{
    public class GoodPercentileResultProvider : IGoodPercentileResultProvider
    {
        private IPercentileResultProvider percentileResultProvider;

        public GoodPercentileResultProvider(IPercentileResultProvider percentileResultProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
        }

        public GoodPercentileResult GetGoodPercentileResult(Int32 level)
        {
            var tableName = String.Format("Level{0}Goods", level);
            var result = percentileResultProvider.GetPercentileResult(tableName);

            

            var parsedResult = result.Split(',');

            var goodResult = new GoodPercentileResult();
            goodResult.GoodType = parsedResult[0];
            goodResult.RollToDetermineAmount = parsedResult[1];

            return goodResult;
        }
    }
}