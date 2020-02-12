using DnDGen.EventGen;
using DnDGen.TreasureGen.Generators;

namespace DnDGen.TreasureGen.Generators
{
    internal class TreasureGeneratorEventDecorator : ITreasureGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly ITreasureGenerator innerGenerator;

        public TreasureGeneratorEventDecorator(ITreasureGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
            this.innerGenerator = innerGenerator;
        }

        public Treasure GenerateAtLevel(int level)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning level {level} treasure generation");
            var treasure = innerGenerator.GenerateAtLevel(level);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of level {level} treasure");

            return treasure;
        }
    }
}
