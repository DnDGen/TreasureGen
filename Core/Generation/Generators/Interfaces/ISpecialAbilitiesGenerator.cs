using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface ISpecialAbilitiesGenerator
    {
        IEnumerable<SpecialAbility> GenerateFor(IEnumerable<String> attributes, String power, Int32 magicalBonus, Int32 quantity);
        SpecialAbility GenerateFor(IEnumerable<String> attributes, String power);
    }
}