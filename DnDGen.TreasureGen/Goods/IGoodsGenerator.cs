using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Goods
{
    public interface IGoodsGenerator
    {
        IEnumerable<Good> GenerateAtLevel(int level);
        Task<IEnumerable<Good>> GenerateAtLevelAsync(int level);
    }
}