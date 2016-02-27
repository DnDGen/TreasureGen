using RollGen;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Items.Magical
{
    public class WondrousItemGenerator : MagicalItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IAttributesSelector attributesSelector;
        private IChargesGenerator chargesGenerator;
        private Dice dice;
        private ISpellGenerator spellGenerator;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;

        public WondrousItemGenerator(IPercentileSelector percentileSelector, IAttributesSelector attributesSelector, IChargesGenerator chargesGenerator, Dice dice, ISpellGenerator spellGenerator, ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
        {
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
            this.chargesGenerator = chargesGenerator;
            this.dice = dice;
            this.spellGenerator = spellGenerator;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
        }

        public Item GenerateAtPower(string power)
        {
            var tablename = string.Format(TableNameConstants.Percentiles.Formattable.POWERITEMTYPEs, power, ItemTypeConstants.WondrousItem);
            var result = typeAndAmountPercentileSelector.SelectFrom(tablename);

            var item = new Item();
            item.Name = result.Type;
            item.IsMagical = true;
            item.ItemType = ItemTypeConstants.WondrousItem;

            var tableName = string.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, item.ItemType);
            item.Attributes = attributesSelector.SelectFrom(tableName, item.Name);
            item.Magic.Bonus = result.Amount;

            if (item.Attributes.Contains(AttributeConstants.Charged))
                item.Magic.Charges = chargesGenerator.GenerateFor(item.ItemType, item.Name);

            var trait = GetTraitFor(item.Name);
            if (!string.IsNullOrEmpty(trait))
                item.Traits.Add(trait);

            var contents = GetContentsFor(item.Name);
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
            var baseItems = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.WondrousItemContents, WondrousItemConstants.RobeOfUsefulItems);
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
            var fullContents = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.WondrousItemContents, name).ToList();

            if (quantity >= fullContents.Count)
                return fullContents;

            var contents = new List<string>();

            while (quantity-- > 0)
            {
                var index = dice.Roll().d(fullContents.Count) - 1;

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
            var quantity = dice.Roll(4).d4();

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
            planes.Add("Material plane");

            while (planes.Count < 6)
            {
                var plane = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.Planes);
                planes.Add(plane);
            }

            return planes;
        }
    }
}