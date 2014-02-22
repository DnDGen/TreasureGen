using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class IntelligenceGenerator : IIntelligenceGenerator
    {

        public Boolean IsIntelligent(String itemType, IEnumerable<String> attributes)
        {
            throw new NotImplementedException();
        }

        public Intelligence GenerateFor(String itemType)
        {
            throw new NotImplementedException();
        }
    }
}