using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentGen.Common.Items
{
    public class Item
    {
        public String Name { get; set; }
        public String ItemType { get; set; }
        public List<String> Traits { get; set; }
        public IEnumerable<String> Attributes { get; set; }
        public Magic Magic { get; set; }
        public Int32 Quantity { get; set; }
        public List<String> Contents { get; set; }

        public Boolean IsMagical
        {
            get
            {
                return isMagical || Magic.Bonus > 0 || Magic.Charges > 0 || !String.IsNullOrEmpty(Magic.Curse)
                       || Magic.Intelligence.Ego > 0 || Magic.SpecialAbilities.Any();
            }
            set
            {
                isMagical = value;
            }
        }

        private Boolean isMagical;

        public Item()
        {
            Traits = new List<String>();
            Attributes = Enumerable.Empty<String>();
            Magic = new Magic();
            Quantity = 1;
            Name = String.Empty;
            Contents = new List<String>();
            ItemType = String.Empty;
        }
    }
}