namespace TreasureGen.Items.Magical
{
    public interface IMagicalItemGeneratorRuntimeFactory
    {
        MagicalItemGenerator CreateGeneratorOf(string itemType);
    }
}
