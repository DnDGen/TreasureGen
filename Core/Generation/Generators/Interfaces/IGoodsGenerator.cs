using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Goods;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface IGoodsGenerator
    {
        IEnumerable<Good> GenerateAtLevel(Int32 level);
    }
}