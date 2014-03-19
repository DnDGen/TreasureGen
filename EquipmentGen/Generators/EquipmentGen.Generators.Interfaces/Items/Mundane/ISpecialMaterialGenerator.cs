using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface ISpecialMaterialGenerator
    {
        Boolean HasSpecialMaterial(IEnumerable<String> types);
        String GenerateFor(IEnumerable<String> types);
    }
}