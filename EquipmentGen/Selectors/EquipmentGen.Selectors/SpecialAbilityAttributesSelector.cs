using System;
using System.Linq;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;

namespace EquipmentGen.Selectors
{
    public class SpecialAbilityAttributesSelector : ISpecialAbilityAttributesSelector
    {
        private IAttributesSelector innerSelector;

        public SpecialAbilityAttributesSelector(IAttributesSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public SpecialAbilityAttributesResult SelectFrom(String tableName, String name)
        {
            var attributes = innerSelector.SelectFrom(tableName, name).ToList();

            if (attributes.Count() < 3)
                throw new Exception("Attributes are not formatted for special abilities");

            var result = new SpecialAbilityAttributesResult();
            result.BaseName = attributes[1];
            result.BonusEquivalent = Convert.ToInt32(attributes[0]);
            result.Strength = Convert.ToInt32(attributes[2]);

            return result;
        }
    }
}