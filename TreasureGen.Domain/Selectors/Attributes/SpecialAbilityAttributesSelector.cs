using System;
using System.Linq;
using TreasureGen.Domain.Tables;
using TreasureGen.Selectors.Results;

namespace TreasureGen.Domain.Selectors.Attributes
{
    internal class SpecialAbilityAttributesSelector : ISpecialAbilityAttributesSelector
    {
        private ICollectionsSelector innerSelector;

        public SpecialAbilityAttributesSelector(ICollectionsSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public bool IsSpecialAbility(string name)
        {
            return innerSelector.Exists(TableNameConstants.Collections.Set.SpecialAbilityAttributes, name);
        }

        public SpecialAbilityAttributesResult SelectFrom(string name)
        {
            var attributes = innerSelector.SelectFrom(TableNameConstants.Collections.Set.SpecialAbilityAttributes, name).ToArray();

            if (attributes.Length < 3)
                throw new Exception("Attributes are not formatted for special abilities");

            var result = new SpecialAbilityAttributesResult();
            result.BaseName = attributes[1];
            result.BonusEquivalent = Convert.ToInt32(attributes[0]);
            result.Power = Convert.ToInt32(attributes[2]);

            return result;
        }
    }
}