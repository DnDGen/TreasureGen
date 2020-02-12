using DnDGen.EventGen;
using DnDGen.TreasureGen.Selectors.Selections;

namespace DnDGen.TreasureGen.Selectors.Collections
{
    internal class SpecialAbilityDataSelectorEventDecorator : ISpecialAbilityDataSelector
    {
        private readonly GenEventQueue eventQueue;
        private readonly ISpecialAbilityDataSelector innerSelector;

        public SpecialAbilityDataSelectorEventDecorator(ISpecialAbilityDataSelector innerSelector, GenEventQueue eventQueue)
        {
            this.eventQueue = eventQueue;
            this.innerSelector = innerSelector;
        }

        public bool IsSpecialAbility(string name)
        {
            return innerSelector.IsSpecialAbility(name);
        }

        public SpecialAbilitySelection SelectFrom(string name)
        {
            eventQueue.Enqueue("TreasureGen", $"Selecting data for special ability {name}");
            var ability = innerSelector.SelectFrom(name);
            eventQueue.Enqueue("TreasureGen", $"Selected data for special ability {name}");

            return ability;
        }
    }
}
