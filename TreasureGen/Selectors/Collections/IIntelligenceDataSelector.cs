using TreasureGen.Selectors.Selections;

namespace TreasureGen.Selectors.Collections
{
    internal interface IIntelligenceDataSelector
    {
        IntelligenceSelection SelectFrom(string name);
    }
}