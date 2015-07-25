using System;
using System.Collections.Generic;
using TreasureGen.Common.Items;

namespace TreasureGen.Generators.Items.Magical
{
    public interface ISpecialAbilitiesGenerator
    {
        IEnumerable<SpecialAbility> GenerateFor(String itemType, IEnumerable<String> attributes, String power, Int32 magicalBonus, Int32 quantity);
    }
}