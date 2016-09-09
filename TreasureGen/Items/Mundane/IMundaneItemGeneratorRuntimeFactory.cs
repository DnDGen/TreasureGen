namespace TreasureGen.Items.Mundane
{
    public interface IMundaneItemGeneratorRuntimeFactory
    {
        MundaneItemGenerator CreateGeneratorOf(string itemType);
    }
}
