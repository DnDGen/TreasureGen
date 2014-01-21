using System;

namespace EquipmentGen.Core.Data.Items
{
    public class Ammunition : Gear
    {
        public Int32 Quantity { get; set; }

        public override String ToString()
        {
            return String.Format("{0} ({1})", base.ToString(), Quantity);
        }
    }
}