using System;
using System.Collections.Generic;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface IAttributesProvider
    {
        IEnumerable<String> GetAttributesFor(String name, String table);
    }
}