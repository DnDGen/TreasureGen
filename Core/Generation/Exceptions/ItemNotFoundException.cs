using System;

namespace EquipmentGen.Core.Generation.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(String item)
            : base(String.Format("Item {0} was not found", item)) { }
    }
}