using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentGen.Common.Items
{
    public class SpecialAbility
    {
        public String Name { get; set; }
        public String CoreName { get; set; }
        public Int32 Strength { get; set; }
        public IEnumerable<String> AttributeRequirements { get; set; }
        public Int32 BonusEquivalent { get; set; }

        public SpecialAbility()
        {
            AttributeRequirements = Enumerable.Empty<String>();
            Name = String.Empty;
            CoreName = String.Empty;
        }
    }
}