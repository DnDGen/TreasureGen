using System;
using TreasureGen.Generators.Items.Mundane;

namespace TreasureGen.Generators.Domain.RuntimeFactories
{
    public interface IMundaneItemGeneratorFactory
    {
        MundaneItemGenerator CreateGeneratorOf(String itemType);
    }
}