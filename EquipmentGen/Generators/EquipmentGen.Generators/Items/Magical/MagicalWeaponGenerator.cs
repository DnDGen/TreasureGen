using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class MagicalWeaponGenerator : IMagicalItemGenerator
    {
        private IAttributesSelector attributesSelector;
        private IPercentileSelector percentileSelector;
        private IAmmunitionGenerator ammunitionGenerator;
        private ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private ISpecificGearGenerator specificGearGenerator;
        private IMagicalItemTraitsGenerator magicalItemTraitsGenerator;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private ISpellGenerator spellGenerator;
        private IDice dice;

        public MagicalWeaponGenerator(IAttributesSelector attributesSelector, IPercentileSelector percentileSelector, IAmmunitionGenerator ammunitionGenerator,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator, ISpecificGearGenerator specificGearGenerator, IMagicalItemTraitsGenerator magicalItemTraitsGenerator,
            IBooleanPercentileSelector booleanPercentileSelector, ISpellGenerator spellGenerator, IDice dice)
        {
            this.attributesSelector = attributesSelector;
            this.percentileSelector = percentileSelector;
            this.ammunitionGenerator = ammunitionGenerator;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.specificGearGenerator = specificGearGenerator;
            this.magicalItemTraitsGenerator = magicalItemTraitsGenerator;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.spellGenerator = spellGenerator;
            this.dice = dice;
        }

        public Item GenerateAtPower(String power)
        {
            var tablename = String.Format("{0}Weapons", power);
            var bonus = percentileSelector.SelectFrom(tablename);
            var specialAbilitiesCount = 0;

            while (bonus == "SpecialAbility")
            {
                specialAbilitiesCount++;
                bonus = percentileSelector.SelectFrom(tablename);
            }

            if (bonus == "SpecificWeapon")
                return specificGearGenerator.GenerateFrom(power, bonus);

            var type = percentileSelector.SelectFrom("WeaponTypes");
            tablename = String.Format("{0}Weapons", type);
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
                weapon.Attributes = attributesSelector.SelectFrom("WeaponAttributes", weapon.Name);
            }

            var traits = magicalItemTraitsGenerator.GenerateFor(weapon.ItemType);
            weapon.Traits.AddRange(traits);
            weapon.Magic.Bonus = Convert.ToInt32(bonus);
            weapon.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(weapon.ItemType, weapon.Attributes, power, weapon.Magic.Bonus,
                specialAbilitiesCount);

            if (weapon.Magic.SpecialAbilities.Any(a => a.Name == SpecialAbilityConstants.SpellStoring))
            {
                var shouldStoreSpell = booleanPercentileSelector.SelectFrom("SpellStoringContainsSpell");

                if (shouldStoreSpell)
                {
                    var spellType = spellGenerator.GenerateType();
                    var level = dice.d4() - 1;
                    var spell = spellGenerator.Generate(spellType, level);

                    weapon.Contents.Add(spell);
                }
            }

            return weapon;
        }
    }
}