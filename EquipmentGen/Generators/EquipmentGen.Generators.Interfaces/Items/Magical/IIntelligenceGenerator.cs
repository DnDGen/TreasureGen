using System;
using System.Collections.Generic;
using EquipmentGen.Common.Items;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Generators.Interfaces.Items.Magical
{
    public interface IIntelligenceGenerator
    {
        Boolean IsIntelligent(String itemType, IEnumerable<String> attributes, Dictionary<Magic, Object> magic);
        Intelligence GenerateFor(Dictionary<Magic, Object> magic);
    }
}