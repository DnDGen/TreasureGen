using System;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface ISpellGenerator
    {
        String GenerateType();
        Int32 GenerateLevel(String power);
        String Generate(String spellType, Int32 level);
    }
}