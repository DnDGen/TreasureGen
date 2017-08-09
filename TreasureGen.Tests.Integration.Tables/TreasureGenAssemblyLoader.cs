using DnDGen.Core.Tables;
using System.Reflection;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Integration.Tables
{
    public class TreasureGenAssemblyLoader : AssemblyLoader
    {
        public Assembly GetRunningAssembly()
        {
            var type = typeof(TableNameConstants);
            return type.Assembly;
        }
    }
}
