using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Generators.Items.Magical
{
    internal interface ISpecialAbilitiesGenerator
    {
        IEnumerable<SpecialAbility> GenerateFor(Item targetItem, string power, int quantity);
        IEnumerable<SpecialAbility> GenerateFor(IEnumerable<SpecialAbility> abilityNames);
    }
}