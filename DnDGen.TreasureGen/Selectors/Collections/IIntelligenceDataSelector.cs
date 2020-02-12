using DnDGen.TreasureGen.Selectors.Selections;

namespace DnDGen.TreasureGen.Selectors.Collections
{
    internal interface IIntelligenceDataSelector
    {
        IntelligenceSelection SelectFrom(string name);
    }
}