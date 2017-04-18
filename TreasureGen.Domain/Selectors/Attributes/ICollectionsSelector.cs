using System.Collections.Generic;

namespace TreasureGen.Domain.Selectors.Attributes
{
    internal interface ICollectionsSelector
    {
        IEnumerable<string> SelectFrom(string tableName, string name);
        bool Exists(string tableName, string name);
    }
}