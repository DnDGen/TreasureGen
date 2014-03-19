using System;
using System.Collections.Generic;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.Items.Magical
{
    public class IntelligenceGenerator : IIntelligenceGenerator
    {

        public Boolean IsIntelligent(String itemType, IEnumerable<String> attributes, Dictionary<Magic, Object> magic)
        {
            throw new NotImplementedException();
        }

        public Intelligence GenerateFor(Dictionary<Magic, Object> magic)
        {
            throw new NotImplementedException();
        }
    }
}