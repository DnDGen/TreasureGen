using System;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Generators.Interfaces.Items.Magical
{
    public interface ISpecificGearGenerator
    {
        Item GenerateFrom(String power, String specificGearType);
    }
}