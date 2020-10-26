using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Items
{
    public class Weapon : Item
    {
        public string Ammunition { get; set; }
        public List<Damage> Damages { get; set; }
        public string DamageRoll => GetRoll(Damages);
        public string DamageDescription => GetDescription(Damages);
        public List<Damage> CriticalDamages { get; set; }
        public string CriticalDamageRoll => GetRoll(CriticalDamages);
        public string CriticalDamageDescription => GetDescription(CriticalDamages);
        public string CriticalMultiplier { get; set; }
        public string Size { get; set; }
        public string ThreatRangeDescription => ThreatRange <= 1 ? 20.ToString() : $"{20 - ThreatRange + 1}-20";
        public int ThreatRange { get; set; }

        private string GetRoll(List<Damage> damages)
        {
            var roll = string.Empty;
            if (!damages.Any())
            {
                if (Magic.Bonus > 0)
                    return Magic.Bonus.ToString();

                return roll;
            }

            roll = damages[0].Roll;
            if (Magic.Bonus > 0)
                roll += $"+{Magic.Bonus}";

            foreach (var damage in damages.Skip(1))
            {
                roll += $"+{damage.Roll}";
            }

            return roll;
        }

        private string GetDescription(List<Damage> damages)
        {
            var description = string.Empty;
            if (!damages.Any())
            {
                if (Magic.Bonus > 0)
                    return Magic.Bonus.ToString();

                return description;
            }

            description = damages[0].ToString();
            if (Magic.Bonus > 0)
            {
                description = description.Replace(damages[0].Roll, $"{damages[0].Roll}+{Magic.Bonus}");
            }

            foreach (var damage in damages.Skip(1))
            {
                description += $" + {damage}";
            }

            return description;
        }

        public override bool CanBeUsedAsWeaponOrArmor => true;
        public IEnumerable<string> CombatTypes => Attributes.Intersect(combatTypes);

        private readonly IEnumerable<string> combatTypes;

        public Weapon()
        {
            Ammunition = string.Empty;
            Size = string.Empty;
            Damages = new List<Damage>();
            CriticalDamages = new List<Damage>();

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
            target.Ammunition = !string.IsNullOrEmpty(Ammunition) ? Ammunition : target.Ammunition;
            target.CriticalDamages = CriticalDamages.Select(d => d.Clone()).ToList();
            target.Damages = Damages.Select(d => d.Clone()).ToList();
            target.Size = !string.IsNullOrEmpty(Size) ? Size : target.Size;
            target.ThreatRange = ThreatRange > 0 ? ThreatRange : target.ThreatRange;

            target.Quantity = Quantity > 1 ? Quantity : target.Quantity;

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
