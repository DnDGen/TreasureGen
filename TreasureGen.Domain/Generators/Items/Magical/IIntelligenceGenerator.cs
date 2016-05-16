using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal interface IIntelligenceGenerator
    {
        bool IsIntelligent(string itemType, IEnumerable<string> attributes, bool isMagical);
        Intelligence GenerateFor(Item item);
    }
}