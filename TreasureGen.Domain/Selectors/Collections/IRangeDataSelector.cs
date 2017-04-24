using TreasureGen.Domain.Selectors.Selections;

namespace TreasureGen.Domain.Selectors.Collections
{
    internal interface IRangeDataSelector
    {
        RangeSelection SelectFrom(string tableName, string name);
    }
}