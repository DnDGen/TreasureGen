using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class SpecialAbilitiesGenerator : ISpecialAbilitiesGenerator
    {
        private ISpecialAbilityDataProvider specialAbilityDataProvider;
        private IAttributesProvider typesProvider;
        private IPercentileResultProvider percentileResultProvider;
        private IDice dice;
        private ISpellGenerator spellGenerator;

        public SpecialAbilitiesGenerator(ISpecialAbilityDataProvider specialAbilityDataProvider, IAttributesProvider typesProvider,
            IPercentileResultProvider percentileResultProvider, IDice dice, ISpellGenerator spellGenerator)
        {
            this.specialAbilityDataProvider = specialAbilityDataProvider;
            this.typesProvider = typesProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.dice = dice;
            this.spellGenerator = spellGenerator;
        }

        public IEnumerable<SpecialAbility> GenerateFor(IEnumerable<String> attributes, String power, Int32 magicalBonus, Int32 quantity)
        {
            if (magicalBonus <= 0)
                return Enumerable.Empty<SpecialAbility>();

            var abilities = new List<SpecialAbility>();
            var bonusSum = magicalBonus;

            while (quantity > 0 && bonusSum < 10)
            {
                var ability = GenerateFor(attributes, power);
                if (ability.Name == "BonusSpecialAbility")
                {
                    quantity++;
                    continue;
                }

                if (bonusSum + ability.BonusEquivalent > 10)
                    continue;

                if (abilities.Any(a => a.CoreName == ability.CoreName))
                {
                    var previousAbility = abilities.First(a => a.CoreName == ability.CoreName);
                    if (previousAbility.Strength < ability.Strength)
                    {
                        bonusSum -= previousAbility.BonusEquivalent;
                        abilities.Remove(previousAbility);
                    }
                    else
                    {
                        continue;
                    }
                }

                quantity--;
                bonusSum += ability.BonusEquivalent;
                abilities.Add(ability);
            }

            return abilities;
        }

        public SpecialAbility GenerateFor(IEnumerable<String> attributes, String power)
        {
            var tableName = GetTableName(attributes, power);
            var abilityName = percentileResultProvider.GetResultFrom(tableName);

            if (abilityName == "BonusSpecialAbility")
                return new SpecialAbility { Name = abilityName };

            var ability = specialAbilityDataProvider.GetDataFor(abilityName);

            while (!AllTypeRequirementsMet(ability.AttributeRequirements, attributes))
            {
                abilityName = percentileResultProvider.GetResultFrom(tableName);
                ability = specialAbilityDataProvider.GetDataFor(abilityName);
            }

            if (ability.CoreName == "Bane")
            {
                var designatedFoe = percentileResultProvider.GetResultFrom("DesignatedFoes");
                ability.Name = String.Format("{0}bane", designatedFoe);
            }
            else if (ability.CoreName == "Spell storing" && dice.Percentile() > 50)
            {
                var level = dice.d3();
                var spellType = spellGenerator.GenerateType();
                var spell = spellGenerator.GenerateOfTypeAtLevel(spellType, level);
                ability.Name = String.Format("Spell storing (contains {0})", spell);
            }

            return ability;
        }

        private String GetTableName(IEnumerable<String> attributes, String power)
        {
            if (!attributes.Any())
                throw new ArgumentException("no attributes when getting table name for special abilities");

            if (attributes.Contains(AttributeConstants.Shield))
                return String.Format("{0}ShieldSpecialAbilities", power);

            if (attributes.Contains(AttributeConstants.Melee))
                return String.Format("{0}MeleeWeaponSpecialAbilities", power);

            if (attributes.Contains(AttributeConstants.Ranged))
                return String.Format("{0}RangedWeaponSpecialAbilities", power);

            if (attributes.Contains(ItemTypeConstants.Armor))
                return String.Format("{0}ArmorSpecialAbilities", power);

            var attributesString = String.Join(",", attributes);
            throw new ArgumentException("invalid attributes for special abilities: {0}", attributesString);
        }

        private Boolean AllTypeRequirementsMet(IEnumerable<String> requirements, IEnumerable<String> types)
        {
            return requirements.All(r => types.Contains(r));
        }
    }
}