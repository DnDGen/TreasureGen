using System.Collections.Generic;
using System.Linq;
using DnDGen.TreasureGen.Coins;
using DnDGen.TreasureGen.Goods;
using DnDGen.TreasureGen.Items;

namespace DnDGen.TreasureGen
{
    public class Treasure
    {
        public Coin Coin { get; set; }
        public IEnumerable<Good> Goods { get; set; }
        public IEnumerable<Item> Items { get; set; }

        public bool IsAny
        {
            get
            {
                return Coin.Quantity > 0 || Goods.Any() || Items.Any();
            }
        }

        public Treasure()
        {
            Coin = new Coin();
            Goods = Enumerable.Empty<Good>();
            Items = Enumerable.Empty<Item>();
        }
    }
}