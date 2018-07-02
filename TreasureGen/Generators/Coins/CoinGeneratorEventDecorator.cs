using EventGen;
using TreasureGen.Coins;

namespace TreasureGen.Generators.Coins
{
    internal class CoinGeneratorEventDecorator : ICoinGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly ICoinGenerator innerGenerator;

        public CoinGeneratorEventDecorator(ICoinGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
            this.innerGenerator = innerGenerator;
        }

        public Coin GenerateAtLevel(int level)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning level {level} coin generation");
            var coin = innerGenerator.GenerateAtLevel(level);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of level {level} coin: {coin.Quantity} {coin.Currency}");

            return coin;
        }
    }
}
