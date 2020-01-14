using System.Collections.Generic;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal interface IIntelligenceGenerator
    {
        bool IsIntelligent(string itemType, IEnumerable<string> attributes, bool isMagical);
        Intelligence GenerateFor(Item item);
    }
}