namespace TreasureGen.Items.Mundane
{
    public interface IMundaneItemGeneratorFactory
    {
        MundaneItemGenerator CreateGeneratorOf(string itemType);
    }
}
