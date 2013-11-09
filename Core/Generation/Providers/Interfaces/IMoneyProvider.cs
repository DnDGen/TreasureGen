using EquipmentGen.Core.Data.Moneys;
using System;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface IMoneyProvider
    {
        Money GetMoney(Int32 level);
    }
}