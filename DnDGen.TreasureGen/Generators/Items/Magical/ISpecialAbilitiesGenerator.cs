using System.Collections.Generic;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal interface ISpecialAbilitiesGenerator
    {
        IEnumerable<SpecialAbility> GenerateFor(Item targetItem, string power, int quantity);
        IEnumerable<SpecialAbility> GenerateFor(IEnumerable<SpecialAbility> abilityNames);
    }
}