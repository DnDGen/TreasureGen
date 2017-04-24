using System.Collections.Generic;
using TreasureGen.Domain.Selectors.Selections;

namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal interface ITypeAndAmountPercentileSelector
    {
        TypeAndAmountSelection SelectFrom(string tableName);
        IEnumerable<TypeAndAmountSelection> SelectAllFrom(string tablename);
    }
}