using System.Collections.Generic;

namespace TreasureGen.Domain.Selectors.Attributes
{
    internal interface IAttributesSelector
    {
        IEnumerable<string> SelectFrom(string tableName, string name);
    }
}