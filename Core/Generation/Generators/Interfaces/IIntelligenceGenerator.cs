using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface IIntelligenceGenerator
    {
        Boolean IsIntelligent(IEnumerable<String> attributes);
        Intelligence GenerateFor(String itemType);
    }
}