using System;

namespace TreasureGen.Generators.Items.Magical
{
    public interface IChargesGenerator
    {
        Int32 GenerateFor(String itemType, String name);
    }
}