﻿using EventGen;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Goods;

namespace TreasureGen.Domain.Generators.Goods
{
    internal class GoodsGeneratorEventDecorator : IGoodsGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly IGoodsGenerator innerGenerator;

        public GoodsGeneratorEventDecorator(IGoodsGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
            this.innerGenerator = innerGenerator;
        }

        public IEnumerable<Good> GenerateAtLevel(int level)
        {
            eventQueue.Enqueue("TreasureGen", $"Beginning level {level} goods generation");
            var goods = innerGenerator.GenerateAtLevel(level);
            eventQueue.Enqueue("TreasureGen", $"Completed generation of {goods.Count()} level {level} goods");

            return goods;
        }
    }
}