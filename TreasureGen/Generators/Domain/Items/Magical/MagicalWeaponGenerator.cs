using RollGen;
using System;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Items.Magical
{
    public class MagicalWeaponGenerator : MagicalItemGenerator
    {
        private IAttributesSelector attributesSelector;
        private IPercentileSelector percentileSelector;
        private IAmmunitionGenerator ammunitionGenerator;
        private ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private ISpecificGearGenerator specificGearGenerator;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private ISpellGenerator spellGenerator;
        private Dice dice;

        public MagicalWeaponGenerator(IAttributesSelector attributesSelector, IPercentileSelector percentileSelector, IAmmunitionGenerator ammunitionGenerator, ISpecialAbilitiesGenerator specialAbilitiesGenerator, ISpecificGearGenerator specificGearGenerator, IBooleanPercentileSelector booleanPercentileSelector, ISpellGenerator spellGenerator, Dice dice)
        {
            this.attributesSelector = attributesSelector;
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

                tablename = string.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, weapon.ItemType);
                weapon.Attributes = attributesSelector.SelectFrom(tablename, weapon.Name);
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

            var thrownWeapons = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.AmmunitionAttributes, AttributeConstants.Thrown);
            if (thrownWeapons.Contains(weapon.Name))
                weapon.Quantity = dice.Roll().d20();

            return weapon;
        }
    }
}