using System;
using EquipmentGen.Core.Data.Coins;

namespace EquipmentGen.Core.Generation.Factories.Interfaces
{
    public interface ICoinFactory
    {
        Coin CreateWith(Int32 level);
    }
}