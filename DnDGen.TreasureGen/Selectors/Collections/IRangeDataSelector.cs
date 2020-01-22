using DnDGen.TreasureGen.Selectors.Selections;

namespace DnDGen.TreasureGen.Selectors.Collections
{
    internal interface IRangeDataSelector
    {
        RangeSelection SelectFrom(string tableName, string name);
    }
}