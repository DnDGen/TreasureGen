namespace DnDGen.TreasureGen.Items
{
    public class Damage
    {
        public string Roll { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Roll} {Type}".Trim();
        }

        public Damage()
        {
            Roll = string.Empty;
            Type = string.Empty;
        }

        public Damage Clone()
        {
            return new Damage { Roll = this.Roll, Type = this.Type };
        }
    }
}
