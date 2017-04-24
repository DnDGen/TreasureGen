using System.Collections.Generic;

namespace TreasureGen.Domain.Selectors.Collections
{
    internal interface ICollectionsSelector
    {
        IEnumerable<string> SelectFrom(string tableName, string name);
        string SelectRandomFrom(IEnumerable<string> collection);
        bool Exists(string tableName, string name);
    }
}