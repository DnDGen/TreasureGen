using TreasureGen.Domain.Selectors.Selections;

namespace TreasureGen.Domain.Selectors.Collections
{
    internal interface ISpecialAbilityDataSelector
    {
        SpecialAbilitySelection SelectFrom(string name);
        bool IsSpecialAbility(string name);
    }
}