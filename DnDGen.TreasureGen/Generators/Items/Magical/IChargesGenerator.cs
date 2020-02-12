namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal interface IChargesGenerator
    {
        int GenerateFor(string itemType, string name);
    }
}