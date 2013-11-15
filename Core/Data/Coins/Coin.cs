using System;

namespace EquipmentGen.Core.Data.Coins
{
    public class Coin
    {
        public String Currency { get; set; }
        public Int32 Quantity { get; set; }

        public override String ToString()
        {
            if (Currency == null)
                return String.Empty;

            return String.Format("{0} {1}", Quantity, Currency);
        }
    }
}