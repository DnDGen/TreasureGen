using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items.Magical;

namespace TreasureGen.Items
{
    public class Item
    {
        public string Name { get; set; }
        public string ItemType { get; set; }
        public HashSet<string> Traits { get; set; }
        public IEnumerable<string> Attributes { get; set; }
        public Magic Magic { get; set; }
        public int Quantity { get; set; }
        public List<string> Contents { get; set; }

        public bool IsMagical
        {
            get
            {
                return isMagical
                       || Magic.Bonus > 0
                       || Magic.Charges > 0
                       || !string.IsNullOrEmpty(Magic.Curse)
                       || Magic.Intelligence.Ego > 0
                       || Magic.SpecialAbilities.Any();
            }
            set
            {
                isMagical = value;
            }
        }

        public bool CanBeUsedAsWeaponOrArmor
        {
            get
            {
                return ItemType == ItemTypeConstants.Weapon
                    || ItemType == ItemTypeConstants.Armor
                    || Name == StaffConstants.Power
                    || Name == RodConstants.Alertness
                    || Name == RodConstants.Flailing
                    || Name == RodConstants.Python
                    || Name == RodConstants.Viper
                    || Name == RodConstants.ThunderAndLightning
                    || Name == RodConstants.Withering;
            }
        }

        private bool isMagical;

        public Item()
        {
            Traits = new HashSet<string>();
            Attributes = Enumerable.Empty<string>();
            Magic = new Magic();
            Quantity = 1;
            Name = string.Empty;
            Contents = new List<string>();
            ItemType = string.Empty;
        }

        public Item Copy()
        {
            var copy = CopyWithoutMagic();

            copy.Magic.Curse = Magic.Curse;

            if (ItemType == ItemTypeConstants.Wand)
                copy.Contents.Clear();

            if (ItemType != ItemTypeConstants.Potion && ItemType != ItemTypeConstants.Scroll)
                copy.Magic.Charges = Magic.Charges;

            if (ItemType != ItemTypeConstants.Wand && ItemType != ItemTypeConstants.Scroll)
                copy.Magic.Bonus = Magic.Bonus;

            var nonIntelligenceItems = new[] { AttributeConstants.OneTimeUse, AttributeConstants.Ammunition };
            if (Attributes.Intersect(nonIntelligenceItems).Any() == false)
                copy.Magic.Intelligence = Magic.Intelligence.Copy();

            if (CanBeUsedAsWeaponOrArmor)
                copy.Magic.SpecialAbilities = Magic.SpecialAbilities.ToArray();

            return copy;
        }

        public Item CopyWithoutMagic()
        {
            var copy = new Item();
            copy.Attributes = Attributes.ToArray();
            copy.Contents.AddRange(Contents);
            copy.ItemType = ItemType;
            copy.Name = Name;
            copy.Quantity = Quantity;

            foreach (var trait in Traits)
            {
                copy.Traits.Add(trait);
            }

            return copy;
        }
    }
}