using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface ITypesProvider
    {
        IEnumerable<String> GetTypesFor(String name, String table);
    }
}