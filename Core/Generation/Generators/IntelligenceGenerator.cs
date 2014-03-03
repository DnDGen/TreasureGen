using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class IntelligenceGenerator : IIntelligenceGenerator
    {

        public Boolean IsIntelligent(String itemType, IEnumerable<String> attributes, Dictionary<Magic, Object> magic)
        {
            throw new NotImplementedException();
        }

        public Intelligence GenerateFor(String itemType, Dictionary<Magic, Object> magic)
        {
            throw new NotImplementedException();
        }
    }
}