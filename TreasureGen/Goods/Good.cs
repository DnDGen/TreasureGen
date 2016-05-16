namespace TreasureGen.Goods
{
    public class Good
    {
        public string Description { get; set; }
        public int ValueInGold { get; set; }

        public Good()
        {
            Description = string.Empty;
        }
    }
}