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
        private IIntelligenceGenerator intelligenceGenerator;
        private IAttributesSelector attributesSelector;
        private IChargesGenerator chargesGenerator;
        private IDice dice;
        private ICurseGenerator curseGenerator;
        private ISpellGenerator spellGenerator;

        public WondrousItemGenerator(IPercentileSelector percentileSelector,
            IMagicalItemTraitsGenerator traitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            IAttributesSelector attributesSelector, IChargesGenerator chargesGenerator, IDice dice,
            ICurseGenerator curseGenerator, ISpellGenerator spellGenerator)
        {
            this.percentileSelector = percentileSelector;
            this.traitsGenerator = traitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.attributesSelector = attributesSelector;
            this.chargesGenerator = chargesGenerator;
            this.dice = dice;
            this.curseGenerator = curseGenerator;
            this.spellGenerator = spellGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var roll = dice.Percentile();
            var tablename = String.Format("{0}WondrousItems", power);
            var result = percentileSelector.SelectFrom(tablename, roll);

            var item = new Item();
            item.Name = result;
            item.IsMagical = true;
            item.ItemType = ItemTypeConstants.WondrousItem;

            var attributeName = GetNameForAttributes(item.Name);
            item.Attributes = attributesSelector.SelectFrom("WondrousItemAttributes", attributeName);

            if (item.Name.Contains("+"))
                item.Magic.Bonus = GetBonus(item.Name);

            if (item.Attributes.Any(a => a == AttributeConstants.Charged))
                item.Magic.Charges = chargesGenerator.GenerateFor(ItemTypeConstants.WondrousItem, item.Name);

            if (intelligenceGenerator.IsIntelligent(ItemTypeConstants.WondrousItem, item.Attributes, item.IsMagical))
                item.Magic.Intelligence = intelligenceGenerator.GenerateFor(item.Magic);

            if (curseGenerator.HasCurse(item.IsMagical))
            {
                var curse = curseGenerator.GenerateCurse();
                if (curse == "SpecificCursedItem")
                    return curseGenerator.GenerateSpecificCursedItem();

                item.Magic.Curse = curse;
            }

            var traits = traitsGenerator.GenerateFor(ItemTypeConstants.WondrousItem);
            item.Traits.AddRange(traits);

            if (item.Name == "Horn of Valhalla")
            {
                roll = dice.Percentile();
                var hornType = percentileSelector.SelectFrom("HornOfValhallaTypes", roll);
                item.Name = String.Format("{0} {1}", hornType, item.Name);
            }
            else if (item.Name == "Iron flask")
            {
                roll = dice.Percentile();
                var contents = percentileSelector.SelectFrom("IronFlaskContents", roll);

                if (contents == "BalorOrPitFiend")
                {
                    roll = dice.Percentile();
                    contents = percentileSelector.SelectFrom("BalorOrPitFiend", roll);
                }

                if (!String.IsNullOrEmpty(contents))
                    item.Contents.Add(contents);
            }
            else if (item.Name == "Robe of useful items")
            {
                var baseItems = GetBaseItemsInRobeOfUsefulItems();
                item.Contents.AddRange(baseItems);

                var extraItems = GenerateExtraItemsInRobeOfUsefulItems();
                item.Contents.AddRange(extraItems);
            }
            else if (item.Name == "Cubic gate")
            {
                var planes = GeneratePlanesForCubicGate();
                item.Contents.AddRange(planes);
            }

            return item;
        }

        private IEnumerable<String> GetBaseItemsInRobeOfUsefulItems()
        {
            return attributesSelector.SelectFrom("RobeOfUsefulItemsBaseItems", "Items");
        }

        private String GetNameForAttributes(String itemName)
        {
            var attributeName = itemName.Split(',').First();

            var typeIndex = attributeName.IndexOf(" type ");
            if (typeIndex > 0)
                attributeName = attributeName.Remove(typeIndex);

            var bonusIndex = attributeName.IndexOf(" +");
            if (bonusIndex > 0)
                attributeName = attributeName.Remove(bonusIndex);

            return attributeName;
        }

        private Int32 GetBonus(String name)
        {
            var bonus = name.Split('+').Last();
            return Convert.ToInt32(bonus);
        }

        private IEnumerable<String> GenerateExtraItemsInRobeOfUsefulItems()
        {
            var extraItems = new List<String>();
            var quantity = dice.d4(4);

            while (quantity-- > 0)
            {
                var roll = dice.Percentile();
                var item = percentileSelector.SelectFrom("RobeOfUsefulItemsExtraItems", roll);

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
                var roll = dice.Percentile();
                var plane = percentileSelector.SelectFrom("Planes", roll);
                if (!planes.Contains(plane))
                    planes.Add(plane);
            }

            return planes;
        }
    }
}