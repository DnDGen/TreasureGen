using System.Collections.Generic;

namespace DnDGen.TreasureGen.Goods
{
    public interface IGoodsGenerator
    {
        IEnumerable<Good> GenerateAtLevel(int level);
    }
}