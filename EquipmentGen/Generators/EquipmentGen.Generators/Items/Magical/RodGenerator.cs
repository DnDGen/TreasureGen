using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class RodGenerator : IMagicalItemGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IAttributesSelector attributesSelector;
        private IChargesGenerator chargesGenerator;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public RodGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IAttributesSelector attributesSelector,
            IChargesGenerator chargesGenerator, IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.attributesSelector = attributesSelector;
            this.chargesGenerator = chargesGenerator;
            this.booleanPercentileSelector = booleanPercentileSelector;
        }

        public Item GenerateAtPower(String power)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor rods");

            var tablename = String.Format("{0}Rods", power);
            var result = typeAndAmountPercentileSelector.SelectFrom(tablename);

            var rod = new Item();
            rod.ItemType = ItemTypeConstants.Rod;
            rod.Name = result.Type;
            rod.IsMagical = true;
            rod.Magic.Bonus = Convert.ToInt32(result.Amount);
            rod.Attributes = attributesSelector.SelectFrom("RodAttributes", rod.Name);

            if (rod.Attributes.Contains(AttributeConstants.Charged))
                rod.Magic.Charges = chargesGenerator.GenerateFor(rod.ItemType, rod.Name);

            if (rod.Name == "Rod of absorption")
            {
                var containsSpellLevels = booleanPercentileSelector.SelectFrom("RodOfAbsorptionContainsSpellLevels");
                if (containsSpellLevels)
                {
                    var maxCharges = chargesGenerator.GenerateFor(rod.ItemType, "Rod of absorption (max)");
                    var containedSpellLevels = (maxCharges - rod.Magic.Charges) / 2;
                    var containedSpellLevelsString = String.Format("{0} spell levels", containedSpellLevels);
                    rod.Contents.Add(containedSpellLevelsString);
                }
            }

            return rod;
        }
    }
}