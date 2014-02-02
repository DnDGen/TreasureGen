using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentGen.Core.Data.Items
{
    public class Gear : TraitItem
    {
        public Int32 MagicalBonus { get; set; }
        public IEnumerable<SpecialAbility> Abilities { get; set; }
        public IEnumerable<String> Types { get; set; }

        public Gear()
        {
            Abilities = Enumerable.Empty<SpecialAbility>();
            Types = Enumerable.Empty<String>();
        }

        public override String ToString()
        {
            var gearString = Name;

            if (MagicalBonus != 0)
            {
                var bonus = String.Format("+{0}", MagicalBonus);
                gearString = String.Join(" ", bonus, gearString);
            }

            if (Abilities.Any())
            {
                var abilities = GetAbilitiesString();
                gearString = String.Join(" of ", gearString, abilities);
            }

            var baseString = base.ToString();
            return baseString.Replace(Name, gearString);
        }

        private String GetAbilitiesString()
        {
            var abilityStrings = Abilities.Select<SpecialAbility, String>(a => a.ToString());

            if (Abilities.Count() < 3)
                return String.Join(" and ", abilityStrings);

            var abilitiesString = String.Join(", ", abilityStrings);
            var last = abilityStrings.Last();
            var indexOfLast = abilitiesString.LastIndexOf(last);
            abilitiesString = abilitiesString.Insert(indexOfLast, "and ");

            return abilitiesString;
        }
    }
}