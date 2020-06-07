using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class MagicalWeaponGenerator : MagicalItemGenerator
    {
        private readonly ICollectionSelector collectionsSelector;
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly ISpecificGearGenerator specificGearGenerator;
        private readonly ISpellGenerator spellGenerator;
        private readonly JustInTimeFactory justInTimeFactory;

        private const string SpecialAbility = "SpecialAbility";

        public MagicalWeaponGenerator(
            ICollectionSelector collectionsSelector,
            ITreasurePercentileSelector percentileSelector,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            ISpecificGearGenerator specificGearGenerator,
            ISpellGenerator spellGenerator,
            JustInTimeFactory justInTimeFactory)
        {
            this.collectionsSelector = collectionsSelector;
            this.percentileSelector = percentileSelector;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.specificGearGenerator = specificGearGenerator;
            this.spellGenerator = spellGenerator;
            this.justInTimeFactory = justInTimeFactory;
        }

        public Item GenerateRandom(string power)
        {
            var name = GenerateRandomName();
            return GenerateWeapon(power, name, false);
        }

        public Item Generate(string power, string itemName, params string[] traits)
        {
            var isSpecific = specificGearGenerator.IsSpecific(ItemTypeConstants.Weapon, itemName);
            return GenerateWeapon(power, itemName, isSpecific, traits);
        }

        private Item GenerateWeapon(string power, string name, bool isSpecific, params string[] traits)
        {
            var prototype = GeneratePrototype(power, name, isSpecific, traits);
            var weapon = GenerateFromPrototype(prototype, true);

            if (!specificGearGenerator.IsSpecific(prototype))
            {
                weapon = GenerateRandomSpecialAbilities(weapon, power);
            }

            return weapon;
        }

        private string GenerateRandomName()
        {
            var type = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MagicalWeaponTypes);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, type);
            var name = percentileSelector.SelectFrom(tableName);

            return name;
        }

        private Weapon GeneratePrototype(string power, string itemName, bool isSpecific, params string[] traits)
        {
            var prototype = new Weapon();

            if (isSpecific)
            {
                var specificItem = specificGearGenerator.GeneratePrototypeFrom(power, ItemTypeConstants.Weapon, itemName, traits);
                specificItem.CloneInto(prototype);

                return prototype;
            }

            var canBeSpecific = specificGearGenerator.CanBeSpecific(power, ItemTypeConstants.Weapon, itemName);
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            var bonus = string.Empty;
            var specialAbilitiesCount = 0;

            do bonus = percentileSelector.SelectFrom(tableName);
            while (!canBeSpecific && bonus == ItemTypeConstants.Weapon);

            while (bonus == SpecialAbility)
            {
                specialAbilitiesCount++;

                do bonus = percentileSelector.SelectFrom(tableName);
                while (!canBeSpecific && bonus == ItemTypeConstants.Weapon);
            }

            prototype.Traits = new HashSet<string>(traits);

            if (bonus == ItemTypeConstants.Weapon && canBeSpecific)
            {
                var specificName = specificGearGenerator.GenerateNameFrom(power, ItemTypeConstants.Weapon, itemName);
                var specificItem = specificGearGenerator.GeneratePrototypeFrom(power, ItemTypeConstants.Weapon, specificName, traits);
                specificItem.CloneInto(prototype);

                return prototype;
            }

            prototype.Name = itemName;
            prototype.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, itemName);
            prototype.Quantity = 0;
            prototype.Magic.Bonus = Convert.ToInt32(bonus);
            prototype.Magic.SpecialAbilities = Enumerable.Repeat(new SpecialAbility(), specialAbilitiesCount);
            prototype.ItemType = ItemTypeConstants.Weapon;

            return prototype;
        }

        private Weapon GenerateFromPrototype(Item prototype, bool allowDecoration)
        {
            if (specificGearGenerator.IsSpecific(prototype))
            {
                var specificWeapon = specificGearGenerator.GenerateFrom(prototype);
                return specificWeapon as Weapon;
            }

            var mundaneWeaponGenerator = justInTimeFactory.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon);
            var weapon = mundaneWeaponGenerator.Generate(prototype, allowDecoration);

            weapon.Magic.Bonus = prototype.Magic.Bonus;
            weapon.Magic.Charges = prototype.Magic.Charges;
            weapon.Magic.Curse = prototype.Magic.Curse;
            weapon.Magic.Intelligence = prototype.Magic.Intelligence;
            weapon.Magic.SpecialAbilities = prototype.Magic.SpecialAbilities;

            if (weapon.Attributes.Contains(AttributeConstants.Ammunition))
                weapon.Magic.Intelligence = new Intelligence();

            if (weapon.IsMagical)
                weapon.Traits.Add(TraitConstants.Masterwork);

            return weapon as Weapon;
        }

        private Weapon GenerateRandomSpecialAbilities(Weapon weapon, string power)
        {
            weapon.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(weapon, power, weapon.Magic.SpecialAbilities.Count());

            if (weapon.Magic.SpecialAbilities.Any(a => a.Name == SpecialAbilityConstants.SpellStoring))
            {
                var shouldStoreSpell = percentileSelector.SelectFrom<bool>(TableNameConstants.Percentiles.Set.SpellStoringContainsSpell);

                if (shouldStoreSpell)
                {
                    var spellType = spellGenerator.GenerateType();
                    var level = spellGenerator.GenerateLevel(PowerConstants.Minor);
                    var spell = spellGenerator.Generate(spellType, level);

                    weapon.Contents.Add(spell);
                }
            }

            return weapon;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            template.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, template.Name);

            var weapon = new Weapon();

            if (template is Weapon)
                weapon = template.Clone() as Weapon;
            else
                template.CloneInto(weapon);

            weapon = GenerateFromPrototype(weapon, allowRandomDecoration);

            weapon.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(template.Magic.SpecialAbilities);

            return weapon;
        }
    }
}