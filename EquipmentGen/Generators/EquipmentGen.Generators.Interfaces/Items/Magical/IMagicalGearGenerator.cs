using System;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Generators.Interfaces.Items.Magical
{
    public interface IMagicalGearGenerator
    {
        Item GenerateAtPower(String power);
    }
}