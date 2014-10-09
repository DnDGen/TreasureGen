using D20Dice;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Selectors;
using EquipmentGen.Selectors.Decorators;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Bootstrap.Factories.Selectors
{
    public static class PercentileSelectorFactory
    {
        public static IPercentileSelector CreateWith(IPercentileMapper percentileMapper, IDice dice, IAttributesSelector attributesSelector)
        {
            IPercentileSelector selector = new PercentileSelector(percentileMapper, dice);
            selector = new ReplacePercentileSelectorDecorator(selector, attributesSelector);

            return selector;
        }
    }
}