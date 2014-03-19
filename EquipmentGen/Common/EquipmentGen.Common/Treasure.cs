using System.Collections.Generic;
using EquipmentGen.Core.Data.Coins;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Data
{
    public class Treasure
    {
        public Coin Coin { get; set; }
        public IEnumerable<Good> Goods { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}