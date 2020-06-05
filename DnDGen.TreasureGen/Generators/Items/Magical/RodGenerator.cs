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

        public Item GenerateRandom(string power)
        {
            var rodPowers = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, ItemTypeConstants.Rod);
            var adjustedPower = PowerHelper.AdjustPower(power, rodPowers);

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, adjustedPower, ItemTypeConstants.Rod);
            var result = typeAndAmountPercentileSelector.SelectFrom(tablename);

            return GenerateRod(result.Type, result.Amount);
        }

        private Item GenerateRod(string name, int bonus, params string[] traits)
        {
            var rod = new Item();
            rod.ItemType = ItemTypeConstants.Rod;
            rod.Name = name;
            rod.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name);
            rod.IsMagical = true;
            rod.Magic.Bonus = bonus;
            rod.Traits = new HashSet<string>(traits);

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

        public Item Generate(string power, string itemName, params string[] traits)
        {
            var rodName = GetRodName(itemName);

            var powers = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.PowerGroups, rodName);
            var adjustedPower = PowerHelper.AdjustPower(power, powers);

            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, adjustedPower, ItemTypeConstants.Rod);
            var results = typeAndAmountPercentileSelector.SelectAllFrom(tablename);
            var matches = results.Where(r => r.Type == rodName).ToList();

            var match = collectionsSelector.SelectRandomFrom(matches);
            return GenerateRod(match.Type, match.Amount, traits);
        }

        private Item GetWeapon(Item rod)
        {
            var weapons = WeaponConstants.GetAllMelee(false, false);
            var weaponBaseNames = weapons.Intersect(rod.BaseNames);
            if (!weaponBaseNames.Any())
                return rod;

            var weaponName = weaponBaseNames.First();

            var mundaneWeaponGenerator = justInTimeFactory.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon);
            var mundaneWeapon = mundaneWeaponGenerator.Generate(weaponName, rod.Traits.ToArray());

            rod.Attributes = rod.Attributes.Union(mundaneWeapon.Attributes);
            rod.CloneInto(mundaneWeapon);

            if (mundaneWeapon.IsMagical)
                mundaneWeapon.Traits.Add(TraitConstants.Masterwork);

            return mundaneWeapon;
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

            foreach (var trait in template.Traits)
            {
                rod.Traits.Add(trait);
            }

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

        private string GetRodName(string itemName)
        {
            var rods = RodConstants.GetAllRods();
            if (rods.Contains(itemName))
                return itemName;

            var rodFromBaseName = collectionsSelector.FindCollectionOf(TableNameConstants.Collections.Set.ItemGroups, itemName, rods.ToArray());

            return rodFromBaseName;
        }
    }
}