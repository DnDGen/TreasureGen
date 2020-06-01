namespace DnDGen.TreasureGen.Items.Mundane
{
    public interface MundaneItemGenerator
    {
        Item GenerateRandom();
        Item Generate(string itemName, params string[] traits);
        Item Generate(Item template, bool allowRandomDecoration = false);
    }
}