using System;

namespace TreasureGen.Generators.Items.Magical
{
    public interface ISpellGenerator
    {
        String GenerateType();
        Int32 GenerateLevel(String power);
        String Generate(String spellType, Int32 level);
    }
}