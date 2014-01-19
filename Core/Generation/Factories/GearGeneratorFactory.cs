using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class GearGeneratorFactory : IGearGeneratorFactory
    {
        public IGearGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemsConstants.ItemTypes.Armor: return new ArmorGenerator();
                case ItemsConstants.ItemTypes.Weapon: return new WeaponGenerator();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}