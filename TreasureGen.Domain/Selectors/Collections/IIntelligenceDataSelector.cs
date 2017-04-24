using TreasureGen.Domain.Selectors.Selections;

namespace TreasureGen.Domain.Selectors.Collections
{
    internal interface IIntelligenceDataSelector
    {
        IntelligenceSelection SelectFrom(string name);
    }
}