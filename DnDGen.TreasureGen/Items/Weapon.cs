using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Items
{
    public class Weapon : Item
    {
        public string Ammunition { get; set; }
        public string CriticalMultiplier { get; set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }
        public string Size { get; set; }
        public string ThreatRange { get; set; }

        public override bool CanBeUsedAsWeaponOrArmor
        {
            get
            {
                return true;
            }
        }

        public IEnumerable<string> CombatTypes
        {
            get
            {
                return Attributes.Intersect(combatTypes);
            }
        }

        private readonly IEnumerable<string> combatTypes;

        public Weapon()
        {
            Ammunition = string.Empty;
            CriticalMultiplier = string.Empty;
            Damage = string.Empty;
            DamageType = string.Empty;
            Size = string.Empty;
            ThreatRange = string.Empty;

            combatTypes = new[] { AttributeConstants.Ranged, AttributeConstants.Melee };
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
            target.Ammunition = Ammunition;
            target.CriticalMultiplier = CriticalMultiplier;
            target.Damage = Damage;
            target.DamageType = DamageType;
            target.Size = Size;
            target.ThreatRange = ThreatRange;

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
