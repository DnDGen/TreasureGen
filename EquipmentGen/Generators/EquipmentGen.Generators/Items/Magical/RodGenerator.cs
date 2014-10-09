using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;

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

            var tablename = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            var result = typeAndAmountPercentileSelector.SelectFrom(tablename);

            var rod = new Item();
            rod.ItemType = ItemTypeConstants.Rod;
            rod.Name = result.Type;
            rod.IsMagical = true;
            rod.Magic.Bonus = result.Amount;
            tablename = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, rod.ItemType);
            rod.Attributes = attributesSelector.SelectFrom(tablename, rod.Name);

            if (rod.Attributes.Contains(AttributeConstants.Charged))
                rod.Magic.Charges = chargesGenerator.GenerateFor(rod.ItemType, rod.Name);

            if (rod.Name == RodConstants.Absorption)
            {
                var containsSpellLevels = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.RodOfAbsorptionContainsSpellLevels);
                if (containsSpellLevels)
                {
                    var maxCharges = chargesGenerator.GenerateFor(rod.ItemType, RodConstants.FullAbsorption);
                    var containedSpellLevels = (maxCharges - rod.Magic.Charges) / 2;
                    var containedSpellLevelsString = String.Format("{0} spell levels", containedSpellLevels);
                    rod.Contents.Add(containedSpellLevelsString);
                }
            }

            return rod;
        }
    }
}