using System.Collections.Generic;
using TreasureGen.Selectors.Selections;

namespace TreasureGen.Selectors.Percentiles
{
    internal interface ITypeAndAmountPercentileSelector
    {
        TypeAndAmountSelection SelectFrom(string tableName);
        IEnumerable<TypeAndAmountSelection> SelectAllFrom(string tablename);
    }
}