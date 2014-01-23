using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Providers
{
    public class GearTypesProvider : IGearTypesProvider
    {
        public IEnumerable<String> GetGearTypesFor(String gearName)
        {
            throw new NotImplementedException();
        }
    }
}