using System;
using EquipmentGen.Core.Data.Coins;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface ICoinGenerator
    {
        Coin GenerateAtLevel(Int32 level);
    }
}