using System;
using TreasureGen.Common.Items;

namespace TreasureGen.Generators.Items.Magical
{
    public interface MagicalItemGenerator
    {
        Item GenerateAtPower(String power);
    }
}