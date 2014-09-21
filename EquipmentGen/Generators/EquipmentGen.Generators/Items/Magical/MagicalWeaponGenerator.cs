using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class MagicalWeaponGenerator : IMagicalItemGenerator
    {
        private IAttributesSelector attributesSelector;
        private IPercentileSelector percentileSelector;
        private IAmmunitionGenerator ammunitionGenerator;
        private ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private ISpecificGearGenerator specificGearGenerator;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private ISpellGenerator spellGenerator;

        public MagicalWeaponGenerator(IAttributesSelector attributesSelector, IPercentileSelector percentileSelector, IAmmunitionGenerator ammunitionGenerator, ISpecialAbilitiesGenerator specialAbilitiesGenerator, ISpecificGearGenerator specificGearGenerator, IBooleanPercentileSelector booleanPercentileSelector, ISpellGenerator spellGenerator)
        {
            this.attributesSelector = attributesSelector;
            this.percentileSelector = percentileSelector;
            this.ammunitionGenerator = ammunitionGenerator;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.specificGearGenerator = specificGearGenerator;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.spellGenerator = spellGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var tablename = String.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Weapon);
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
            tablename = String.Format(TableNameConstants.Percentiles.Formattable.WEAPONTYPEWeapons, type);
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

                tablename = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, weapon.ItemType);
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

            return weapon;
        }
    }
}