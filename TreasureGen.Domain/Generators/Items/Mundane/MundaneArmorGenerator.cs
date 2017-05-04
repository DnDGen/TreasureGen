using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Collections;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class MundaneArmorGenerator : MundaneItemGenerator
    {
        private readonly IPercentileSelector percentileSelector;
        private readonly ICollectionsSelector collectionsSelector;
        private readonly IBooleanPercentileSelector booleanPercentileSelector;
        private readonly Generator generator;
        private readonly IArmorDataSelector armorDataSelector;

        public MundaneArmorGenerator(IPercentileSelector percentileSelector, ICollectionsSelector collectionsSelector, IBooleanPercentileSelector booleanPercentileSelector, Generator generator, IArmorDataSelector armorDataSelector)
        {
            this.percentileSelector = percentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.generator = generator;
            this.armorDataSelector = armorDataSelector;
        }

        public Item Generate()
        {
            var armor = new Armor();
            armor.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors);

            if (armor.Name == AttributeConstants.Shield)
                armor.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields);

            armor = PopulateArmor(armor);

            var isMasterwork = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork);
            if (isMasterwork)
                armor.Traits.Add(TraitConstants.Masterwork);

            armor.Size = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);

            return armor;
        }

        private Armor PopulateArmor(Armor armor)
        {
            armor.BaseNames = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.ItemGroups, armor.Name);

            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, armor.ItemType);
            armor.Attributes = collectionsSelector.SelectFrom(tableName, armor.Name);

            var armorSelection = armorDataSelector.Select(armor.Name);
            armor.ArmorBonus = armorSelection.ArmorBonus;
            armor.ArmorCheckPenalty = armorSelection.ArmorCheckPenalty;
            armor.MaxDexterityBonus = armorSelection.MaxDexterityBonus;

            return armor;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var armor = new Armor();
            template.MundaneClone(armor);

            armor.ItemType = ItemTypeConstants.Armor;
            armor.Quantity = 1;

            armor = PopulateArmor(armor);
            armor.Size = GetSize(template);
            armor.Traits.Remove(armor.Size);

            if (allowRandomDecoration)
            {
                var isMasterwork = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork);
                if (isMasterwork)
                    armor.Traits.Add(TraitConstants.Masterwork);
            }

            return armor;
        }

        private string GetSize(Item template)
        {
            if (template is Armor)
            {
                var armor = template as Armor;

                if (!string.IsNullOrEmpty(armor.Size))
                    return armor.Size;
            }

            var allSizes = percentileSelector.SelectAllFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
            var sizes = template.Traits.Intersect(allSizes);

            if (sizes.Any())
                return sizes.Single();

            return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
        }

        public Item GenerateFrom(IEnumerable<string> subset)
        {
            if (!subset.Any())
                throw new ArgumentException("Cannot generate from an empty collection subset");

            var armor = generator.Generate(
                Generate,
                a => subset.Any(n => a.NameMatches(n)),
                () => GenerateDefaultFrom(subset),
                $"Mundane armor from [{string.Join(", ", subset)}]");

            return armor;
        }

        private Item GenerateDefaultFrom(IEnumerable<string> subset)
        {
            var template = new Item();
            template.Name = collectionsSelector.SelectRandomFrom(subset);

            var defaultArmor = GenerateFrom(template);
            return defaultArmor;
        }
    }
}