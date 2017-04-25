using RollGen;
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
    internal class CurseGenerator : ICurseGenerator
    {
        private readonly Dice dice;
        private readonly IPercentileSelector percentileSelector;
        private readonly IBooleanPercentileSelector booleanPercentileSelector;
        private readonly ICollectionsSelector collectionsSelector;
        private readonly Generator generator;
        private readonly MundaneItemGenerator mundaneArmorGenerator;
        private readonly MundaneItemGenerator mundaneWeaponGenerator;

        public CurseGenerator(Dice dice, IPercentileSelector percentileSelector, IBooleanPercentileSelector booleanPercentileSelector, ICollectionsSelector collectionsSelector, Generator generator, IMundaneItemGeneratorRuntimeFactory mundaneGeneratorFactory)
        {
            this.dice = dice;
            this.percentileSelector = percentileSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.generator = generator;

            mundaneArmorGenerator = mundaneGeneratorFactory.CreateGeneratorOf(ItemTypeConstants.Armor);
            mundaneWeaponGenerator = mundaneGeneratorFactory.CreateGeneratorOf(ItemTypeConstants.Weapon);
        }

        public bool HasCurse(bool isMagical)
        {
            return isMagical && booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IsItemCursed);
        }

        public string GenerateCurse()
        {
            var curse = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.Curses);

            if (curse == CurseConstants.Intermittent)
                return string.Format("{0} ({1})", curse, GetIntermittentFunctioning());

            if (curse == CurseConstants.Drawback)
                return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CurseDrawbacks);

            return curse;
        }

        private string GetIntermittentFunctioning()
        {
            var roll = dice.Roll().d3().AsSum();

            if (roll == 1)
                return "Unreliable";

            if (roll == 3)
                return "Uncontrolled";

            var situation = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.CursedDependentSituations);
            return $"Dependent: {situation}";
        }

        public Item Generate()
        {
            var specificCursedItem = new Item();
            specificCursedItem.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.SpecificCursedItems);
            specificCursedItem.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, specificCursedItem.Name);
            specificCursedItem.Magic.Curse = CurseConstants.SpecificCursedItem;
            specificCursedItem.ItemType = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.SpecificCursedItemItemTypes, specificCursedItem.Name).Single();
            specificCursedItem.Attributes = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.SpecificCursedItemAttributes, specificCursedItem.Name);

            if (specificCursedItem.ItemType == ItemTypeConstants.Armor)
                return GetArmor(specificCursedItem);

            if (specificCursedItem.ItemType == ItemTypeConstants.Weapon)
                return GetWeapon(specificCursedItem);

            return specificCursedItem;
        }

        private Item GetArmor(Item cursedItem)
        {
            var template = new Armor();
            template.Name = cursedItem.BaseNames.First();
            var armor = mundaneArmorGenerator.GenerateFrom(template);

            cursedItem.Clone(armor);

            if (armor.IsMagical)
                armor.Traits.Add(TraitConstants.Masterwork);

            return armor;
        }

        private Item GetWeapon(Item cursedItem)
        {
            var template = new Weapon();
            template.Name = cursedItem.BaseNames.First();
            var weapon = mundaneWeaponGenerator.GenerateFrom(template);

            cursedItem.Quantity = weapon.Quantity;
            cursedItem.Clone(weapon);

            if (weapon.IsMagical)
                weapon.Traits.Add(TraitConstants.Masterwork);

            return weapon;
        }

        public bool IsSpecificCursedItem(Item template)
        {
            var cursedItems = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, CurseConstants.SpecificCursedItem);
            return cursedItems.Contains(template.Name);
        }

        public Item GenerateFrom(Item template, bool allowDecoration = false)
        {
            var cursedItem = template.SmartClone();
            cursedItem.ItemType = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.SpecificCursedItemItemTypes, cursedItem.Name).Single();
            cursedItem.Attributes = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.SpecificCursedItemAttributes, cursedItem.Name);
            cursedItem.Quantity = 1;
            cursedItem.Magic.Curse = CurseConstants.SpecificCursedItem;
            cursedItem.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, cursedItem.Name);
            cursedItem.Magic.SpecialAbilities = Enumerable.Empty<SpecialAbility>();

            if (cursedItem.ItemType == ItemTypeConstants.Armor)
                return GetArmor(cursedItem);

            if (cursedItem.ItemType == ItemTypeConstants.Weapon)
                return GetWeapon(cursedItem);

            return cursedItem;

        }

        public Item GenerateFrom(IEnumerable<string> subset)
        {
            var specificCursedItem = generator.Generate(
                Generate,
                i => subset.Any(n => i.NameMatches(n)),
                () => null,
                $"Cannot generate a specific cursed item from [{string.Join(", ", subset)}]");

            return specificCursedItem;
        }
    }
}