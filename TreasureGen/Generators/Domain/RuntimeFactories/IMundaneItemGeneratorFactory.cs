using System;
using TreasureGen.Generators.Items.Mundane;

namespace TreasureGen.Generators.Domain.RuntimeFactories
{
    public interface IMundaneItemGeneratorFactory
    {
        IMundaneItemGenerator CreateGeneratorOf(String itemType);
    }
}