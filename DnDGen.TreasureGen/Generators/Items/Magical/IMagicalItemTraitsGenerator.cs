using System.Collections.Generic;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal interface IMagicalItemTraitsGenerator
    {
        IEnumerable<string> GenerateFor(string itemType, IEnumerable<string> attributes);
    }
}