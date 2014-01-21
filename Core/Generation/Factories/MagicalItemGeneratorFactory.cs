using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class MagicalItemGeneratorFactory : IMagicalItemGeneratorFactory
    {
        public IMagicalItemGenerator CreateWith(String type)
        {
            switch (type)
            {
                case ItemsConstants.ItemTypes.Potion: return new PotionGenerator();
                case ItemsConstants.ItemTypes.Ring: return new RingGenerator();
                case ItemsConstants.ItemTypes.Rod: return new RodGenerator();
                case ItemsConstants.ItemTypes.Scroll: return new ScrollGenerator();
                case ItemsConstants.ItemTypes.Staff: return new StaffGenerator();
                case ItemsConstants.ItemTypes.Wand: return new WandGenerator();
                case ItemsConstants.ItemTypes.WondrousItem: return new WondrousItemGenerator();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}