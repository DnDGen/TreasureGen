using System;

namespace EquipmentGen.Generators.Interfaces.Items.Magical
{
    public interface ISpellGenerator
    {
        String GenerateType();
        Int32 GenerateLevel(String power);
        String Generate(String spellType, Int32 level);
    }
}