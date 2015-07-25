using System;
using System.Collections.Generic;
using TreasureGen.Common.Items;

namespace TreasureGen.Generators.Items.Magical
{
    public interface IIntelligenceGenerator
    {
        Boolean IsIntelligent(String itemType, IEnumerable<String> attributes, Boolean isMagical);
        Intelligence GenerateFor(Item item);
    }
}