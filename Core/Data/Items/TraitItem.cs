using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Data.Items
{
    public class TraitItem : Item
    {
        public List<String> Traits { get; set; }

        public TraitItem()
        {
            Traits = new List<String>();
        }
    }
}