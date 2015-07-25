using System;
using System.IO;

namespace TreasureGen.Tables.Interfaces
{
    public interface IStreamLoader
    {
        Stream LoadFor(String filename);
    }
}