using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DnDGen.TreasureGen.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DnDGen.TreasureGen.Tests.Integration")]
[assembly: InternalsVisibleTo("DnDGen.TreasureGen.Tests.Integration.IoC")]
[assembly: InternalsVisibleTo("DnDGen.TreasureGen.Tests.Integration.Tables")]
namespace DnDGen.TreasureGen.Generators
{
    public interface ITreasureGenerator
    {
        Treasure GenerateAtLevel(int level);
        Task<Treasure> GenerateAtLevelAsync(int level);
    }
}