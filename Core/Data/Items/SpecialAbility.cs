using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Data.Items
{
    public class SpecialAbility
    {
        public String Name { get; set; }
        public Int32 Strength { get; set; }
        public IEnumerable<String> TypeRequirements { get; set; }
        public Int32 BonusEquivalent { get; set; }

        public override String ToString()
        {
            if (Name.Equals("fortification", StringComparison.InvariantCultureIgnoreCase))
                return GetFortificationStrength();

            return GetAbilityStrength();
        }

        private String GetFortificationStrength()
        {
            switch (Strength)
            {
                case 0: return "Light fortification";
                case 1: return "Moderate fortification";
                case 2: return "Heavy fortification";
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private String GetAbilityStrength()
        {
            switch (Strength)
            {
                case 0: return Name;
                case 1: return String.Format("Improved {0}", Name);
                case 2: return String.Format("Greater {0}", Name);
                default: return String.Format("{0} ({1})", Name, Strength);
            }
        }
    }
}