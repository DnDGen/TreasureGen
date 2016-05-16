using TreasureGen.Selectors.Results;

namespace TreasureGen.Domain.Selectors.Attributes
{
    internal interface IIntelligenceAttributesSelector
    {
        IntelligenceAttributesResult SelectFrom(string tableName, string name);
    }
}