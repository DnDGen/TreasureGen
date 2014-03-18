using System;

namespace EquipmentGen.Core.Generation.Providers.Objects
{
    public class TypeAndAmountPercentileResult
    {
        public String Type { get; set; }
        public String AmountToRoll { get; set; }

        public TypeAndAmountPercentileResult()
        {
            Type = String.Empty;
            AmountToRoll = String.Empty;
        }
    }
}