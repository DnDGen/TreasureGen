using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items
{
    internal class SpecificGearGenerator : ISpecificGearGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private ICollectionsSelector collectionsSelector;
        private IChargesGenerator chargesGenerator;
        private IPercentileSelector percentileSelector;
        private ISpellGenerator spellGenerator;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private Dice dice;
        private IArmorDataSelector armorDataSelector;

        public SpecificGearGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            ICollectionsSelector collectionsSelector,
            IChargesGenerator chargesGenerator,
            IPercentileSelector percentileSelector,
            ISpellGenerator spellGenerator,
            IBooleanPercentileSelector booleanPercentileSelector,
            Dice dice,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            IArmorDataSelector armorDataSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.chargesGenerator = chargesGenerator;
            this.percentileSelector = percentileSelector;
            this.spellGenerator = spellGenerator;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.dice = dice;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.armorDataSelector = armorDataSelector;
        }

        public Item GenerateFrom(string power, string specificGearType)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpecificITEMTYPEs, power, specificGearType);
            var selection = typeAndAmountPercentileSelector.SelectFrom(tableName);

            var gear = new Item();
            gear.Name = selection.Type;
            gear.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, selection.Type);
            gear.Magic.Bonus = selection.Amount;
            gear.Magic.SpecialAbilities = GetSpecialAbilities(specificGearType, gear.Name);
            gear.ItemType = GetItemType(specificGearType);

            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, specificGearType);
            gear.Attributes = collectionsSelector.SelectFrom(tableName, gear.Name);

            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, specificGearType);
            var traits = collectionsSelector.SelectFrom(tableName, gear.Name);

            foreach (var trait in traits)
                gear.Traits.Add(trait);

            if (gear.Attributes.Contains(AttributeConstants.Charged))
                gear.Magic.Charges = chargesGenerator.GenerateFor(specificGearType, gear.Name);

            if (gear.Name == WeaponConstants.JavelinOfLightning)
            {
                gear.IsMagical = true;
            }
            else if (gear.Name == ArmorConstants.CastersShield)
            {
                var hasSpell = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldContainsSpell);

                if (hasSpell)
                {
                    var spellType = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CastersShieldSpellTypes);
                    var spellLevel = spellGenerator.GenerateLevel(PowerConstants.Medium);
                    var spell = spellGenerator.Generate(spellType, spellLevel);
                    var formattedSpell = string.Format("{0} ({1}, {2})", spell, spellType, spellLevel);
                    gear.Contents.Add(formattedSpell);
                }
            }

            gear.Name = RenameGear(gear.Name);
            gear.Quantity = GetQuantity(gear);

            if (gear.Name == WeaponConstants.SlayingArrow || gear.Name == WeaponConstants.GreaterSlayingArrow)
            {
                var designatedFoe = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes);
                var trait = string.Format("Designated Foe: {0}", designatedFoe);
                gear.Traits.Add(trait);
            }

            if (gear.IsMagical == false && gear.ItemType != ItemTypeConstants.Armor)
            {
                var size = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
                gear.Traits.Add(size);
            }

            if (gear.IsMagical)
                gear.Traits.Add(TraitConstants.Masterwork);

            if (gear.ItemType != ItemTypeConstants.Armor)
                return gear;

            var armor = new Armor();
            gear.Clone(armor);

            var baseName = armor.BaseNames.Single();
            var armorSelection = armorDataSelector.Select(baseName);

            armor.ArmorBonus = armorSelection.ArmorBonus;
            armor.ArmorCheckPenalty = armorSelection.ArmorCheckPenalty;
            armor.MaxDexterityBonus = armorSelection.MaxDexterityBonus;
            armor.Size = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);

            return armor;
        }

        private int GetQuantity(Item gear)
        {
            if (gear.Attributes.Contains(AttributeConstants.Ammunition))
                return dice.Roll().d(50).AsSum();

            if (gear.Attributes.Contains(AttributeConstants.Thrown) && gear.Attributes.Contains(AttributeConstants.Melee) == false)
                return dice.Roll().d20().AsSum();

            return 1;
        }

        private string RenameGear(string oldName)
        {
            switch (oldName)
            {
                case WeaponConstants.SilverDagger: return WeaponConstants.Dagger;
                case WeaponConstants.LuckBlade0: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade1: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade2: return WeaponConstants.LuckBlade;
                case WeaponConstants.LuckBlade3: return WeaponConstants.LuckBlade;
                default: return oldName;
            }
        }

        private IEnumerable<SpecialAbility> GetSpecialAbilities(string specificGearType, string name)
        {
            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPESpecialAbilities, specificGearType);
            var abilityNames = collectionsSelector.SelectFrom(tableName, name);
            var abilityPrototypes = abilityNames.Select(n => new SpecialAbility { Name = n });
            var abilities = specialAbilitiesGenerator.GenerateFor(abilityPrototypes);

            return abilities;
        }

        public Item GenerateFrom(Item template)
        {
            var gear = template.Clone();

            var specificGearType = GetSpecificGearType(gear.Name);
            gear.ItemType = GetItemType(specificGearType);

            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, specificGearType);
            gear.Attributes = collectionsSelector.SelectFrom(tableName, gear.Name);
            gear.Magic.SpecialAbilities = GetSpecialAbilities(specificGearType, gear.Name);

            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, specificGearType);
            var traits = collectionsSelector.SelectFrom(tableName, gear.Name);

            foreach (var trait in traits)
                gear.Traits.Add(trait);

            return gear.SmartClone();
        }

        private string GetItemType(string specificGearType)
        {
            if (specificGearType == ItemTypeConstants.Weapon)
                return ItemTypeConstants.Weapon;

            return ItemTypeConstants.Armor;
        }

        private string GetSpecificGearType(string name)
        {
            var shields = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, AttributeConstants.Shield);
            if (shields.Contains(name))
                return AttributeConstants.Shield;

            var armors = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Armor);
            if (armors.Contains(name))
                return ItemTypeConstants.Armor;

            var weapons = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, ItemTypeConstants.Weapon);
            if (weapons.Contains(name))
                return ItemTypeConstants.Weapon;

            throw new ArgumentException($"Specific gear {name} is not a shield, armor, or weapon");
        }

        public bool TemplateIsSpecific(Item template)
        {
            var specificItems = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, AttributeConstants.Specific);
            return specificItems.Contains(template.Name);
        }
    }
}