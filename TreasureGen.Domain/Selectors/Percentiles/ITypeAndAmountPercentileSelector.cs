using TreasureGen.Selectors.Results;

namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal interface ITypeAndAmountPercentileSelector
    {
        TypeAndAmountPercentileResult SelectFrom(string tableName);
    }
}