using System;
using System.Collections.Generic;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Generators.Interfaces.Items.Magical
{
    public interface IIntelligenceGenerator
    {
        Boolean IsIntelligent(String itemType, IEnumerable<String> attributes, Boolean isMagical);
        Intelligence GenerateFor(Magic magic);
    }
}