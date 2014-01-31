using System;

namespace EquipmentGen.Core.Data.Items
{
    public class AlchemicalItem : Item
    {
        public Int32 Quantity { get; set; }

        public override String ToString()
        {
            return String.Format("{0} (x{1})", base.ToString(), Quantity);
        }
    }
}