using TreasureGen.Selectors.Selections;

namespace TreasureGen.Selectors.Collections
{
    internal interface IRangeDataSelector
    {
        RangeSelection SelectFrom(string tableName, string name);
    }
}