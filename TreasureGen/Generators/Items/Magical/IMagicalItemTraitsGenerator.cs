using System.Collections.Generic;

namespace TreasureGen.Generators.Items.Magical
{
    internal interface IMagicalItemTraitsGenerator
    {
        IEnumerable<string> GenerateFor(string itemType, IEnumerable<string> attributes);
    }
}