using System;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface ISpellGenerator
    {
        String GenerateType();
        String GenerateOfTypeAtLevel(String spellType, Int32 level);
    }
}