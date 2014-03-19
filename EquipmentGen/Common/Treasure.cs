using System.Collections.Generic;
using EquipmentGen.Common.Coins;
using EquipmentGen.Common.Goods;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Common
{
    public class Treasure
    {
        public Coin Coin { get; set; }
        public IEnumerable<Good> Goods { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}