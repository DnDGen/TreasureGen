using System;
using EquipmentGen.Common.Coins;

namespace EquipmentGen.Generators.Interfaces.Coins
{
    public interface ICoinGenerator
    {
        Coin GenerateAtLevel(Int32 level);
    }
}