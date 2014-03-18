using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface IAttributesProvider
    {
        IEnumerable<String> GetAttributesFor(String name, String table);
    }
}