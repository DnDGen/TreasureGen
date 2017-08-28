﻿namespace TreasureGen.Items
{
    public class Weapon : Item
    {
        public string Damage { get; set; }
        public string Size { get; set; }
        public string ThreatRange { get; set; }
        public string CriticalMultiplier { get; set; }
        public string DamageType { get; set; }
        public string Ammunition { get; set; }

        public override bool CanBeUsedAsWeaponOrArmor
        {
            get
            {
                return true;
            }
        }

        public Weapon()
        {
            Size = string.Empty;
            Damage = string.Empty;
            ThreatRange = string.Empty;
            DamageType = string.Empty;
            CriticalMultiplier = string.Empty;
            Ammunition = string.Empty;
        }

        public override Item Clone()
        {
            var clone = new Weapon();
            base.CloneInto(clone);
            CloneWeapon(clone);

            return clone;
        }

        private Weapon CloneWeapon(Weapon target)
        {
            target.Damage = Damage;
            target.ThreatRange = ThreatRange;
            target.CriticalMultiplier = CriticalMultiplier;
            target.Size = Size;
            target.DamageType = DamageType;
            target.Ammunition = Ammunition;

            return target;
        }

        public override Item MundaneClone()
        {
            var clone = new Weapon();
            MundaneCloneInto(clone);
            CloneWeapon(clone);

            return clone;
        }

        public override Item MundaneCloneInto(Item target)
        {
            base.MundaneCloneInto(target);

            if (target is Weapon)
                CloneWeapon(target as Weapon);

            return target;
        }

        public override Item SmartClone()
        {
            var clone = new Weapon();
            base.SmartCloneInto(clone);
            CloneWeapon(clone);

            return clone;
        }
    }
}