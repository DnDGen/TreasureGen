using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Items.Magical
{
    public class MagicalArmorGenerator : IMagicalItemGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IPercentileSelector percentileSelector;
        private IAttributesSelector attributesSelector;
        private ISpecialAbilitiesGenerator specialAbilitiesSelector;
        private ISpecificGearGenerator specificGearGenerator;

        public MagicalArmorGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IPercentileSelector percentileSelector, IAttributesSelector attributesSelector, ISpecialAbilitiesGenerator specialAbilitiesSelector, ISpecificGearGenerator specificGearGenerator)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
            this.specialAbilitiesSelector = specialAbilitiesSelector;
            this.specificGearGenerator = specificGearGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var abilityCount = 0;

            while (result.Type == "SpecialAbility")
            {
                abilityCount += result.Amount;
                result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            }

            if (result.Amount == 0)
                return specificGearGenerator.GenerateFrom(power, result.Type);

            var armor = new Item();
            armor.ItemType = ItemTypeConstants.Armor;
            armor.Magic.Bonus = result.Amount;

            tableName = String.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, result.Type);
            armor.Name = percentileSelector.SelectFrom(tableName);

            tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, armor.ItemType);
            armor.Attributes = attributesSelector.SelectFrom(tableName, armor.Name);
            armor.Magic.SpecialAbilities = specialAbilitiesSelector.GenerateFor(armor.ItemType, armor.Attributes, power, armor.Magic.Bonus, abilityCount);

            return armor;
        }
    }
}