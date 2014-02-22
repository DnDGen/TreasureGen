using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface IIntelligenceGenerator
    {
        Boolean IsIntelligent(String itemType, IEnumerable<String> attributes);
        Intelligence GenerateFor(String itemType);
    }
}