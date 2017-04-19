using System;
using System.Collections.Generic;
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
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionsSelector collectionsSelector;
        private readonly IChargesGenerator chargesGenerator;
        private readonly IBooleanPercentileSelector booleanPercentileSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly Generator generator;

        public RodGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ICollectionsSelector collectionsSelector,
            IChargesGenerator chargesGenerator, IBooleanPercentileSelector booleanPercentileSelector, ISpecialAbilitiesGenerator specialAbilitiesGenerator, Generator generator)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.chargesGenerator = chargesGenerator;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.generator = generator;
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
            rod.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, rod.Name);
            rod.IsMagical = true;
            rod.Magic.Bonus = result.Amount;
            tablename = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, rod.ItemType);
            rod.Attributes = collectionsSelector.SelectFrom(tablename, rod.Name);

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

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var rod = template.Clone();
            rod.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, rod.Name);
            rod.IsMagical = true;
            rod.Quantity = 1;
            rod.ItemType = ItemTypeConstants.Rod;

            var results = GetAllResults();
            var result = results.First(r => rod.NameMatches(r.Type));
            rod.Magic.Bonus = result.Amount;

            var tablename = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            rod.Attributes = collectionsSelector.SelectFrom(tablename, rod.Name);

            rod.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(rod.Magic.SpecialAbilities);

            return rod.SmartClone();
        }

        private IEnumerable<TypeAndAmountPercentileResult> GetAllResults()
        {
            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Rod);
            var mediumResults = typeAndAmountPercentileSelector.SelectAllFrom(tablename);

            tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.Rod);
            var majorResults = typeAndAmountPercentileSelector.SelectAllFrom(tablename);

            return mediumResults.Union(majorResults);
        }

        public Item GenerateFromSubset(string power, IEnumerable<string> subset)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor rods");

            var rod = generator.Generate(
                () => GenerateAtPower(power),
                r => subset.Any(n => r.NameMatches(n)),
                () => GenerateDefaultFrom(subset),
                $"Rod from [{string.Join(", ", subset)}]");

            return rod;
        }

        private Item GenerateDefaultFrom(IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);

            var defaultRod = Generate(template);
            return defaultRod;
        }
    }
}