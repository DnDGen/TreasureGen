using DnDGen.TreasureGen.Items.Magical;
using System;

namespace DnDGen.TreasureGen.Items
{
    public class Armor : Item
    {
        public int ArmorBonus { get; set; }
        public string Size { get; set; }
        public int ArmorCheckPenalty { get; set; }
        public int MaxDexterityBonus { get; set; }

        public int TotalArmorBonus
        {
            get
            {
                if (string.IsNullOrEmpty(Magic.Curse))
                    return ArmorBonus + Magic.Bonus;

                if (Magic.Curse == CurseConstants.Delusion)
                    return ArmorBonus;

                if (Magic.Curse == CurseConstants.OppositeEffect)
                    return ArmorBonus - Magic.Bonus;

                return ArmorBonus + Magic.Bonus;
            }
        }

        public int TotalArmorCheckPenalty
        {
            get
            {
                var penalty = ArmorCheckPenalty;

                if (Traits.Contains(TraitConstants.Masterwork))
                    penalty++;

                if (Traits.Contains(TraitConstants.SpecialMaterials.Darkwood))
                    penalty++;

                if (Traits.Contains(TraitConstants.SpecialMaterials.Mithral))
                    penalty += 2;

                return Math.Min(0, penalty);
            }
        }

        public int TotalMaxDexterityBonus
        {
            get
            {
                var maxBonus = MaxDexterityBonus;

                if (Traits.Contains(TraitConstants.SpecialMaterials.Mithral))
                    maxBonus += 2;

                return maxBonus;
            }
        }

        public Armor()
        {
            Size = string.Empty;
            ItemType = ItemTypeConstants.Armor;
        }

        public override Item Clone()
        {
            var clone = new Armor();
            base.CloneInto(clone);
            CloneArmor(clone);

            return clone;
        }

        private Armor CloneArmor(Armor target)
        {
            target.ArmorBonus = ArmorBonus > 0 ? ArmorBonus : target.ArmorBonus;
            target.ArmorCheckPenalty = ArmorCheckPenalty < 0 ? ArmorCheckPenalty : target.ArmorCheckPenalty;
            target.MaxDexterityBonus = MaxDexterityBonus != 0 ? MaxDexterityBonus : target.MaxDexterityBonus;
            target.Size = !string.IsNullOrEmpty(Size) ? Size : target.Size;

            return target;
        }

        public override Item MundaneClone()
        {
            var clone = new Armor();
            base.MundaneCloneInto(clone);
            CloneArmor(clone);

            return clone;
        }

        public override Item MundaneCloneInto(Item target)
        {
            base.MundaneCloneInto(target);

            if (target is Armor)
                CloneArmor(target as Armor);

            return target;
        }

        public override Item SmartClone()
        {
            var clone = new Armor();
            base.SmartCloneInto(clone);
            CloneArmor(clone);

            return clone;
        }
    }
}
