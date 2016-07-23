using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items.Magical;

namespace TreasureGen.Items
{
    public class Item
    {
        public string Name { get; set; }
        public string ItemType { get; set; }
        public HashSet<string> Traits { get; set; }
        public IEnumerable<string> Attributes { get; set; }
        public Magic Magic { get; set; }
        public int Quantity { get; set; }
        public List<string> Contents { get; set; }

        public bool IsMagical
        {
            get
            {
                return isMagical
                       || Magic.Bonus > 0
                       || Magic.Charges > 0
                       || !string.IsNullOrEmpty(Magic.Curse)
                       || Magic.Intelligence.Ego > 0
                       || Magic.SpecialAbilities.Any();
            }
            set
            {
                isMagical = value;
            }
        }

        private bool isMagical;

        public Item()
        {
            Traits = new HashSet<string>();
            Attributes = Enumerable.Empty<string>();
            Magic = new Magic();
            Quantity = 1;
            Name = string.Empty;
            Contents = new List<string>();
            ItemType = string.Empty;
        }
    }
}