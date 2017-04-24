using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

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
        private readonly MundaneItemGenerator mundaneArmorGenerator;
        private readonly IMundaneItemGeneratorRuntimeFactory mundaneGeneratorFactory;

        public MagicalArmorGenerator(
            ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            IPercentileSelector percentileSelector,
            ICollectionsSelector collectionsSelector,
            ISpecialAbilitiesGenerator specialAbilitiesSelector,
            ISpecificGearGenerator specificGearGenerator,
            Generator generator,
            IMundaneItemGeneratorRuntimeFactory mundaneGeneratorFactory)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.specialAbilitiesSelector = specialAbilitiesSelector;
            this.specificGearGenerator = specificGearGenerator;
            this.generator = generator;
            this.mundaneArmorGenerator = mundaneGeneratorFactory.CreateGeneratorOf(ItemTypeConstants.Armor);
        }

        public Item GenerateAtPower(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            var selection = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var abilityCount = 0;

            while (selection.Type == "SpecialAbility")
            {
                abilityCount += selection.Amount;
                selection = typeAndAmountPercentileSelector.SelectFrom(tableName);
            }

            if (selection.Amount == 0)
                return specificGearGenerator.GenerateFrom(power, selection.Type);

            var template = new Armor();
            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, selection.Type);
            template.Name = percentileSelector.SelectFrom(tableName);

            var armor = mundaneArmorGenerator.Generate(template);
            armor.Magic.Bonus = selection.Amount;
            armor.Magic.SpecialAbilities = specialAbilitiesSelector.GenerateFor(ItemTypeConstants.Armor, armor.Attributes, power, armor.Magic.Bonus, abilityCount);

            if (armor.IsMagical)
                armor.Traits.Add(TraitConstants.Masterwork);

            return armor;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            if (specificGearGenerator.TemplateIsSpecific(template))
            {
                var specificArmor = specificGearGenerator.GenerateFrom(template);
                specificArmor.Quantity = 1;
                return specificArmor;
            }

            var armor = mundaneArmorGenerator.Generate(template);
            armor.IsMagical = true;
            armor.Magic.Bonus = template.Magic.Bonus;
            armor.Magic.Charges = template.Magic.Charges;
            armor.Magic.Curse = template.Magic.Curse;
            armor.Magic.Intelligence = template.Magic.Intelligence;
            armor.Magic.SpecialAbilities = specialAbilitiesSelector.GenerateFor(template.Magic.SpecialAbilities);

            if (armor.IsMagical)
                armor.Traits.Add(TraitConstants.Masterwork);

            return armor;
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
                template.Magic.Bonus = results.Where(r => r.Type != "SpecialAbility" && r.Amount > 0).Select(r => r.Amount).Min();
            }

            var armor = Generate(template);
            return armor;
        }
    }
}