using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentGen.Core.Data.Items
{
    public class Gear : TraitItem
    {
        public Int32 MagicalBonus { get; set; }
        public List<String> Abilities { get; set; }

        public Gear()
        {
            Abilities = new List<String>();
        }

        public override String ToString()
        {
            var bonus = GetBonusString();
            var abilities = GetAbilitiesString();
            var result = Name;

            if (!String.IsNullOrEmpty(bonus))
                result = String.Join(" ", bonus, result);

            if (!String.IsNullOrEmpty(abilities))
                result = String.Join(" of ", result, abilities);

            var baseString = base.ToString();
            return baseString.Replace(Name, result);
        }

        private String GetBonusString()
        {
            if (MagicalBonus > 0)
                return String.Format("+{0}", MagicalBonus);

            return String.Empty;
        }

        private String GetAbilitiesString()
        {
            var count = Abilities.Count();

            if (count == 1)
            {
                return Abilities.First();
            }
            else if (count == 2)
            {
                return String.Join(" and ", Abilities);
            }
            else if (count > 2)
            {
                var traits = String.Empty;
                var last = Abilities.Last();
                var first = Abilities.First();

                foreach (var trait in Abilities)
                {
                    if (trait != first)
                        traits += ", ";

                    if (trait == last)
                        traits += "and ";

                    traits += trait;
                }

                return traits;
            }

            return String.Empty;
        }
    }
}