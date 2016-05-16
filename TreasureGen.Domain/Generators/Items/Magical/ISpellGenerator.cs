namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal interface ISpellGenerator
    {
        string GenerateType();
        int GenerateLevel(string power);
        string Generate(string spellType, int level);
    }
}