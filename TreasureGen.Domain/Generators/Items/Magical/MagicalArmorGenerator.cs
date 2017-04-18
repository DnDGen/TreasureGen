using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class MagicalArmorGenerator : MagicalItemGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IPercentileSelector percentileSelector;
        private ICollectionsSelector collectionsSelector;
        private ISpecialAbilitiesGenerator specialAbilitiesSelector;
        private ISpecificGearGenerator specificGearGenerator;

        public MagicalArmorGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IPercentileSelector percentileSelector, ICollectionsSelector collectionsSelector, ISpecialAbilitiesGenerator specialAbilitiesSelector, ISpecificGearGenerator specificGearGenerator)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.specialAbilitiesSelector = specialAbilitiesSelector;
            this.specificGearGenerator = specificGearGenerator;
        }

        public Item GenerateAtPower(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
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

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, result.Type);
            armor.Name = percentileSelector.SelectFrom(tableName);
            armor.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, armor.Name);

            tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, armor.ItemType);
            armor.Attributes = collectionsSelector.SelectFrom(tableName, armor.Name);
            armor.Magic.SpecialAbilities = specialAbilitiesSelector.GenerateFor(armor.ItemType, armor.Attributes, power, armor.Magic.Bonus, abilityCount);

            return armor;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var armor = template.SmartClone();

            if (specificGearGenerator.TemplateIsSpecific(template))
            {
                armor = specificGearGenerator.GenerateFrom(template);
            }
            else
            {
                armor.ItemType = ItemTypeConstants.Armor;
                armor.Quantity = 1;
                armor.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, armor.Name);

                var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, armor.ItemType);
                armor.Attributes = collectionsSelector.SelectFrom(tableName, armor.Name);
            }

            armor.Quantity = 1;
            armor.Magic.SpecialAbilities = specialAbilitiesSelector.GenerateFor(template.Magic.SpecialAbilities);

            return armor;
        }
    }
}