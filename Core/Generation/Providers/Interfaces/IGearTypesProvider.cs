using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface IGearTypesProvider
    {
        IEnumerable<String> GetGearTypesFor(String gearName);
    }
}