using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class MundaneWeaponGenerator : MundaneItemGenerator
    {
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ICollectionsSelector collectionsSelector;
        private readonly Dice dice;
        private readonly Generator generator;
        private readonly IWeaponDataSelector weaponDataSelector;

        public MundaneWeaponGenerator(
            ITreasurePercentileSelector percentileSelector,
            ICollectionsSelector collectionsSelector,
            Dice dice,
            Generator generator,
            IWeaponDataSelector weaponDataSelector)
        {
            this.percentileSelector = percentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.generator = generator;
            this.dice = dice;
            this.weaponDataSelector = weaponDataSelector;
        }

        public Item Generate()
        {
            var type = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeaponTypes);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, type);
            var weaponName = percentileSelector.SelectFrom(tableName);

            var weapon = new Weapon();
            weapon.Name = weaponName;
            weapon.Size = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);

            weapon = PopulateWeapon(weapon);
            weapon.Quantity = GetQuantity(weapon);

            var isMasterwork = percentileSelector.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork);
            if (isMasterwork)
                weapon.Traits.Add(TraitConstants.Masterwork);

            return weapon;
        }

        private Weapon PopulateWeapon(Weapon weapon)
        {
            if (string.IsNullOrEmpty(weapon.Name) || string.IsNullOrEmpty(weapon.Size))
                throw new ArgumentException("Weapon name and weapon size cannot be empty - they must be filled before calling this method");

            weapon.ItemType = ItemTypeConstants.Weapon;
            weapon.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, weapon.Name);

            if (weapon.Name.Contains("Composite"))
            {
                var name = weapon.Name;
                weapon.Name = GetCompositeBowName(name);
                var compositeStrengthBonus = GetCompositeBowBonus(name);

                if (!string.IsNullOrEmpty(compositeStrengthBonus))
                    weapon.Traits.Add(compositeStrengthBonus);
            }

            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Weapon);
            weapon.Attributes = collectionsSelector.SelectFrom(tableName, weapon.Name);

            var weaponSelection = weaponDataSelector.Select(weapon.Name);
            weapon.CriticalMultiplier = weaponSelection.CriticalMultiplier;
            weapon.Damage = weaponSelection.DamageBySize[weapon.Size];
            weapon.DamageType = weaponSelection.DamageType;
            weapon.ThreatRange = weaponSelection.ThreatRange;
            weapon.Ammunition = weaponSelection.Ammunition;

            return weapon;
        }

        private int GetQuantity(Weapon weapon)
        {
            if (weapon.Quantity > 1)
                return weapon.Quantity;

            if (weapon.Attributes.Contains(AttributeConstants.Ammunition))
            {
                var roll = dice.Roll().Percentile().AsSum();
                return Math.Max(1, roll / 2);
            }

            if (weapon.Attributes.Contains(AttributeConstants.Thrown) && !weapon.Attributes.Contains(AttributeConstants.Melee))
                return dice.Roll().d20().AsSum();

            return 1;
        }

        private string GetCompositeBowBonus(string weaponName)
        {
            var compositeBonusStartIndex = weaponName.IndexOf('+');
            if (compositeBonusStartIndex == -1)
                return string.Empty;

            var compositeBonus = weaponName.Substring(compositeBonusStartIndex, 2);
            return $"{compositeBonus} Strength bonus";
        }

        private string GetCompositeBowName(string weaponName)
        {
            switch (weaponName)
            {
                case WeaponConstants.CompositeLongbow:
                case WeaponConstants.CompositePlus0Longbow:
                case WeaponConstants.CompositePlus1Longbow:
                case WeaponConstants.CompositePlus2Longbow:
                case WeaponConstants.CompositePlus3Longbow:
                case WeaponConstants.CompositePlus4Longbow: return WeaponConstants.CompositeLongbow;
                case WeaponConstants.CompositeShortbow:
                case WeaponConstants.CompositePlus0Shortbow:
                case WeaponConstants.CompositePlus1Shortbow:
                case WeaponConstants.CompositePlus2Shortbow: return WeaponConstants.CompositeShortbow;
                default: throw new ArgumentException($"Composite bow {weaponName} does not map to a known bow");
            }
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var weapon = new Weapon();
            template.MundaneClone(weapon);

            weapon.Size = GetSize(template);
            weapon.Traits.Remove(weapon.Size);
            weapon = PopulateWeapon(weapon);

            if (allowRandomDecoration)
            {
                var isMasterwork = percentileSelector.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork);
                if (isMasterwork)
                    weapon.Traits.Add(TraitConstants.Masterwork);
            }

            if (weapon.Quantity == 0)
                weapon.Quantity = GetQuantity(weapon);

            return weapon;
        }

        private string GetSize(Item template)
        {
            if (template is Weapon)
            {
                var weapon = template as Weapon;

                if (!string.IsNullOrEmpty(weapon.Size))
                    return weapon.Size;
            }

            var allSizes = percentileSelector.SelectAllFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
            var sizes = template.Traits.Intersect(allSizes);

            if (sizes.Any())
                return sizes.Single();

            return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
        }

        public Item GenerateFrom(IEnumerable<string> subset)
        {
            if (!subset.Any())
                throw new ArgumentException("Cannot generate from an empty collection subset");

            var weapon = generator.Generate(
                Generate,
                w => subset.Any(n => w.NameMatches(n)),
                () => GenerateDefaultFrom(subset),
                w => $"{w.Name} is not in subset [{string.Join(", ", subset)}]",
                $"Mundane weapon from [{string.Join(", ", subset)}]");

            return weapon;
        }

        private Item GenerateDefaultFrom(IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);
            template.Quantity = 0;

            var defaultWeapon = GenerateFrom(template);
            return defaultWeapon;
        }
    }
}