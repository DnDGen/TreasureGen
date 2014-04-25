using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class SpecificGearGenerator : ISpecificGearGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IDice dice;
        private IAttributesSelector attributesSelector;
        private ISpecialAbilityAttributesSelector specialAbilityAttributesSelector;
        private IChargesGenerator chargesGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private ICurseGenerator curseGenerator;
        private IPercentileSelector percentileSelector;
        private ISpellGenerator spellGenerator;

        public SpecificGearGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IDice dice,
            IAttributesSelector attributesSelector, ISpecialAbilityAttributesSelector specialAbilityAttributesSelector,
            IChargesGenerator chargesGenerator, IIntelligenceGenerator intelligenceGenerator, ICurseGenerator curseGenerator,
            IPercentileSelector percentileSelector, ISpellGenerator spellGenerator)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.dice = dice;
            this.attributesSelector = attributesSelector;
            this.specialAbilityAttributesSelector = specialAbilityAttributesSelector;
            this.chargesGenerator = chargesGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.curseGenerator = curseGenerator;
            this.percentileSelector = percentileSelector;
            this.spellGenerator = spellGenerator;
        }

        public Item GenerateFrom(String power, String specificGearType)
        {
            var tableName = String.Format("{0}{1}", power, specificGearType);
            var roll = dice.Percentile();
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName, roll);
            var itemType = specificGearType.Replace("Specific", String.Empty);

            var gear = new Item();
            gear.Name = result.Type;
            gear.Magic.Bonus = Convert.ToInt32(result.Amount);
            gear.Magic.SpecialAbilities = GetSpecialAbilities(specificGearType, gear.Name);

            tableName = String.Format("{0}Attributes", specificGearType);
            gear.Attributes = attributesSelector.SelectFrom(tableName, gear.Name);

            tableName = String.Format("{0}Traits", specificGearType);
            var traits = attributesSelector.SelectFrom(tableName, gear.Name);
            gear.Traits.AddRange(traits);

            if (gear.Attributes.Contains(AttributeConstants.Charged))
                gear.Magic.Charges = chargesGenerator.GenerateFor(itemType, gear.Name);

            if (gear.Name == "Javelin of lightning")
            {
                gear.IsMagical = true;
            }
            else if (gear.Name == ArmorConstants.CastersShield && dice.Percentile() > 50)
            {
                roll = dice.Percentile();
                var spellType = percentileSelector.SelectFrom("CastersShieldSpellTypes", roll);
                var spellLevel = spellGenerator.GenerateLevel(PowerConstants.Medium);
                var spell = spellGenerator.Generate(spellType, spellLevel);
                var formattedSpell = String.Format("{0} ({1}, {2})", spell, spellType, spellLevel);
                gear.Contents.Add(formattedSpell);
            }

            gear.Name = RenameGear(gear.Name);

            if (intelligenceGenerator.IsIntelligent(itemType, gear.Attributes, gear.IsMagical))
                gear.Magic.Intelligence = intelligenceGenerator.GenerateFor(gear.Magic);

            if (curseGenerator.HasCurse(gear.IsMagical))
            {
                var curse = curseGenerator.GenerateCurse();
                if (curse == "SpecificCursedItem")
                    return curseGenerator.GenerateSpecificCursedItem();

                gear.Magic.Curse = curse;
            }

            return gear;
        }

        private String RenameGear(String oldName)
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

        private IEnumerable<SpecialAbility> GetSpecialAbilities(String specificGearType, String name)
        {
            var tableName = String.Format("{0}SpecialAbilities", specificGearType);
            var abilityNames = attributesSelector.SelectFrom(tableName, name);

            return abilityNames.Select(n => ReconstituteAbility(n));
        }

        private SpecialAbility ReconstituteAbility(String name)
        {
            var abilityResult = specialAbilityAttributesSelector.SelectFrom("SpecialAbilityAttributes", name);
            var ability = new SpecialAbility();

            ability.Name = name;
            ability.AttributeRequirements = attributesSelector.SelectFrom("SpecialAbilityAttributeRequirements", abilityResult.BaseName);
            ability.BaseName = abilityResult.BaseName;
            ability.BonusEquivalent = abilityResult.BonusEquivalent;
            ability.Strength = abilityResult.Strength;

            return ability;
        }
    }
}