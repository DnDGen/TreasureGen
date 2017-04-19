using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class MagicalArmorGenerator : MagicalItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly IPercentileSelector percentileSelector;
        private readonly ICollectionsSelector collectionsSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesSelector;
        private readonly ISpecificGearGenerator specificGearGenerator;
        private readonly Generator generator;

        public MagicalArmorGenerator(
            ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            IPercentileSelector percentileSelector,
            ICollectionsSelector collectionsSelector,
            ISpecialAbilitiesGenerator specialAbilitiesSelector,
            ISpecificGearGenerator specificGearGenerator,
            Generator generator)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.specialAbilitiesSelector = specialAbilitiesSelector;
            this.specificGearGenerator = specificGearGenerator;
            this.generator = generator;
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
            var armor = template.Clone();

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
                armor.Magic.SpecialAbilities = specialAbilitiesSelector.GenerateFor(template.Magic.SpecialAbilities);
            }

            armor.Quantity = 1;

            return armor.SmartClone();
        }

        public Item GenerateFromSubset(string power, IEnumerable<string> subset)
        {
            var armor = generator.Generate(
                () => GenerateAtPower(power),
                a => subset.Any(n => a.NameMatches(n)),
                () => CreateDefaultArmor(power, subset),
                $"Magical armor from [{string.Join(", ", subset)}]");

            return armor;
        }

        private Item CreateDefaultArmor(string power, IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);

            if (!specificGearGenerator.TemplateIsSpecific(template))
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
                var results = typeAndAmountPercentileSelector.SelectAllFrom(tableName);
                template.Magic.Bonus = results.Select(r => r.Amount).Where(a => a > 0).Min();
            }

            var armor = Generate(template);
            return armor;
        }
    }
}