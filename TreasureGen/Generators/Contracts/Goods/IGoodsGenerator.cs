using System;
using System.Collections.Generic;
using TreasureGen.Common.Goods;

namespace TreasureGen.Generators.Goods
{
    public interface IGoodsGenerator
    {
        IEnumerable<Good> GenerateAtLevel(Int32 level);
    }
}