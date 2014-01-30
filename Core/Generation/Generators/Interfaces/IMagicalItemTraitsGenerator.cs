using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface IMagicalItemTraitsGenerator
    {
        IEnumerable<String> GenerateFor(String itemType);
    }
}