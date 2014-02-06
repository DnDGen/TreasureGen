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
    }
}