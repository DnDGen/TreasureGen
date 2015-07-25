using System;
using System.Collections.Generic;

namespace TreasureGen.Selectors.Interfaces
{
    public interface IAttributesSelector
    {
        IEnumerable<String> SelectFrom(String tableName, String name);
    }
}