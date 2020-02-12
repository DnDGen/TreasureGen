using System.Collections.Generic;
using DnDGen.TreasureGen.Selectors.Selections;

namespace DnDGen.TreasureGen.Selectors.Percentiles
{
    internal interface ITypeAndAmountPercentileSelector
    {
        TypeAndAmountSelection SelectFrom(string tableName);
        IEnumerable<TypeAndAmountSelection> SelectAllFrom(string tablename);
    }
}