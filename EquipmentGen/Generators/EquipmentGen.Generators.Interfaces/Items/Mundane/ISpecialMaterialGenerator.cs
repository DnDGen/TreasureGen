using System;
using System.Collections.Generic;

namespace EquipmentGen.Generators.Interfaces.Items.Mundane
{
    public interface ISpecialMaterialGenerator
    {
        Boolean HasSpecialMaterial(IEnumerable<String> types);
        String GenerateFor(IEnumerable<String> types);
    }
}