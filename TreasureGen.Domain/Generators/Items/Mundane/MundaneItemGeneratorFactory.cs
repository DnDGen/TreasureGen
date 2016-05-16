using System;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class MundaneItemGeneratorFactory : IMundaneItemGeneratorFactory
    {
        private MundaneItemGenerator armorGenerator;
        private MundaneItemGenerator weaponGenerator;
        private MundaneItemGenerator toolGenerator;
        private MundaneItemGenerator alchemicalItemGenerator;

        public MundaneItemGeneratorFactory(MundaneItemGenerator armorGenerator, MundaneItemGenerator weaponGenerator, MundaneItemGenerator toolGenerator, MundaneItemGenerator alchemicalItemGenerator)
        {
            this.armorGenerator = armorGenerator;
            this.weaponGenerator = weaponGenerator;
            this.toolGenerator = toolGenerator;
            this.alchemicalItemGenerator = alchemicalItemGenerator;
        }

        public MundaneItemGenerator CreateGeneratorOf(string itemType)
        {
            switch (itemType)
            {
                case ItemTypeConstants.Armor: return armorGenerator;
                case ItemTypeConstants.Weapon: return weaponGenerator;
                case ItemTypeConstants.AlchemicalItem: return alchemicalItemGenerator;
                case ItemTypeConstants.Tool: return toolGenerator;
                default: throw new ArgumentException(itemType);
            }
        }
    }
}