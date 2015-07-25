using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common.Coins;
using TreasureGen.Common.Goods;
using TreasureGen.Common.Items;

namespace TreasureGen.Common
{
    public class Treasure
    {
        public Coin Coin { get; set; }
        public IEnumerable<Good> Goods { get; set; }
        public IEnumerable<Item> Items { get; set; }

        public Treasure()
        {
            Coin = new Coin();
            Goods = Enumerable.Empty<Good>();
            Items = Enumerable.Empty<Item>();
        }
    }
}