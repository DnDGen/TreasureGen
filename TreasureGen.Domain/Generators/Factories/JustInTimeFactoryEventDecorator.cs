using EventGen;

namespace TreasureGen.Domain.Generators.Factories
{
    internal class JustInTimeFactoryEventDecorator : JustInTimeFactory
    {
        private readonly JustInTimeFactory innerFactory;
        private readonly GenEventQueue eventQueue;

        public JustInTimeFactoryEventDecorator(JustInTimeFactory innerFactory, GenEventQueue eventQueue)
        {
            this.innerFactory = innerFactory;
            this.eventQueue = eventQueue;
        }

        public T Build<T>()
        {
            eventQueue.Enqueue("TreasureGen", $"Instantiating something just in time");
            var builtType = innerFactory.Build<T>();
            eventQueue.Enqueue("TreasureGen", $"Finished instantiating something just in time");

            return builtType;
        }

        public T Build<T>(string name)
        {
            eventQueue.Enqueue("TreasureGen", $"Instantiating something named {name} just in time");
            var builtType = innerFactory.Build<T>(name);
            eventQueue.Enqueue("TreasureGen", $"Finished instantiating something named {name} just in time");

            return builtType;
        }
    }
}
