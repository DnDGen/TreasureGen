using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class ChargesGenerator : IChargesGenerator
    {
        private IDice dice;
        private IAttributesSelector attributesSelector;

        public ChargesGenerator(IDice dice, IAttributesSelector attributesSelector)
        {
            this.dice = dice;
            this.attributesSelector = attributesSelector;
        }

        public Int32 GenerateFor(String itemType, String name)
        {
            if (itemType == ItemTypeConstants.Wand || itemType == ItemTypeConstants.Staff)
                return PercentileCharges();

            if (name == "Deck of illusions" && dice.Percentile() <= 90)
                return 34;

            var limits = attributesSelector.SelectFrom("ChargeLimits", name);
            var minimum = Convert.ToInt32(limits.First());
            var maximum = Convert.ToInt32(limits.Last());
            var roll = String.Format("1d({0}-{1}+1)+{1}-1", maximum, minimum);

            return dice.Roll(roll);
        }

        private Int32 PercentileCharges()
        {
            var roll = dice.Percentile();
            return Math.Max(roll / 2, 1);
        }
    }
}