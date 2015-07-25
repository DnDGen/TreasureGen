using System;
using TreasureGen.Common;

namespace TreasureGen.Generators
{
    public interface ITreasureGenerator
    {
        Treasure GenerateAtLevel(Int32 level);
    }
}