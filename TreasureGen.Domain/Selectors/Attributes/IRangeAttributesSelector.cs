using TreasureGen.Selectors.Results;

namespace TreasureGen.Domain.Selectors.Attributes
{
    internal interface IRangeAttributesSelector
    {
        RangeAttributesResult SelectFrom(string tableName, string name);
    }
}