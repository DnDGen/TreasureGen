using System.Collections.Generic;
using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal interface IAmmunitionGenerator
    {
        Item Generate();
        bool TemplateIsAmmunition(Item template);
        Item GenerateFrom(Item template);
        Item GenerateFrom(IEnumerable<string> subset);
    }
}