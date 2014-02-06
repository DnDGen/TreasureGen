using System;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Providers.Interfaces
{
    public interface ISpecialAbilityDataProvider
    {
        SpecialAbility GetDataFor(String specialAbilityName);
    }
}