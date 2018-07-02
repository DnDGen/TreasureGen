using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Selectors.Percentiles;
using TreasureGen.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Generators.Items.Magical
{
    internal class MagicalWeaponGenerator : MagicalItemGenerator
    {
        private readonly ICollectionSelector collectionsSelector;
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly ISpecificGearGenerator specificGearGenerator;
        private readonly ISpellGenerator spellGenerator;
        private readonly Generator generator;
        private readonly JustInTimeFactory justInTimeFactory;

        public MagicalWeaponGenerator(
            ICollectionSelector collectionsSelector,
            ITreasurePercentileSelector percentileSelector,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            ISpecificGearGenerator specificGearGenerator,
            ISpellGenerator spellGenerator,
            Generator generator,
            JustInTimeFactory justInTimeFactory)
        {
            this.collectionsSelector = collectionsSelector;
            this.percentileSelector = percentileSelector;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.specificGearGenerator = specificGearGenerator;
            this.spellGenerator = spellGenerator;
            this.generator = generator;
            this.justInTimeFactory = justInTimeFactory;
        }

        public Item GenerateFrom(string power)
        {
            var prototype = GenerateRandomPrototype(power);
            var weapon = GenerateFromPrototype(prototype, true);

            if (!specificGearGenerator.IsSpecific(prototype))
            {
                weapon = GenerateRandomSpecialAbilities(weapon, power);
            }

            return weapon;
        }

        private Weapon GenerateRandomPrototype(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            var bonus = percentileSelector.SelectFrom(tableName);
            var specialAbilitiesCount = 0;

            while (bonus == "SpecialAbility")
            {
                specialAbilitiesCount++;
                bonus = percentileSelector.SelectFrom(tableName);
            }

            var prototype = new Weapon();

            if (bonus == ItemTypeConstants.Weapon)
            {
                var specificPrototype = specificGearGenerator.GenerateRandomPrototypeFrom(power, ItemTypeConstants.Weapon);
                specificPrototype.CloneInto(prototype);

                return prototype;
            }

            var type = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MagicalWeaponTypes);
            tableName = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, type);

            prototype.Name = percentileSelector.SelectFrom(tableName);
            prototype.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, prototype.Name);
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
            var weapon = mundaneWeaponGenerator.GenerateFrom(prototype, allowDecoration);

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

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
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

        public Item GenerateFrom(string power, IEnumerable<string> subset, params string[] traits)
        {
            var prototype = generator.Generate(
                () => GenerateRandomPrototype(power),
                w => subset.Any(n => w.NameMatches(n)),
                () => CreateDefaultPrototype(power, subset),
                w => $"{w.Name} is not in subset [{string.Join(", ", subset)}]",
                $"Magical weapon from [{string.Join(", ", subset)}]");

            prototype.Traits = new HashSet<string>(traits);
            var weapon = GenerateFromPrototype(prototype, true);

            if (!specificGearGenerator.IsSpecific(prototype))
            {
                weapon = GenerateRandomSpecialAbilities(weapon, power);
            }

            return weapon;
        }

        private Item CreateDefaultPrototype(string power, IEnumerable<string> subset)
        {
            var prototype = new Item();
            prototype.Name = collectionsSelector.SelectRandomFrom(subset);
            prototype.Quantity = 0;
            prototype.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, prototype.Name);

            if (!specificGearGenerator.IsSpecific(prototype))
            {
                var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
                var bonuses = percentileSelector.SelectAllFrom(tablename);
                var junk = 0;
                bonuses = bonuses.Where(b => int.TryParse(b, out junk));

                prototype.Magic.Bonus = bonuses.Select(b => Convert.ToInt32(b)).Min();
            }

            return prototype;
        }
    }
}