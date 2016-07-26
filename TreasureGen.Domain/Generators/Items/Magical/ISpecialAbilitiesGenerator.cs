using System.Collections.Generic;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal interface ISpecialAbilitiesGenerator
    {
        IEnumerable<SpecialAbility> GenerateFor(string itemType, IEnumerable<string> attributes, string power, int magicalBonus, int quantity);
        IEnumerable<SpecialAbility> GenerateFor(IEnumerable<string> abilityNames);
    }
}