using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors.Interfaces;
using TreasureGen.Selectors.Interfaces.Objects;
using TreasureGen.Tables.Interfaces;

namespace TreasureGen.Generators.Domain.Items.Magical
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
            return typeAndAmountPercentileSelector.SelectFrom(tableName);
        }
    }
}