using System;

namespace TreasureGen.Selectors.Results
{
    public class TypeAndAmountPercentileResult
    {
        public String Type { get; set; }
        public Int32 Amount { get; set; }

        public TypeAndAmountPercentileResult()
        {
            Type = String.Empty;
        }
    }
}