namespace DnDGen.TreasureGen.Items.Magical
{
    public interface MagicalItemGenerator
    {
        Item GenerateFrom(string power);
        Item GenerateFrom(string power, string itemName);
        Item GenerateFrom(Item template, bool allowRandomDecoration = false);
        bool IsItemOfPower(string itemName, string power);
    }
}