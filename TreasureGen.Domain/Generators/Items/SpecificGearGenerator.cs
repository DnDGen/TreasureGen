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
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items
{
    internal class SpecificGearGenerator : ISpecificGearGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ICollectionsSelector collectionsSelector;
        private readonly IChargesGenerator chargesGenerator;
        private readonly IPercentileSelector percentileSelector;
        private readonly ISpellGenerator spellGenerator;
        private readonly IBooleanPercentileSelector booleanPercentileSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly Dice dice;
        private readonly IMundaneItemGeneratorFactory mundaneGeneratorFactory;

        public SpecificGearGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            ICollectionsSelector collectionsSelector,
            IChargesGenerator chargesGenerator,
            IPercentileSelector percentileSelector,
            ISpellGenerator spellGenerator,
            IBooleanPercentileSelector booleanPercentileSelector,
            Dice dice,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            IMundaneItemGeneratorFactory mundaneGeneratorFactory)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.chargesGenerator = chargesGenerator;
            this.percentileSelector = percentileSelector;
            this.spellGenerator = spellGenerator;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.dice = dice;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.mundaneGeneratorFactory = mundaneGeneratorFactory;
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

            if (gear.Name == WeaponConstants.SlayingArrow || gear.Name == WeaponConstants.GreaterSlayingArrow)
            {
                var designatedFoe = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.DesignatedFoes);
                var trait = string.Format("Designated Foe: {0}", designatedFoe);
                gear.Traits.Add(trait);
            }

            if (gear.IsMagical)
                gear.Traits.Add(TraitConstants.Masterwork);

            if (gear.ItemType == ItemTypeConstants.Armor)
                return GetArmor(gear);

            if (gear.ItemType == ItemTypeConstants.Weapon)
                return GetWeapon(gear);

            return gear;
        }

        private Item GetArmor(Item gear)
        {
            var template = new Armor();
            template.Name = gear.BaseNames.First();

            var mundaneArmorGenerator = mundaneGeneratorFactory.CreateGeneratorOf(ItemTypeConstants.Armor);
            var armor = mundaneArmorGenerator.GenerateFrom(template);

            gear.Clone(armor);

            if (armor.IsMagical)
                armor.Traits.Add(TraitConstants.Masterwork);

            return armor;
        }

        private Item GetWeapon(Item gear)
        {
            var template = new Weapon();
            template.Name = gear.BaseNames.First();
            template.Quantity = 0;

            var mundaneWeaponGenerator = mundaneGeneratorFactory.CreateGeneratorOf(ItemTypeConstants.Weapon);
            var weapon = mundaneWeaponGenerator.GenerateFrom(template);

            gear.Quantity = weapon.Quantity;
            gear.Clone(weapon);

            if (weapon.IsMagical)
                weapon.Traits.Add(TraitConstants.Masterwork);

            if (weapon.Attributes.Contains(AttributeConstants.Ammunition) || weapon.Attributes.Contains(AttributeConstants.OneTimeUse))
                weapon.Magic.Intelligence = new Intelligence();

            return weapon;
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
            gear.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, gear.Name);

            var tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPEAttributes, specificGearType);
            gear.Attributes = collectionsSelector.SelectFrom(tableName, gear.Name);
            gear.Magic.SpecialAbilities = GetSpecialAbilities(specificGearType, gear.Name);

            tableName = string.Format(TableNameConstants.Collections.Formattable.SpecificITEMTYPETraits, specificGearType);
            var traits = collectionsSelector.SelectFrom(tableName, gear.Name);

            foreach (var trait in traits)
                gear.Traits.Add(trait);

            if (gear.ItemType == ItemTypeConstants.Armor)
                return GetArmor(gear);

            if (gear.ItemType == ItemTypeConstants.Weapon)
                return GetWeapon(gear);

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