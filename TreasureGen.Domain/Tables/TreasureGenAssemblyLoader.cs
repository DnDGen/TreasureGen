using DnDGen.Core.Tables;
using System.Reflection;

namespace TreasureGen.Domain.Tables
{
    internal class TreasureGenAssemblyLoader : AssemblyLoader
    {
        public Assembly GetRunningAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
