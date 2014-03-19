using System;

namespace EquipmentGen.Common.Coins
{
    public class Coin
    {
        public String Currency { get; set; }
        public Int32 Quantity { get; set; }

        public Coin()
        {
            Currency = String.Empty;
        }
    }
}