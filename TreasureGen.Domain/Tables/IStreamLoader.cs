using System.IO;

namespace TreasureGen.Domain.Tables
{
    internal interface IStreamLoader
    {
        Stream LoadFor(string filename);
    }
}