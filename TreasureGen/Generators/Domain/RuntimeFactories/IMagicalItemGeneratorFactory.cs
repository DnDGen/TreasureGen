using System;
using TreasureGen.Generators.Items.Magical;

namespace TreasureGen.Generators.Domain.RuntimeFactories
{
    public interface IMagicalItemGeneratorFactory
    {
        MagicalItemGenerator CreateGeneratorOf(String type);
    }
}