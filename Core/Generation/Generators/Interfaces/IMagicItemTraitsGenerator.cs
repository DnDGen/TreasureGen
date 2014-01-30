using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface IMagicItemTraitsGenerator
    {
        IEnumerable<String> GenerateTraitsFor(String itemType);
    }
}