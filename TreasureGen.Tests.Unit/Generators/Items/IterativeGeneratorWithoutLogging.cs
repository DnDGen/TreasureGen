using DnDGen.Core.Generators;
using System;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    public class IterativeGeneratorWithoutLogging : Generator
    {
        public int MaxAttempts { get; set; }

        public IterativeGeneratorWithoutLogging(int maxRetries = 1)
        {
            MaxAttempts = maxRetries;
        }

        public T Generate<T>(Func<T> buildInstructions, Func<T, bool> isValid, Func<T> buildDefault, Func<T, string> failureDescription, string defaultDescription)
        {
            T builtObject;
            var attempts = 1;

            do builtObject = buildInstructions();
            while (attempts++ < MaxAttempts && !isValid(builtObject));

            if (isValid(builtObject))
                return builtObject;

            return buildDefault();
        }
    }
}
