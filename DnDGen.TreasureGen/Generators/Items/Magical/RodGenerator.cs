using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class RodGenerator : MagicalItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionSelector collectionsSelector;
        private readonly IChargesGenerator chargesGenerator;
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly JustInTimeFactory justInTimeFactory;

        public RodGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            ICollectionSelector collectionsSelector,
            IChargesGenerator chargesGenerator,
            ITreasurePercentileSelector percentileSelector,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            JustInTimeFactory justInTimeFactory)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.chargesGenerator = chargesGenerator;
            this.percentileSelector = percentileSelector;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.justInTimeFactory = justInTimeFactory;
        }

        public Item GenerateFrom(string power)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor rods");

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            var result = typeAndAmountPercentileSelector.SelectFrom(tablename);

            return GenerateRod(result.Type, result.Amount);
        }

        private Item GenerateRod(string name, int bonus)
        {
            var rod = new Item();
            rod.ItemType = ItemTypeConstants.Rod;
            rod.Name = name;
            rod.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name);
            rod.IsMagical = true;
            rod.Magic.Bonus = bonus;

            var tablename = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Rod);
            rod.Attributes = collectionsSelector.SelectFrom(tablename, name);

            if (rod.Attributes.Contains(AttributeConstants.Charged))
                rod.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.Rod, name);

            if (name == RodConstants.Absorption)
            {
                var containsSpellLevels = percentileSelector.SelectFrom<bool>(TableNameConstants.Percentiles.Set.RodOfAbsorptionContainsSpellLevels);
                if (containsSpellLevels)
                {
                    var maxCharges = chargesGenerator.GenerateFor(ItemTypeConstants.Rod, RodConstants.Absorption_Full);
                    var containedSpellLevels = (maxCharges - rod.Magic.Charges) / 2;
                    rod.Contents.Add($"{containedSpellLevels} spell levels");
                }
            }

            rod = GetWeapon(rod);

            return rod;
        }

        public Item GenerateFrom(string power, string itemName)
        {
            if (power == PowerConstants.Minor)
                throw new ArgumentException("Cannot generate minor rods");

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            var results = typeAndAmountPercentileSelector.SelectAllFrom(tablename);
            var matches = results.Where(r => r.Type == itemName).ToList();

            if (!matches.Any())
            {
                foreach (var result in results)
                {
                    var baseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, result.Type);
                    if (baseNames.Contains(itemName))
                        matches.Add(result);
                }
            }

            if (!matches.Any())
            {
                throw new ArgumentException($"{itemName} is not a valid {power} Rod");
            }

            var match = collectionsSelector.SelectRandomFrom(matches);
            return GenerateRod(match.Type, match.Amount);
        }

        private Item GetWeapon(Item rod)
        {
            var weapons = WeaponConstants.GetBaseNames();
            if (!weapons.Intersect(rod.BaseNames).Any())
                return rod;

            var template = new Weapon();
            template.Name = weapons.Intersect(rod.BaseNames).First();

            var mundaneWeaponGenerator = justInTimeFactory.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon);
            var mundaneWeapon = mundaneWeaponGenerator.GenerateFrom(template);

            rod.Attributes = rod.Attributes.Union(mundaneWeapon.Attributes);
            rod.CloneInto(mundaneWeapon);

            if (mundaneWeapon.IsMagical)
                mundaneWeapon.Traits.Add(TraitConstants.Masterwork);

            return mundaneWeapon;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
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

            rod = GetWeapon(rod);

            return rod.SmartClone();
        }

        private IEnumerable<TypeAndAmountSelection> GetAllResults()
        {
            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.Rod);
            var mediumResults = typeAndAmountPercentileSelector.SelectAllFrom(tablename);

            tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.Rod);
            var majorResults = typeAndAmountPercentileSelector.SelectAllFrom(tablename);

            return mediumResults.Union(majorResults);
        }

        public bool IsItemOfPower(string itemName, string power)
        {
            if (power == PowerConstants.Minor)
                return false;

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Rod);
            var results = typeAndAmountPercentileSelector.SelectAllFrom(tablename);
            var matches = results.Where(r => r.Type == itemName);

            if (results.Any(r => r.Type == itemName))
                return true;

            foreach (var result in results)
            {
                var baseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, result.Type);
                if (baseNames.Contains(itemName))
                    return true;
            }

            return false;
        }
    }
}