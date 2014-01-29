using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface ISpecialMaterialGenerator
    {
        Boolean HasSpecialMaterial();
        String GenerateSpecialMaterialFor(IEnumerable<String> types);
    }
}