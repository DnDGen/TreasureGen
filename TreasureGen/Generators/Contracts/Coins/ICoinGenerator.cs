using System;
using TreasureGen.Common.Coins;

namespace TreasureGen.Generators.Coins
{
    public interface ICoinGenerator
    {
        Coin GenerateAtLevel(Int32 level);
    }
}