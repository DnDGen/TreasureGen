using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface IIntelligenceGenerator
    {
        Boolean IsIntelligent(String itemType, IEnumerable<String> attributes, Dictionary<Magic, Object> magic);
        Intelligence GenerateFor(Dictionary<Magic, Object> magic);
    }
}