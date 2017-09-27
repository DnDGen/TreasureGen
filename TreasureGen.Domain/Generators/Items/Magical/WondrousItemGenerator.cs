using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class WondrousItemGenerator : MagicalItemGenerator
    {
        private readonly ITreasurePercentileSelector percentileSelector;
        private readonly ICollectionSelector collectionsSelector;
        private readonly IChargesGenerator chargesGenerator;
        private readonly Dice dice;
        private readonly ISpellGenerator spellGenerator;
        private readonly ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private readonly Generator generator;

        public WondrousItemGenerator(
            ITreasurePercentileSelector percentileSelector,
            ICollectionSelector collectionsSelector,
            IChargesGenerator chargesGenerator,
            Dice dice,
            ISpellGenerator spellGenerator,
            ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            Generator generator)
        {
            this.percentileSelector = percentileSelector;
            this.collectionsSelector = collectionsSelector;
            this.chargesGenerator = chargesGenerator;
            this.dice = dice;
            this.spellGenerator = spellGenerator;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.generator = generator;
        }

        public Item GenerateFrom(string power)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);

            var item = BuildWondrousItem(result.Type);
            item.Magic.Bonus = result.Amount;

            return item;
        }

        private Item BuildWondrousItem(string name)
        {
            var item = new Item();
            item.Name = name;
            item.BaseNames = new[] { name };
            item.IsMagical = true;
            item.ItemType = ItemTypeConstants.WondrousItem;

            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, item.ItemType);
            item.Attributes = collectionsSelector.SelectFrom(tableName, name);

            if (item.Attributes.Contains(AttributeConstants.Charged))
                item.Magic.Charges = chargesGenerator.GenerateFor(item.ItemType, name);

            var trait = GetTraitFor(name);
            if (!string.IsNullOrEmpty(trait))
                item.Traits.Add(trait);

            var contents = GetContentsFor(name);
            item.Contents.AddRange(contents);

            return item;
        }

        private string GetTraitFor(string name)
        {
            switch (name)
            {
                case WondrousItemConstants.HornOfValhalla: return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.HornOfValhallaTypes);
                case WondrousItemConstants.CandleOfInvocation: return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IntelligenceAlignments);
                case WondrousItemConstants.RobeOfTheArchmagi: return percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfTheArchmagiColors);
                default: return string.Empty;
            }
        }

        private IEnumerable<string> GetContentsFor(string name)
        {
            switch (name)
            {
                case WondrousItemConstants.IronFlask: return GetIronFlaskContents();
                case WondrousItemConstants.RobeOfUsefulItems: return GetRobeOfUsefulItemsItems();
                case WondrousItemConstants.CubicGate: return GeneratePlanesForCubicGate();
            }

            if (ItemHasPartialContents(name))
                return GetPartialContents(name);

            return Enumerable.Empty<string>();
        }

        private IEnumerable<string> GetIronFlaskContents()
        {
            var contents = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IronFlaskContents);

            if (string.IsNullOrEmpty(contents))
                return Enumerable.Empty<string>();

            if (contents == TableNameConstants.Percentiles.Set.BalorOrPitFiend)
                contents = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.BalorOrPitFiend);

            return new[] { contents };
        }

        private IEnumerable<string> GetRobeOfUsefulItemsItems()
        {
            var baseItems = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, WondrousItemConstants.RobeOfUsefulItems);
            var extraItems = GenerateExtraItemsInRobeOfUsefulItems();

            //INFO: Can't do Union because it will deduplicate the allowed duplicate items
            var items = new List<string>();
            items.AddRange(baseItems);
            items.AddRange(extraItems);

            return items;
        }

        private IEnumerable<string> GetPartialContents(string name)
        {
            var quantity = chargesGenerator.GenerateFor(ItemTypeConstants.WondrousItem, name);
            var fullContents = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.WondrousItemContents, name).ToList();

            if (quantity >= fullContents.Count)
                return fullContents;

            var contents = new List<string>();

            while (quantity-- > 0)
            {
                var index = dice.Roll().d(fullContents.Count).AsSum() - 1;

                contents.Add(fullContents[index]);
                fullContents.RemoveAt(index);
            }

            return contents;
        }

        private bool ItemHasPartialContents(string name)
        {
            if (name == WondrousItemConstants.RobeOfBones)
                return true;

            if (name.StartsWith(WondrousItemConstants.NecklaceOfFireballs))
                return true;

            if (name == WondrousItemConstants.DeckOfIllusions)
                return true;

            return false;
        }

        private IEnumerable<string> GenerateExtraItemsInRobeOfUsefulItems()
        {
            var extraItems = new List<string>();
            var quantity = dice.Roll(4).d4().AsSum();

            while (quantity-- > 0)
            {
                var item = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.RobeOfUsefulItemsExtraItems);

                if (item == ItemTypeConstants.Scroll)
                {
                    var spellType = spellGenerator.GenerateType();
                    var level = spellGenerator.GenerateLevel(PowerConstants.Minor);
                    var spell = spellGenerator.Generate(spellType, level);

                    item = string.Format("{0} scroll of {1} ({2})", spellType, spell, level);
                }

                extraItems.Add(item);
            }

            return extraItems;
        }

        private IEnumerable<string> GeneratePlanesForCubicGate()
        {
            var planes = new HashSet<string>();
            planes.Add("Material Plane");

            while (planes.Count < 6)
            {
                var plane = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.Planes);
                planes.Add(plane);
            }

            return planes;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var item = template.Clone();
            item.IsMagical = true;
            item.BaseNames = new[] { item.Name };

            var tableName = string.Format(TableNameConstants.Collections.Formattable.ITEMTYPEAttributes, ItemTypeConstants.WondrousItem);
            item.Attributes = collectionsSelector.SelectFrom(tableName, item.Name);
            item.ItemType = ItemTypeConstants.WondrousItem;

            return item.SmartClone();
        }

        public Item GenerateFrom(string power, IEnumerable<string> subset)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            var results = typeAndAmountPercentileSelector.SelectAllFrom(tableName);

            if (!results.Any(r => subset.Any(n => r.Type == n)))
            {
                return CreateDefaultWondrousItem(power, subset);
            }

            var item = generator.Generate(
                () => GenerateFrom(power),
                i => subset.Any(n => i.NameMatches(n)),
                () => CreateDefaultWondrousItem(power, subset),
                i => $"{i.Name} is not in subset [{string.Join(", ", subset)}]",
                $"Wondrous item from [{string.Join(", ", subset)}]");

            return item;
        }

        private Item CreateDefaultWondrousItem(string power, IEnumerable<string> subset)
        {
            var name = collectionsSelector.SelectRandomFrom(subset);
            var item = BuildWondrousItem(name);
            var result = GetResult(power, item.Name);

            item.Magic.Bonus = result.Amount;

            return item;
        }

        private TypeAndAmountSelection GetResult(string power, string name)
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            var results = typeAndAmountPercentileSelector.SelectAllFrom(tableName);
            var result = results.FirstOrDefault(r => r.Type == name);

            if (result != null)
                return result;

            if (power != PowerConstants.Minor)
            {
                tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Minor, ItemTypeConstants.WondrousItem);
                var minorResults = typeAndAmountPercentileSelector.SelectAllFrom(tableName);

                result = minorResults.FirstOrDefault(r => r.Type == name);

                if (result != null)
                    return result;
            }

            if (power != PowerConstants.Medium)
            {
                tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Medium, ItemTypeConstants.WondrousItem);
                var mediumResults = typeAndAmountPercentileSelector.SelectAllFrom(tableName);

                result = mediumResults.FirstOrDefault(r => r.Type == name);

                if (result != null)
                    return result;
            }

            if (power != PowerConstants.Major)
            {
                tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, PowerConstants.Major, ItemTypeConstants.WondrousItem);
                var majorResults = typeAndAmountPercentileSelector.SelectAllFrom(tableName);

                result = majorResults.FirstOrDefault(r => r.Type == name);

                if (result != null)
                    return result;
            }

            throw new ArgumentException($"{name} is not a Wondrous Item");
        }
    }
}