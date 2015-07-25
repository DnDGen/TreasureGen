using System;
using TreasureGen.Common.Items;

namespace TreasureGen.Generators.Items.Magical
{
    public interface ISpecificGearGenerator
    {
        Item GenerateFrom(String power, String specificGearType);
    }
}