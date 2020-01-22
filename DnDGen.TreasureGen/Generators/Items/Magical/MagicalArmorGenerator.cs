using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using System.Collections.Generic;
using System.Linq;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class MagicalArmorGenerator : MagicalItemGenerator
    {
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ICollectionSelector collectionsSelector;
        private readonly ISpecialAbilitiesGenerator specialAbilitiesGenerator;
        private readonly ISpecificGearGenerator specificGearGenerator;
        private readonly Generator generator;
        private readonly JustInTimeFactory justInTimeFactory;

        public MagicalArmorGenerator(
            ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            ITreasurePercentileSelector percentileSelector,
            ICollectionSelector collectionsSelector,
            ISpecialAbilitiesGenerator specialAbilitiesGenerator,
            ISpecificGearGenerator specificGearGenerator,
            Generator generator,
            JustInTimeFactory justInTimeFactory)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.specialAbilitiesGenerator = specialAbilitiesGenerator;
            this.specificGearGenerator = specificGearGenerator;
            this.generator = generator;
            this.justInTimeFactory = justInTimeFactory;
        }

        public Item GenerateFrom(string power)
        {
            var prototype = GenerateRandomPrototype(power);
            var armor = GenerateFromPrototype(prototype);

            if (!specificGearGenerator.IsSpecific(armor))
            {
                var abilityCount = armor.Magic.SpecialAbilities.Count();
                armor.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(armor, power, abilityCount);
            }

            return armor;
        }

        private Armor GenerateRandomPrototype(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
            var selection = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var abilityCount = 0;

            while (selection.Type == "SpecialAbility")
            {
                abilityCount += selection.Amount;
                selection = typeAndAmountPercentileSelector.SelectFrom(tableName);
            }

            var prototype = new Armor();

            if (selection.Amount == 0)
            {
                var specificItem = specificGearGenerator.GenerateRandomPrototypeFrom(power, selection.Type);
                specificItem.CloneInto(prototype);

                return prototype;
            }

            tableName = string.Format(TableNameConstants.Percentiles.Formattable.ARMORTYPETypes, selection.Type);
            prototype.Name = percentileSelector.SelectFrom(tableName);
            prototype.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, prototype.Name);
            prototype.Magic.Bonus = selection.Amount;
            prototype.Magic.SpecialAbilities = Enumerable.Repeat(new SpecialAbility(), abilityCount);

            return prototype;
        }

        private Armor GenerateFromPrototype(Armor prototype)
        {
            if (specificGearGenerator.IsSpecific(prototype))
            {
                var specificArmor = specificGearGenerator.GenerateFrom(prototype);
                specificArmor.Quantity = 1;
                return specificArmor as Armor;
            }

            var mundaneArmorGenerator = justInTimeFactory.Build<MundaneItemGenerator>(ItemTypeConstants.Armor);
            var armor = mundaneArmorGenerator.GenerateFrom(prototype);

            armor.Magic.Bonus = prototype.Magic.Bonus;
            armor.Magic.Charges = prototype.Magic.Charges;
            armor.Magic.Curse = prototype.Magic.Curse;
            armor.Magic.Intelligence = prototype.Magic.Intelligence;
            armor.Magic.SpecialAbilities = prototype.Magic.SpecialAbilities;

            if (armor.IsMagical)
                armor.Traits.Add(TraitConstants.Masterwork);

            return armor as Armor;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var armorTemplate = new Armor();
            template.CloneInto(armorTemplate);
            armorTemplate.Magic.SpecialAbilities = Enumerable.Empty<SpecialAbility>();
            armorTemplate.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, armorTemplate.Name);

            var armor = GenerateFromPrototype(armorTemplate);

            armor.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(template.Magic.SpecialAbilities);

            return armor;
        }

        public Item GenerateFrom(string power, IEnumerable<string> subset, params string[] traits)
        {
            var prototype = generator.Generate(
                () => GenerateRandomPrototype(power),
                a => subset.Any(n => a.NameMatches(n)),
                () => CreateDefaultPrototype(power, subset),
                a => $"{a.Name} is not in subset [{string.Join(", ", subset)}]",
                $"Magical armor from [{string.Join(", ", subset)}]");

            prototype.Traits = new HashSet<string>(traits);
            var armor = GenerateFromPrototype(prototype);

            if (!specificGearGenerator.IsSpecific(armor))
            {
                var abilityCount = armor.Magic.SpecialAbilities.Count();
                armor.Magic.SpecialAbilities = specialAbilitiesGenerator.GenerateFor(armor, power, abilityCount);
            }

            return armor;
        }

        private Armor CreateDefaultPrototype(string power, IEnumerable<string> subset)
        {
            var prototype = new Armor();
            prototype.Name = collectionsSelector.SelectRandomFrom(subset);
            prototype.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, prototype.Name);

            if (!specificGearGenerator.IsSpecific(prototype))
            {
                var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.Armor);
                var results = typeAndAmountPercentileSelector.SelectAllFrom(tableName);
                prototype.Magic.Bonus = results.Where(r => r.Type != "SpecialAbility" && r.Amount > 0).Select(r => r.Amount).Min();
            }

            return prototype;
        }
    }
}