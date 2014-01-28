using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class GearSpecialAbilitiesGenerator : IGearSpecialAbilitiesGenerator
    {
        public IEnumerable<GearSpecialAbility> GenerateFor(IEnumerable<String> types, String power, Int32 magicalBonus, Int32 quantity)
        {
            throw new NotImplementedException();
        }
    }
}