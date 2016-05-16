namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal class TypeAndAmountPercentileResult
    {
        public string Type { get; set; }
        public int Amount { get; set; }

        public TypeAndAmountPercentileResult()
        {
            Type = string.Empty;
        }
    }
}