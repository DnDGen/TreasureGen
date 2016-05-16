﻿namespace TreasureGen.Coins
{
    public interface ICoinGenerator
    {
        Coin GenerateAtLevel(int level);
    }
}