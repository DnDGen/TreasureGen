using TreasureGen.Selectors.Selections;

namespace TreasureGen.Selectors.Collections
{
    internal interface ISpecialAbilityDataSelector
    {
        SpecialAbilitySelection SelectFrom(string name);
        bool IsSpecialAbility(string name);
    }
}