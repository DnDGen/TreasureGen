using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface IMaterialsProvider
    {
        Boolean HasSpecialMaterial();
        String GetSpecialMaterialFor(IEnumerable<String> types);
    }
}