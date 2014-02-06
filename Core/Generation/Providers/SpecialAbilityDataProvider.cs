using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Providers
{
    public class SpecialAbilityDataProvider : ISpecialAbilityDataProvider
    {
        //public SpecialAbilityData GetResultFrom(String tableName)
        //{
        //    var percentileResult = innerProvider.GetResultFrom(tableName);

        //    if (!percentileResult.Contains(","))
        //    {
        //        var message = String.Format("Table {0} was not formatted for special ability parsing", tableName);
        //        throw new FormatException(message);
        //    }

        //    var parsedResult = percentileResult.Split(',');

        //    var result = new SpecialAbilityData();
        //    result.Name = parsedResult[0];
        //    result.Bonus = Convert.ToInt32(parsedResult[1]);
        //    result.Strength = Convert.ToInt32(parsedResult[2]);

        //    if (parsedResult.Length > 3)
        //        result.CoreName = parsedResult[3];
        //    else
        //        result.CoreName = result.Name;

        //    return result;
        //}

        public SpecialAbility GetDataFor(String specialAbilityName)
        {
            throw new NotImplementedException();
        }
    }
}