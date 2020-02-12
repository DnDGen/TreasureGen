namespace DnDGen.TreasureGen.Items.Mundane
{
    public interface MundaneItemGenerator
    {
        Item Generate();
        Item Generate(string itemName, params string[] traits);
        Item GenerateFrom(Item template, bool allowRandomDecoration = false);
    }
}