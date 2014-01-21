using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class PowerGearGeneratorFactory : IPowerGearGeneratorFactory
    {
        public IPowerGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemsConstants.ItemTypes.Armor: return new PowerArmorGenerator();
                case ItemsConstants.ItemTypes.Weapon: return new PowerWeaponGenerator();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}