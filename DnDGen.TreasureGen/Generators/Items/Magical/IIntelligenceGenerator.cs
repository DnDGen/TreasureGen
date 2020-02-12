using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using System.Collections.Generic;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal interface IIntelligenceGenerator
    {
        bool CanBeIntelligent(IEnumerable<string> attributes, bool isMagical);
        bool IsIntelligent(string itemType, IEnumerable<string> attributes, bool isMagical);
        Intelligence GenerateFor(Item item);
    }
}