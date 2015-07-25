using System;
using TreasureGen.Selectors.Interfaces.Objects;

namespace TreasureGen.Selectors.Interfaces
{
    public interface ITypeAndAmountPercentileSelector
    {
        TypeAndAmountPercentileResult SelectFrom(String tableName);
    }
}