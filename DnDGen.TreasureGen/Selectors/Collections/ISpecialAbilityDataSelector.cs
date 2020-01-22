using DnDGen.TreasureGen.Selectors.Selections;

namespace DnDGen.TreasureGen.Selectors.Collections
{
    internal interface ISpecialAbilityDataSelector
    {
        SpecialAbilitySelection SelectFrom(string name);
        bool IsSpecialAbility(string name);
    }
}