using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class ArmorGenerator : IGearGenerator
    {
        public Gear GenerateAtLevel(Int32 level)
        {
            throw new NotImplementedException();
        }

        public Gear GenerateAtPower(String power)
        {
            throw new NotImplementedException();
        }
    }
}