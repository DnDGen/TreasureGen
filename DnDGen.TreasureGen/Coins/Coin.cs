namespace DnDGen.TreasureGen.Coins
{
    public class Coin
    {
        public string Currency { get; set; }
        public int Quantity { get; set; }

        public Coin()
        {
            Currency = string.Empty;
        }
    }
}