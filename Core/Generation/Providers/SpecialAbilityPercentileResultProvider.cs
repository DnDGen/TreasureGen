using System;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Providers.Objects;

namespace EquipmentGen.Core.Generation.Providers
{
    public class SpecialAbilityPercentileResultProvider : ISpecialAbilityPercentileResultProvider
    {
        private IPercentileResultProvider innerProvider;

        public SpecialAbilityPercentileResultProvider(IPercentileResultProvider innerProvider)
        {
            this.innerProvider = innerProvider;
        }

        public SpecialAbilityPercentileResult GetResultFrom(String tableName)
        {
            var percentileResult = innerProvider.GetResultFrom(tableName);

            if (!percentileResult.Contains(","))
            {
                var message = String.Format("Table {0} was not formatted for special ability parsing", tableName);
                throw new FormatException(message);
            }

            var parsedResult = percentileResult.Split(',');

            var result = new SpecialAbilityPercentileResult();
            result.Name = parsedResult[0];
            result.Bonus = Convert.ToInt32(parsedResult[1]);
            result.Strength = Convert.ToInt32(parsedResult[2]);

            return result;
        }
    }
}