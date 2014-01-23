using System;
using System.Collections.Generic;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Providers
{
    public class MaterialsProvider : IMaterialsProvider
    {
        public Boolean HasSpecialMaterial()
        {
            throw new NotImplementedException();
        }

        public String GetSpecialMaterialFor(IEnumerable<String> types)
        {
            throw new NotImplementedException();
        }
    }
}