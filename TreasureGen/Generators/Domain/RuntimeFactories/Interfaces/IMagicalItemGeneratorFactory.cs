using System;
using TreasureGen.Generators.Items.Magical;

namespace TreasureGen.Generators.Domain.RuntimeFactories.Interfaces
{
    public interface IMagicalItemGeneratorFactory
    {
        IMagicalItemGenerator CreateGeneratorOf(String type);
    }
}