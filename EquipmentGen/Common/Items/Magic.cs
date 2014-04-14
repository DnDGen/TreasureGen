using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentGen.Common.Items
{
    public class Magic
    {
        public Int32 Bonus { get; set; }
        public Int32 Charges { get; set; }
        public IEnumerable<SpecialAbility> SpecialAbilities { get; set; }
        public String Curse { get; set; }
        public Intelligence Intelligence { get; set; }

        public Magic()
        {
            SpecialAbilities = Enumerable.Empty<SpecialAbility>();
            Curse = String.Empty;
            Intelligence = new Intelligence();
        }
    }
}