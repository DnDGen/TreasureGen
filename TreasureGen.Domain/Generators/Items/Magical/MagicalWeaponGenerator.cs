using RollGen;
using System;
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
    internal class MagicalWeaponGenerator : MagicalItemGenerator
    {
        private readonly ICollectionsSelector collectionsSelector;
        private readonly IPercentileSelector percentileSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly ISpecificGearGenerator specificGearGenerator;
        private readonly IBooleanPercentileSelector booleanPercentileSelector;
        private readonly ISpellGenerator spellGenerator;
        private readonly Dice dice;
        private readonly Generator generator;
        private readonly IMundaneItemGeneratorRuntimeFactory mundaneGeneratorFactory;

        public MagicalWeaponGenerator(
            ICollectionsSelector collectionsSelector,
            IPercentileSelector percentileSelector,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            ISpecificGearGenerator specificGearGenerator,
            IBooleanPercentileSelector booleanPercentileSelector,
            ISpellGenerator spellGenerator,
            Dice dice,
            Generator generator,
            IMundaneItemGeneratorRuntimeFactory mundaneGeneratorFactory)
        {
            this.collectionsSelector = collectionsSelector;
            this.percentileSelector = percentileSelector;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.specificGearGenerator = specificGearGenerator;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.spellGenerator = spellGenerator;
            this.dice = dice;
            this.generator = generator;
            this.mundaneGeneratorFactory = mundaneGeneratorFactory;
        }

        public Item GenerateAtPower(string power)
        {
            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
            var bonus = percentileSelector.SelectFrom(tablename);
            var specialAbilitiesCount = 0;

            while (bonus == "SpecialAbility")
            {
                specialAbilitiesCount++;
                bonus = percentileSelector.SelectFrom(tablename);
            }

            if (bonus == ItemTypeConstants.Weapon)
                return specificGearGenerator.GenerateFrom(power, ItemTypeConstants.Weapon);

            var type = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MagicalWeaponTypes);
            tablename = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, type);

            var name = percentileSelector.SelectFrom(tablename);
            var template = CreateTemplate(name, power);
            var weapon = Generate(template);

            weapon.Magic.Bonus = Convert.ToInt32(bonus);
            weapon.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(weapon, power, specialAbilitiesCount);

            if (weapon.Magic.SpecialAbilities.Any(a => a.Name == SpecialAbilityConstants.SpellStoring))
            {
                var shouldStoreSpell = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.SpellStoringContainsSpell);

                if (shouldStoreSpell)
                {
                    var spellType = spellGenerator.GenerateType();
                    var level = spellGenerator.GenerateLevel(PowerConstants.Minor);
                    var spell = spellGenerator.Generate(spellType, level);

                    weapon.Contents.Add(spell);
                }
            }

            if (weapon.IsMagical)
                weapon.Traits.Add(TraitConstants.Masterwork);

            return weapon;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            if (specificGearGenerator.TemplateIsSpecific(template))
            {
                var specificWeapon = specificGearGenerator.GenerateFrom(template);
                return specificWeapon;
            }

            var mundaneWeaponGenerator = mundaneGeneratorFactory.CreateGeneratorOf(ItemTypeConstants.Weapon);
            var weapon = mundaneWeaponGenerator.GenerateFrom(template, allowRandomDecoration);
            weapon.Magic.Bonus = template.Magic.Bonus;
            weapon.Magic.Charges = template.Magic.Charges;
            weapon.Magic.Curse = template.Magic.Curse;
            weapon.Magic.Intelligence = template.Magic.Intelligence;
            weapon.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(template.Magic.SpecialAbilities);

            if (weapon.IsMagical)
                weapon.Traits.Add(TraitConstants.Masterwork);

            if (weapon.Attributes.Contains(AttributeConstants.Ammunition))
                weapon.Magic.Intelligence = new Intelligence();

            return weapon;
        }

        public Item GenerateFromSubset(string power, IEnumerable<string> subset)
        {
            var weapon = generator.Generate(
                () => GenerateAtPower(power),
                w => subset.Any(n => w.NameMatches(n)),
                () => GetDefaultWeapon(power, subset),
                $"Magical weapon from [{string.Join(", ", subset)}]");

            return weapon;
        }

        private Item GetDefaultWeapon(string power, IEnumerable<string> subset)
        {
            var name = collectionsSelector.SelectRandomFrom(subset);
            var template = CreateTemplate(name, power);
            var defaultWeapon = Generate(template);

            return defaultWeapon;
        }

        private Item CreateTemplate(string name, string power)
        {
            var template = new Item();
            template.Name = name;
            template.Quantity = 0;

            if (!specificGearGenerator.TemplateIsSpecific(template))
            {
                var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
                var bonuses = percentileSelector.SelectAllFrom(tablename);
                var junk = 0;
                bonuses = bonuses.Where(b => int.TryParse(b, out junk));

                template.Magic.Bonus = bonuses.Select(b => Convert.ToInt32(b)).Min();
            }

            return template;
        }
    }
}