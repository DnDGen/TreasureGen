using System;
using System.Collections.Generic;

namespace EquipmentGen.Core.Data.Items
{
    public abstract class Item
    {
        public String Name { get; set; }
        public IEnumerable<String> Traits { get; set; }
        public Int32 MagicalBonus { get; set; }
    }
}