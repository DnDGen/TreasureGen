using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentGen.Core.Data.Items
{
    public class TraitItem : Item
    {
        public List<String> Traits { get; set; }

        public TraitItem()
        {
            Traits = new List<String>();
        }

        public override String ToString()
        {
            if (!Traits.Any())
                return base.ToString();

            var traits = String.Join(", ", Traits);
            return String.Format("{0} ({1})", base.ToString(), traits);
        }
    }
}