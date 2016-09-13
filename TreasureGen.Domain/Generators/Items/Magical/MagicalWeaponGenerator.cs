using RollGen;
using System;
using System.Linq;
using TreasureGen.Domain.Generators.Items.Mundane;
using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class MagicalWeaponGenerator : MagicalItemGenerator
    {
        private ICollectionsSelector collectionsSelector;
        private IPercentileSelector percentileSelector;
        private IAmmunitionGenerator ammunitionGenerator;
        private ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private ISpecificGearGenerator specificGearGenerator;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private ISpellGenerator spellGenerator;
        private Dice dice;

        public MagicalWeaponGenerator(ICollectionsSelector collectionsSelector, IPercentileSelector percentileSelector, IAmmunitionGenerator ammunitionGenerator, ISpecialAbilitiesGenerator specialAbilitiesGenerator, ISpecificGearGenerator specificGearGenerator, IBooleanPercentileSelector booleanPercentileSelector, ISpellGenerator spellGenerator, Dice dice)
        {
            this.collectionsSelector = collectionsSelector;
            this.percentileSelector = percentileSelector;
            this.ammunitionGenerator = ammunitionGenerator;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.specificGearGenerator = specificGearGenerator;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.spellGenerator = spellGenerator;
            this.dice = dice;
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
                return specificGearGenerator.GenerateFrom(power, bonus);

            var type = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.WeaponTypes);
            tablename = string.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, type);
            var name = percentileSelector.SelectFrom(tablename);

            var weapon = new Item();

            if (name == AttributeConstants.Ammunition)
            {
                weapon = ammunitionGenerator.Generate();
            }
            else
            {
                weapon.ItemType = ItemTypeConstants.Weapon;
                weapon.Name = name;

                if (weapon.Name.Contains("Composite"))
                {
                    weapon.Name = GetCompositeBowName(name);
                    var compositeStrengthBonus = GetCompositeBowBonus(name);
                    weapon.Traits.Add(compositeStrengthBonus);
                }

                tablename = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, weapon.ItemType);
                weapon.Attributes = collectionsSelector.SelectFrom(tablename, weapon.Name);
            }

            weapon.Magic.Bonus = Convert.ToInt32(bonus);
            weapon.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(weapon.ItemType, weapon.Attributes, power, weapon.Magic.Bonus, specialAbilitiesCount);

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

            if (weapon.Attributes.Contains(AttributeConstants.Thrown) && weapon.Attributes.Contains(AttributeConstants.Melee) == false)
                weapon.Quantity = dice.Roll().d20();

            return weapon;
        }

        private string GetCompositeBowBonus(string weaponName)
        {
            var compositeBonusStartIndex = weaponName.IndexOf('+');
            var compositeBonus = weaponName.Substring(compositeBonusStartIndex, 2);
            return $"{compositeBonus} Strength bonus";
        }

        private string GetCompositeBowName(string weaponName)
        {
            switch (weaponName)
            {
                case WeaponConstants.CompositePlus0Longbow:
                case WeaponConstants.CompositePlus1Longbow:
                case WeaponConstants.CompositePlus2Longbow:
                case WeaponConstants.CompositePlus3Longbow:
                case WeaponConstants.CompositePlus4Longbow: return WeaponConstants.CompositeLongbow;
                case WeaponConstants.CompositePlus0Shortbow:
                case WeaponConstants.CompositePlus1Shortbow:
                case WeaponConstants.CompositePlus2Shortbow: return WeaponConstants.CompositeShortbow;
                default: throw new ArgumentException($"Composite bow {weaponName} does not map to a known bow");
            }
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            template.ItemType = ItemTypeConstants.Weapon;
            var weapon = template.Copy();

            if (specificGearGenerator.TemplateIsSpecific(template))
            {
                weapon = specificGearGenerator.GenerateFrom(template);
            }
            else if (ammunitionGenerator.TemplateIsAmmunition(template))
            {
                weapon = ammunitionGenerator.GenerateFrom(template);
            }
            else
            {
                var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, weapon.ItemType);
                weapon.Attributes = collectionsSelector.SelectFrom(tableName, weapon.Name);
            }

            var abilityNames = template.Magic.SpecialAbilities.Select(a => a.Name);
            weapon.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(abilityNames);

            return weapon;
        }
    }
}