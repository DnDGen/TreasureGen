using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.RollGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using System.Linq;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class CurseGenerator : ICurseGenerator
    {
        private readonly Dice dice;
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ICollectionSelector collectionsSelector;
        private readonly JustInTimeFactory justInTimeFactory;

        public CurseGenerator(Dice dice, ITreasurePercentileSelector percentileSelector, ICollectionSelector collectionsSelector, JustInTimeFactory justInTimeFactory)
        {
            this.dice = dice;
            this.percentileSelector = percentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.justInTimeFactory = justInTimeFactory;
        }

        public bool HasCurse(bool isMagical)
        {
            return isMagical && percentileSelector.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsItemCursed);
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
            var name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.SpecificCursedItems);
            return Generate(name);
        }

        public Item Generate(string itemName)
        {
            var prototype = GeneratePrototype(itemName);
            var specificCursedItem = GenerateFromPrototype(prototype);
            return specificCursedItem;
        }

        private Item GeneratePrototype(string name)
        {
            var specificCursedItem = new Item();
            specificCursedItem.Name = name;
            specificCursedItem.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, name);
            specificCursedItem.Magic.Curse = CurseConstants.SpecificCursedItem;

            return specificCursedItem;
        }

        private Item GenerateFromPrototype(Item prototype)
        {
            var specificCursedItem = prototype.Clone();
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

            var mundaneArmorGenerator = justInTimeFactory.Build<MundaneItemGenerator>(ItemTypeConstants.Armor);
            var armor = mundaneArmorGenerator.GenerateFrom(template);

            cursedItem.CloneInto(armor);

            if (armor.IsMagical)
                armor.Traits.Add(TraitConstants.Masterwork);

            return armor;
        }

        private Item GetWeapon(Item cursedItem)
        {
            var template = new Weapon();
            template.Name = cursedItem.BaseNames.First();

            var mundaneWeaponGenerator = justInTimeFactory.Build<MundaneItemGenerator>(ItemTypeConstants.Weapon);
            var weapon = mundaneWeaponGenerator.GenerateFrom(template);

            cursedItem.Quantity = weapon.Quantity;
            cursedItem.CloneInto(weapon);

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
            var prototype = template.SmartClone();
            prototype.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, prototype.Name);
            prototype.Magic.Curse = CurseConstants.SpecificCursedItem;
            prototype.Quantity = 1;
            prototype.Magic.SpecialAbilities = Enumerable.Empty<SpecialAbility>();

            var cursedItem = GenerateFromPrototype(prototype);

            return cursedItem;
        }
    }
}