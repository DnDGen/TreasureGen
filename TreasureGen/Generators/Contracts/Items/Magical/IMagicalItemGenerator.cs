using System;
using TreasureGen.Common.Items;

namespace TreasureGen.Generators.Items.Magical
{
    public interface IMagicalItemGenerator
    {
        Item GenerateAtPower(String power);
    }
}