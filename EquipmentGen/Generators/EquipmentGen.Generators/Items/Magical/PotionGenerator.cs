using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class PotionGenerator : IMagicalItemGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IPercentileSelector percentileSelector;

        public PotionGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IPercentileSelector percentileSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
        }

        public Item GenerateAtPower(String power)
        {
            var result = GetResult(power);
            var potion = new Item();

            potion.Name = result.Type;
            potion.ItemType = ItemTypeConstants.Potion;
            potion.Magic.Bonus = result.Amount;
            potion.IsMagical = true;
            potion.Attributes = new[] { AttributeConstants.OneTimeUse };

            return potion;
        }

        private TypeAndAmountPercentileResult GetResult(String power)
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Potion);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);

            if (result.Type.Contains("ALIGNMENT"))
            {
                var alignment = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.ProtectionAlignments);
                result.Type = result.Type.Replace("ALIGNMENT", alignment);
            }

            if (result.Type.Contains("ENERGY"))
            {
                var energy = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.Elements);
                result.Type = result.Type.Replace("ENERGY", energy);
            }

            return result;
        }
    }
}