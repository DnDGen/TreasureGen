using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class AmmunitionGenerator : IAmmunitionGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileResultProvider;
        private IDice dice;
        private IAttributesSelector attributesProvider;

        public AmmunitionGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileResultProvider, IDice dice,
            IAttributesSelector typesProvider)
        {
            this.typeAndAmountPercentileResultProvider = typeAndAmountPercentileResultProvider;
            this.dice = dice;
            this.attributesProvider = typesProvider;
        }

        public Item Generate()
        {
            var roll = dice.Percentile();
            var result = typeAndAmountPercentileResultProvider.SelectFrom("Ammunitions", roll);

            var ammunition = new Item();
            ammunition.Name = result.Type;
            ammunition.Quantity = dice.Roll(result.AmountToRoll);
            ammunition.Attributes = attributesProvider.SelectFrom(ammunition.Name, "AmmunitionAttributes");

            return ammunition;
        }
    }
}