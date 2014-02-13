using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentGen.Core.Data.Items
{
    public class TraitItem : Item
    {
        public List<String> Traits { get; set; }
        public Intelligence Intelligence { get; set; }
        public Int32 Charges { get; set; }
        public IEnumerable<String> Types { get; set; }

        public TraitItem()
        {
            Traits = new List<String>();
            Intelligence = new Intelligence();
            Types = Enumerable.Empty<String>();
        }
    }
}