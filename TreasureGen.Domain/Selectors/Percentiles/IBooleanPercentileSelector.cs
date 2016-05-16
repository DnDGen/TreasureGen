namespace TreasureGen.Domain.Selectors.Percentiles
{
    internal interface IBooleanPercentileSelector
    {
        bool SelectFrom(string tableName);
    }
}