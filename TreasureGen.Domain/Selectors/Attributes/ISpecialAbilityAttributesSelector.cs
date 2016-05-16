using TreasureGen.Selectors.Results;

namespace TreasureGen.Domain.Selectors.Attributes
{
    internal interface ISpecialAbilityAttributesSelector
    {
        SpecialAbilityAttributesResult SelectFrom(string tableName, string name);
    }
}