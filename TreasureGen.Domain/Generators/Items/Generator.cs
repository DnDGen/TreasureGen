using System;

namespace TreasureGen.Domain.Generators.Items
{
    internal interface Generator
    {
        T Generate<T>(Func<T> buildInstructions, Func<T, bool> isValid, Func<T> buildDefault, string defaultDescription);
    }
}
