using System;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface ISpecialAbilityDataProvider
    {
        SpecialAbility GetDataFor(String specialAbilityName);
    }
}