using System;
using TreasureGen.Selectors.Results;

namespace TreasureGen.Selectors
{
    public interface ITypeAndAmountPercentileSelector
    {
        TypeAndAmountPercentileResult SelectFrom(String tableName);
    }
}