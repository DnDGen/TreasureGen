namespace TreasureGen.Selectors.Selections
{
    internal class TypeAndAmountSelection
    {
        public string Type { get; set; }
        public int Amount { get; set; }

        public TypeAndAmountSelection()
        {
            Type = string.Empty;
        }
    }
}