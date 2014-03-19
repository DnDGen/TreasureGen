using System;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Selectors.Interfaces
{
    public interface ISpecialAbilityDataSelector
    {
        SpecialAbility SelectFor(String specialAbilityName);
    }
}