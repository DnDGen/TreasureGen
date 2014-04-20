using System;

namespace EquipmentGen.Selectors.Interfaces.Objects
{
    public class TypeAndAmountPercentileResult
    {
        public String Type { get; set; }
        public String Amount { get; set; }

        public TypeAndAmountPercentileResult()
        {
            Type = String.Empty;
            Amount = String.Empty;
        }
    }
}