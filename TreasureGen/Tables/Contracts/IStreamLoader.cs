using System;
using System.IO;

namespace TreasureGen.Tables
{
    public interface IStreamLoader
    {
        Stream LoadFor(String filename);
    }
}