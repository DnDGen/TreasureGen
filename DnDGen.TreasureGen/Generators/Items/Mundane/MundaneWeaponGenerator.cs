using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using DnDGen.TreasureGen.Selectors.Collections;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;

namespace DnDGen.TreasureGen.Generators.Items.Mundane
{
    internal class MundaneWeaponGenerator : MundaneItemGenerator
    {
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ICollectionSelector collectionsSelector;
        private readonly Dice dice;
        private readonly Generator generator;
        private readonly IWeaponDataSelector weaponDataSelector;

        public MundaneWeaponGenerator(
            ITreasurePercentileSelector percentileSelector,
            ICollectionSelector collectionsSelector,
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
            var weapon = GenerateRandomPrototype();
            weapon = GenerateFromPrototype(weapon, true);

            return weapon;
        }

        private Weapon GenerateRandomPrototype()
        {
            var type = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneWeaponTypes);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, type);
            var weaponName = percentileSelector.SelectFrom(tableName);

            var weapon = GeneratePrototype(weaponName);

            return weapon;
        }

        private Weapon GeneratePrototype(string name)
        {
            var weapon = new Weapon();
            weapon.Name = name;
            weapon.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name);
            weapon.Quantity = 0;

            return weapon;
        }

        private Weapon GenerateFromPrototype(Weapon prototype, bool allowDecoration)
        {
            var weapon = SetWeaponAttributes(prototype);
            weapon.Quantity = GetQuantity(weapon);

            if (allowDecoration)
            {
                var isMasterwork = percentileSelector.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork);
                if (isMasterwork)
                    weapon.Traits.Add(TraitConstants.Masterwork);
            }

            return weapon;
        }

        private Weapon SetWeaponAttributes(Weapon weapon)
        {
            if (string.IsNullOrEmpty(weapon.Name))
                throw new ArgumentException("Weapon name cannot be empty - it must be filled before calling this method");

            weapon.Size = GetSize(weapon);
            weapon.Traits.Remove(weapon.Size);
            weapon.ItemType = ItemTypeConstants.Weapon;

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
            if (weapon.Quantity > 0)
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
            template.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, template.Name);

            var weapon = new Weapon();

            if (template is Weapon)
                weapon = template.MundaneClone() as Weapon;
            else
                template.MundaneCloneInto(weapon);

            weapon = GenerateFromPrototype(weapon, allowRandomDecoration);

            return weapon;
        }

        private string GetSize(Weapon template)
        {
            if (!string.IsNullOrEmpty(template.Size))
                return template.Size;

            if (!template.Traits.Any())
                return GetRandomSize();

            var allSizes = percentileSelector.SelectAllFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
            var sizeTraits = template.Traits.Intersect(allSizes);

            if (sizeTraits.Any())
                return sizeTraits.Single();

            return GetRandomSize();
        }

        private string GetRandomSize()
        {
            return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
        }

        public Item GenerateFrom(IEnumerable<string> subset, params string[] traits)
        {
            if (!subset.Any())
                throw new ArgumentException("Cannot generate from an empty collection subset");

            var prototype = new Weapon();

            if (subset.Count() == 1)
            {
                var name = subset.Single();
                prototype = GeneratePrototype(name);
            }
            else
            {
                prototype = generator.Generate(
                    GenerateRandomPrototype,
                    w => subset.Any(n => w.NameMatches(n)),
                    () => GenerateDefaultFrom(subset),
                    w => $"{w.Name} is not in subset [{string.Join(", ", subset)}]",
                    $"Mundane weapon from [{string.Join(", ", subset)}]");
            }

            prototype.Traits = new HashSet<string>(traits);
            var weapon = GenerateFromPrototype(prototype, true);

            return weapon;
        }

        private Weapon GenerateDefaultFrom(IEnumerable<string> subset)
        {
            var template = new Weapon();
            template.Name = collectionsSelector.SelectRandomFrom(subset);
            template.Quantity = 0;

            var defaultWeapon = GenerateFrom(template);
            return defaultWeapon as Weapon;
        }
    }
}