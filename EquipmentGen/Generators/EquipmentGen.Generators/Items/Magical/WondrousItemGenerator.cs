using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class WondrousItemGenerator : IMagicalItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IMagicalItemTraitsGenerator traitsGenerator;
        private IAttributesSelector attributesSelector;
        private IChargesGenerator chargesGenerator;
        private IDice dice;
        private ISpellGenerator spellGenerator;
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;

        public WondrousItemGenerator(IPercentileSelector percentileSelector, IMagicalItemTraitsGenerator traitsGenerator,
            IAttributesSelector attributesSelector, IChargesGenerator chargesGenerator, IDice dice, ISpellGenerator spellGenerator,
            ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector)
        {
            this.percentileSelector = percentileSelector;
            this.traitsGenerator = traitsGenerator;
            this.attributesSelector = attributesSelector;
            this.chargesGenerator = chargesGenerator;
            this.dice = dice;
            this.spellGenerator = spellGenerator;
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
        }

        public Item GenerateAtPower(String power)
        {
            var tablename = String.Format("{0}WondrousItems", power);
            var result = typeAndAmountPercentileSelector.SelectFrom(tablename);

            var item = new Item();
            item.Name = result.Type;
            item.IsMagical = true;
            item.ItemType = ItemTypeConstants.WondrousItem;
            item.Attributes = attributesSelector.SelectFrom("WondrousItemAttributes", item.Name);
            item.Magic.Bonus = Convert.ToInt32(result.Amount);

            if (item.Attributes.Contains(AttributeConstants.Charged))
                item.Magic.Charges = chargesGenerator.GenerateFor(item.ItemType, item.Name);

            var traits = traitsGenerator.GenerateFor(item.ItemType, item.Attributes);
            item.Traits.AddRange(traits);

            if (item.Name == "Horn of Valhalla")
            {
                var hornType = percentileSelector.SelectFrom("HornOfValhallaTypes");
                item.Name = String.Format("{0} {1}", hornType, item.Name);
            }
            else if (item.Name == "Iron flask")
            {
                var contents = percentileSelector.SelectFrom("IronFlaskContents");

                if (contents == "BalorOrPitFiend")
                    contents = percentileSelector.SelectFrom("BalorOrPitFiend");

                if (!String.IsNullOrEmpty(contents))
                    item.Contents.Add(contents);
            }
            else if (item.Name == "Robe of useful items")
            {
                var baseItems = attributesSelector.SelectFrom("WondrousItemContents", item.Name);
                item.Contents.AddRange(baseItems);

                var extraItems = GenerateExtraItemsInRobeOfUsefulItems();
                item.Contents.AddRange(extraItems);
            }
            else if (item.Name == "Cubic gate")
            {
                var planes = GeneratePlanesForCubicGate();
                item.Contents.AddRange(planes);
            }
            else if (ItemHasPartialContents(item.Name))
            {
                var partialContents = GetPartialContents(item.Name);
                item.Contents.AddRange(partialContents);
            }

            return item;
        }

        private IEnumerable<String> GetPartialContents(String name)
        {
            var quantity = chargesGenerator.GenerateFor(ItemTypeConstants.WondrousItem, name);
            var fullContents = attributesSelector.SelectFrom("WondrousItemContents", name).ToList();

            if (quantity >= fullContents.Count)
                return fullContents;

            var contents = new List<String>();

            while (quantity-- > 0)
            {
                var roll = String.Format("1d{0}-1", fullContents.Count);
                var index = dice.Roll(roll);

                contents.Add(fullContents[index]);
                fullContents.RemoveAt(index);
            }

            return contents;
        }

        private Boolean ItemHasPartialContents(String name)
        {
            if (name == "Robe of bones")
                return true;

            if (name.StartsWith("Necklace of fireballs"))
                return true;

            if (name == "Deck of illusions")
                return true;

            return false;
        }

        private IEnumerable<String> GenerateExtraItemsInRobeOfUsefulItems()
        {
            var extraItems = new List<String>();
            var quantity = dice.d4(4);

            while (quantity-- > 0)
            {
                var item = percentileSelector.SelectFrom("RobeOfUsefulItemsExtraItems");

                if (item == ItemTypeConstants.Scroll)
                {
                    var spellType = spellGenerator.GenerateType();
                    var level = spellGenerator.GenerateLevel(PowerConstants.Minor);
                    var spell = spellGenerator.Generate(spellType, level);

                    item = String.Format("{0} scroll of {1} ({2})", spellType, spell, level);
                }

                extraItems.Add(item);
            }

            return extraItems;
        }

        private IEnumerable<String> GeneratePlanesForCubicGate()
        {
            var planes = new List<String>();
            planes.Add("Material plane");

            while (planes.Count < 6)
            {
                var plane = percentileSelector.SelectFrom("Planes");

                if (!planes.Contains(plane))
                    planes.Add(plane);
            }

            return planes;
        }
    }
}