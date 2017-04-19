using System.Collections.Generic;

namespace TreasureGen.Items.Mundane
{
    public interface MundaneItemGenerator
    {
        Item Generate();
        Item Generate(Item template, bool allowRandomDecoration = false);
        Item GenerateFromSubset(IEnumerable<string> subset);
    }
}