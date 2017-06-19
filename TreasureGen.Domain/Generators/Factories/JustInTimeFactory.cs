namespace TreasureGen.Domain.Generators.Factories
{
    internal interface JustInTimeFactory
    {
        T Build<T>();
    }
}
