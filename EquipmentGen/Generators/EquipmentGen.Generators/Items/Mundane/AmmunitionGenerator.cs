using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class AmmunitionGenerator : IAmmunitionGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IDice dice;
        private IAttributesSelector attributesSelector;

        public AmmunitionGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IDice dice,
            IAttributesSelector attributesSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.dice = dice;
            this.attributesSelector = attributesSelector;
        }

        public Item Generate()
        {
            var roll = dice.Percentile();
            var result = typeAndAmountPercentileSelector.SelectFrom("Ammunitions", roll);

            var ammunition = new Item();
            ammunition.Name = result.Type;
            ammunition.Quantity = dice.Roll(result.AmountToRoll);
            ammunition.Attributes = attributesSelector.SelectFrom("AmmunitionAttributes", ammunition.Name);

            return ammunition;
        }
    }
}