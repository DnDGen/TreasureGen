using System.Collections.Generic;

namespace TreasureGen.Goods
{
    public interface IGoodsGenerator
    {
        IEnumerable<Good> GenerateAtLevel(int level);
    }
}