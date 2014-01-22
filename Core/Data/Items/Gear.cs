using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentGen.Core.Data.Items
{
    public class Gear : TraitItem
    {
        public Int32 MagicalBonus { get; set; }
        public List<String> Abilities { get; set; }
        public List<String> Types { get; set; }

        public Gear()
        {
            Abilities = new List<String>();
            Types = new List<String>();
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
            if (Abilities.Count < 3)
                return String.Join(" and ", Abilities);

            var abilitiesString = String.Join(", ", Abilities);
            var last = Abilities.Last();
            var indexOfLast = abilitiesString.LastIndexOf(last);
            abilitiesString = abilitiesString.Insert(indexOfLast, "and ");

            return abilitiesString;
        }
    }
}