namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal interface IChargesGenerator
    {
        int GenerateFor(string itemType, string name);
    }
}