using EventGen;
using System;

namespace TreasureGen.Domain.Generators.Items
{
    internal class IterativeGenerator : Generator
    {
        private const int MaxRetries = 1000;

        private readonly GenEventQueue eventQueue;

        public IterativeGenerator(GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
        }

        public T Generate<T>(Func<T> buildInstructions, Func<T, bool> isValid, Func<T> buildDefault, string defaultDescription)
        {
            T builtObject;
            var retries = 1;

            do builtObject = buildInstructions();
            while (isValid(builtObject) == false && retries++ < MaxRetries);

            if (isValid(builtObject))
                return builtObject;

            builtObject = buildDefault();
            eventQueue.Enqueue("TreasureGen", $"Generating {defaultDescription} by default");

            return builtObject;
        }
    }
}
