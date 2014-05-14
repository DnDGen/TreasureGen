using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;

namespace EquipmentGen.Generators.Items.Magical
{
    public class PotionGenerator : IMagicalItemGenerator
    {
        private IDice dice;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IPercentileSelector percentileSelector;

        public PotionGenerator(IDice dice, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IPercentileSelector percentileSelector)
        {
            this.dice = dice;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
        }

        public Item GenerateAtPower(String power)
        {
            var result = GetResult(power);
            var potion = new Item();

            potion.Name = result.Type;
            potion.ItemType = ItemTypeConstants.Potion;
            potion.Magic.Bonus = Convert.ToInt32(result.Amount);
            potion.IsMagical = true;
            potion.Attributes = new[] { AttributeConstants.OneTimeUse };

            return potion;
        }

        private TypeAndAmountPercentileResult GetResult(String power)
        {
            var tableName = String.Format("{0}Potions", power);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);

            if (result.Type.Contains("ALIGNMENT"))
            {
                var alignment = percentileSelector.SelectFrom("ProtectionAlignments");
                result.Type = result.Type.Replace("ALIGNMENT", alignment);
            }

            if (result.Type.Contains("ENERGY"))
            {
                var energy = percentileSelector.SelectFrom("Elements");
                result.Type = result.Type.Replace("ENERGY", energy);
            }

            return result;
        }
    }
}