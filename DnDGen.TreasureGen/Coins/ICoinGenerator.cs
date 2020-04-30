using System.Threading.Tasks;

namespace DnDGen.TreasureGen.Coins
{
    public interface ICoinGenerator
    {
        Coin GenerateAtLevel(int level);
        Task<Coin> GenerateAtLevelAsync(int level);
    }
}