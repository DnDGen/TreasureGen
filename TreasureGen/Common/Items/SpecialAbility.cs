using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureGen.Common.Items
{
    public class SpecialAbility
    {
        public String Name { get; set; }
        public String BaseName { get; set; }
        public Int32 Strength { get; set; }
        public IEnumerable<String> AttributeRequirements { get; set; }
        public Int32 BonusEquivalent { get; set; }

        public SpecialAbility()
        {
            AttributeRequirements = Enumerable.Empty<String>();
            Name = String.Empty;
            BaseName = String.Empty;
        }
    }
}