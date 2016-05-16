using System;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class RodGenerator : MagicalItemGenerator
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

        public Item GenerateAtPower(string power)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor rods");

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            var result = typeAndAmountPercentileSelector.SelectFrom(tablename);

            var rod = new Item();
            rod.ItemType = ItemTypeConstants.Rod;
            rod.Name = result.Type;
            rod.IsMagical = true;
            rod.Magic.Bonus = result.Amount;
            tablename = string.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, rod.ItemType);
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
                    rod.Contents.Add($"{containedSpellLevels} spell levels");
                }
            }

            return rod;
        }
    }
}