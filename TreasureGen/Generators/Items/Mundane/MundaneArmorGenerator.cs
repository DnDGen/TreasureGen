using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Selectors.Collections;
using TreasureGen.Selectors.Percentiles;
using TreasureGen.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Generators.Items.Mundane
{
    internal class MundaneArmorGenerator : MundaneItemGenerator
    {
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ICollectionSelector collectionsSelector;
        private readonly Generator generator;
        private readonly IArmorDataSelector armorDataSelector;

        public MundaneArmorGenerator(ITreasurePercentileSelector percentileSelector, ICollectionSelector collectionsSelector, Generator generator, IArmorDataSelector armorDataSelector)
        {
            this.percentileSelector = percentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.generator = generator;
            this.armorDataSelector = armorDataSelector;
        }

        public Item Generate()
        {
            var armor = GenerateRandomPrototype();
            armor = GenerateFromPrototype(armor, true);

            return armor;
        }

        private Armor SetArmorAttributes(Armor armor)
        {
            armor.ItemType = ItemTypeConstants.Armor;
            armor.Quantity = 1;

            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, armor.ItemType);
            armor.Attributes = collectionsSelector.SelectFrom(tableName, armor.Name);

            armor.Size = GetSize(armor);
            armor.Traits.Remove(armor.Size);

            var armorSelection = armorDataSelector.Select(armor.Name);
            armor.ArmorBonus = armorSelection.ArmorBonus;
            armor.ArmorCheckPenalty = armorSelection.ArmorCheckPenalty;
            armor.MaxDexterityBonus = armorSelection.MaxDexterityBonus;

            return armor;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            template.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, template.Name);

            var armor = new Armor();

            if (template is Armor)
                armor = template.MundaneClone() as Armor;
            else
                template.MundaneCloneInto(armor);

            armor = GenerateFromPrototype(armor, allowRandomDecoration);

            return armor;
        }

        private string GetSize(Armor template)
        {
            if (!string.IsNullOrEmpty(template.Size))
                return template.Size;

            if (!template.Traits.Any())
                return GetRandomSize();

            var allSizes = percentileSelector.SelectAllFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
            var sizeTraits = template.Traits.Intersect(allSizes);

            if (sizeTraits.Any())
                return sizeTraits.Single();

            return GetRandomSize();
        }

        private string GetRandomSize()
        {
            return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
        }

        private Armor GenerateFromPrototype(Armor prototype, bool allowDecoration)
        {
            var armor = SetArmorAttributes(prototype);

            if (allowDecoration)
            {
                var isMasterwork = percentileSelector.SelectFrom<bool>(TableNameConstants.Percentiles.Set.IsMasterwork);
                if (isMasterwork)
                    armor.Traits.Add(TraitConstants.Masterwork);
            }

            return armor;
        }

        public Item GenerateFrom(IEnumerable<string> subset, params string[] traits)
        {
            if (!subset.Any())
                throw new ArgumentException("Cannot generate from an empty collection subset");

            var armorPrototype = generator.Generate(
                GenerateRandomPrototype,
                a => subset.Any(n => a.NameMatches(n)),
                () => GenerateDefaultPrototypeFrom(subset),
                a => $"{a.Name} is not in subset [{string.Join(", ", subset)}]",
                $"Mundane armor from [{string.Join(", ", subset)}]");

            armorPrototype.Traits = new HashSet<string>(traits);
            var armor = GenerateFromPrototype(armorPrototype, true);

            return armor;
        }

        private Armor GenerateDefaultPrototypeFrom(IEnumerable<string> subset)
        {
            var template = new Armor();
            template.Name = collectionsSelector.SelectRandomFrom(subset);
            template.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, template.Name);

            return template;
        }

        private Armor GenerateRandomPrototype()
        {
            var armor = new Armor();
            armor.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors);

            if (armor.Name == AttributeConstants.Shield)
                armor.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields);

            armor.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, armor.Name);

            return armor;
        }
    }
}