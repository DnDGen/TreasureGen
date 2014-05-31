using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class RodGenerator : IMagicalItemGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;

        public RodGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
        }

        public Item GenerateAtPower(String power)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor rods");

            var tablename = String.Format("{0}Rods", power);
            var result = typeAndAmountPercentileSelector.SelectFrom(tablename);

            var rod = new Item();
            rod.ItemType = ItemTypeConstants.Rod;
            rod.Name = String.Format("Rod of {0}", result.Type);
            rod.IsMagical = true;

            return rod;
        }
    }
}