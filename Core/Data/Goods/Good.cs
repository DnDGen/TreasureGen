using System;

namespace EquipmentGen.Core.Data.Goods
{
    public abstract class Good
    {
        public String Description { get; set; }
        public Int32 ValueInGold { get; set; }
    }
}