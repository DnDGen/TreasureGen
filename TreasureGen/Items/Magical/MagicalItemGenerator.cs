namespace TreasureGen.Items.Magical
{
    public interface MagicalItemGenerator
    {
        Item GenerateAtPower(string power);
        Item Generate(Item template, bool allowRandomDecoration = false);
    }
}