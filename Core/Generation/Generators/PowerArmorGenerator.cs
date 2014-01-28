using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class PowerArmorGenerator : IPowerGearGenerator
    {
        public Gear GenerateAtPower(String power)
        {
            var armor = new Gear();

            return armor;
        }
    }
}