using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class IntelligenceGenerator : IIntelligenceGenerator
    {
        public Intelligence GenerateFor(String itemType)
        {
            throw new NotImplementedException();
        }

        public Boolean IsIntelligent(IEnumerable<String> attributes)
        {
            throw new NotImplementedException();
        }
    }
}