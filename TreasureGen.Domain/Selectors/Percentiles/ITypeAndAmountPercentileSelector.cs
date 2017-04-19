using System.Collections.Generic;

namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal interface ITypeAndAmountPercentileSelector
    {
        TypeAndAmountPercentileResult SelectFrom(string tableName);
        IEnumerable<TypeAndAmountPercentileResult> SelectAllFrom(string tablename);
    }
}