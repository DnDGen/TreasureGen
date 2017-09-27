using DnDGen.Core.Selectors.Collections;
using System;
using System.Linq;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Domain.Selectors.Collections
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
            return innerSelector.IsCollection(TableNameConstants.Collections.Set.SpecialAbilityAttributes, name);
        }

        public SpecialAbilitySelection SelectFrom(string name)
        {
            var data = innerSelector.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributes, name).ToArray();

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