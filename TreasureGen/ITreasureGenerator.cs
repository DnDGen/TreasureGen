namespace TreasureGen.Generators
{
    public interface ITreasureGenerator
    {
        Treasure GenerateAtLevel(int level);
    }
}