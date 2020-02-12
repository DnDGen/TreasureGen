using DnDGen.EventGen;
using System.Collections.Generic;
using System.Linq;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class SpecialAbilitiesGeneratorEventDecorator : ISpecialAbilitiesGenerator
    {
        private readonly GenEventQueue eventQueue;
        private readonly ISpecialAbilitiesGenerator innerGenerator;

        public SpecialAbilitiesGeneratorEventDecorator(ISpecialAbilitiesGenerator innerGenerator, GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
            this.innerGenerator = innerGenerator;
        }

        public IEnumerable<SpecialAbility> GenerateFor(IEnumerable<SpecialAbility> abilityTemplates)
        {
            eventQueue.Enqueue("TreasureGen", $"Generating {abilityTemplates.Count()} special abilities from templates");
            var abilities = innerGenerator.GenerateFor(abilityTemplates);
            eventQueue.Enqueue("TreasureGen", $"Generated {abilities.Count()} special abilities");

            return abilities;
        }

        public IEnumerable<SpecialAbility> GenerateFor(Item targetItem, string power, int quantity)
        {
            eventQueue.Enqueue("TreasureGen", $"Generating {quantity} {power} special abilities for {targetItem.Name}");
            var abilities = innerGenerator.GenerateFor(targetItem, power, quantity);
            eventQueue.Enqueue("TreasureGen", $"Generated {abilities.Count()} {power} special abilities for {targetItem.Name}");

            return abilities;
        }
    }
}
