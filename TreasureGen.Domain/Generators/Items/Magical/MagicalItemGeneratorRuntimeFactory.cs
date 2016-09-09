using System;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class MagicalItemGeneratorRuntimeFactory : IMagicalItemGeneratorRuntimeFactory
    {
        private MagicalItemGenerator armorGenerator;
        private MagicalItemGenerator potionGenerator;
        private MagicalItemGenerator ringGenerator;
        private MagicalItemGenerator rodGenerator;
        private MagicalItemGenerator scrollGenerator;
        private MagicalItemGenerator staffGenerator;
        private MagicalItemGenerator wandGenerator;
        private MagicalItemGenerator weaponGenerator;
        private MagicalItemGenerator wondrousItemGenerator;

        public MagicalItemGeneratorRuntimeFactory(MagicalItemGenerator armorGenerator, MagicalItemGenerator potionGenerator,
            MagicalItemGenerator ringGenerator, MagicalItemGenerator rodGenerator, MagicalItemGenerator scrollGenerator,
            MagicalItemGenerator staffGenerator, MagicalItemGenerator wandGenerator, MagicalItemGenerator weaponGenerator,
            MagicalItemGenerator wondrousItemGenerator)
        {
            this.armorGenerator = armorGenerator;
            this.potionGenerator = potionGenerator;
            this.ringGenerator = ringGenerator;
            this.rodGenerator = rodGenerator;
            this.scrollGenerator = scrollGenerator;
            this.staffGenerator = staffGenerator;
            this.wandGenerator = wandGenerator;
            this.weaponGenerator = weaponGenerator;
            this.wondrousItemGenerator = wondrousItemGenerator;
        }

        public MagicalItemGenerator CreateGeneratorOf(string itemType)
        {
            switch (itemType)
            {
                case ItemTypeConstants.Potion: return potionGenerator;
                case ItemTypeConstants.Ring: return ringGenerator;
                case ItemTypeConstants.Rod: return rodGenerator;
                case ItemTypeConstants.Scroll: return scrollGenerator;
                case ItemTypeConstants.Staff: return staffGenerator;
                case ItemTypeConstants.Wand: return wandGenerator;
                case ItemTypeConstants.WondrousItem: return wondrousItemGenerator;
                case ItemTypeConstants.Armor: return armorGenerator;
                case ItemTypeConstants.Weapon: return weaponGenerator;
                default: throw new ArgumentException(itemType);
            }
        }
    }
}