using System.Collections.Generic;

namespace TreasureGen.Items.Magical
{
    public interface MagicalItemGenerator
    {
        Item GenerateFrom(string power);
        Item GenerateFrom(Item template, bool allowRandomDecoration = false);
        Item GenerateFrom(string power, IEnumerable<string> subset);
    }
}