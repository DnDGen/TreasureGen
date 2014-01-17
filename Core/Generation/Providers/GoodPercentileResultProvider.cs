using System;
using System.Collections.Generic;
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

        public GoodValuePercentileResult GetGoodValuePercentileResult(String tableName)
        {
            var result = percentileResultProvider.GetPercentileResult(tableName);
            var parsedResults = result.Split(',');

            var descriptions = new List<String>();
            for (var i = 1; i < parsedResults.Length; i++)
                descriptions.Add(parsedResults[i]);

            var goodValueResult = new GoodValuePercentileResult();
            goodValueResult.ValueRoll = parsedResults[0];
            goodValueResult.Descriptions = descriptions;

            return goodValueResult;
        }
    }
}