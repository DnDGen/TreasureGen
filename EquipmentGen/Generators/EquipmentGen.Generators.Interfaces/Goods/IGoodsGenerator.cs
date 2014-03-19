using System;
using System.Collections.Generic;
using EquipmentGen.Common.Goods;

namespace EquipmentGen.Generators.Interfaces.Goods
{
    public interface IGoodsGenerator
    {
        IEnumerable<Good> GenerateAtLevel(Int32 level);
    }
}