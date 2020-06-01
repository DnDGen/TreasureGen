namespace DnDGen.TreasureGen.Items.Magical
{
    public interface MagicalItemGenerator
    {
        Item GenerateRandom(string power);
        Item Generate(string power, string itemName, params string[] traits);
        Item Generate(Item template, bool allowRandomDecoration = false);
        bool IsItemOfPower(string itemName, string power);
    }
}