using System;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class SpellGenerator : ISpellGenerator
    {
        public String GenerateType()
        {
            throw new NotImplementedException();
        }

        public Int32 GenerateLevel(String power)
        {
            throw new NotImplementedException();
        }

        public String Generate(String spellType, Int32 level)
        {
            throw new NotImplementedException();
        }
    }
}