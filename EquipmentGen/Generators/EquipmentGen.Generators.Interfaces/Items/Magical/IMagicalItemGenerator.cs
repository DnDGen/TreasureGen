using System;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Generators.Interfaces.Items.Magical
{
    public interface IMagicalItemGenerator
    {
        Item GenerateAtPower(String power);
    }
}