using System;
using System.Collections.Generic;

namespace TreasureGen.Generators.Items.Magical
{
    public interface IMagicalItemTraitsGenerator
    {
        IEnumerable<String> GenerateFor(String itemType, IEnumerable<String> attributes);
    }
}