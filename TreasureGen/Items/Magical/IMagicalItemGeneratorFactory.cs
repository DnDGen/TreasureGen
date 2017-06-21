namespace TreasureGen.Items.Magical
{
    public interface IMagicalItemGeneratorFactory
    {
        MagicalItemGenerator CreateGeneratorOf(string itemType);
    }
}
