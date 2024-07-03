using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using System;
using System.Linq;

namespace DnDGen.TreasureGen.Selectors.Collections
{
    internal class SpecialAbilityDataSelector : ISpecialAbilityDataSelector
    {
        private readonly ICollectionSelector innerSelector;

        public SpecialAbilityDataSelector(ICollectionSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public bool IsSpecialAbility(string name)
        {
            return innerSelector.IsCollection(Config.Name, TableNameConstants.Collections.Set.SpecialAbilityAttributes, name);
        }

        public SpecialAbilitySelection SelectFrom(string name)
        {
            var data = innerSelector.SelectFrom(Config.Name, TableNameConstants.Collections.Set.SpecialAbilityAttributes, name).ToArray();

            if (data.Length != 3)
                throw new Exception("Data is not formatted for special abilities");

            var selection = new SpecialAbilitySelection();
            selection.BaseName = data[DataIndexConstants.SpecialAbility.BaseName];
            selection.BonusEquivalent = Convert.ToInt32(data[DataIndexConstants.SpecialAbility.BonusEquivalent]);
            selection.Power = Convert.ToInt32(data[DataIndexConstants.SpecialAbility.Power]);

            return selection;
        }
    }
}