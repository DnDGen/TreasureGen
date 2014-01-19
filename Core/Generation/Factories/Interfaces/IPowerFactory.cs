using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Factories.Interfaces
{
    public interface IPowerFactory
    {
        Item Create();
    }
}