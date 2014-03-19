using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.Items.Magical
{
    public class WondrousItemGenerator : IMagicalItemGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IMagicalItemTraitsGenerator traitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private IAttributesProvider attributesProvider;
        private IChargesGenerator chargesGenerator;
        private IDice dice;

        public WondrousItemGenerator(IPercentileResultProvider percentileResultProvider,
            IMagicalItemTraitsGenerator traitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            IAttributesProvider attributesProvider, IChargesGenerator chargesGenerator, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.traitsGenerator = traitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.attributesProvider = attributesProvider;
            this.chargesGenerator = chargesGenerator;
            this.dice = dice;
        }

        public Item GenerateAtPower(String power)
        {
            var roll = dice.Percentile();
            var tablename = String.Format("{0}WondrousItems", power);
            var result = percentileResultProvider.GetResultFrom(tablename, roll);

            var item = new Item();
            item.Name = result;
            item.Magic[Magic.IsMagical] = true;

            var attributeName = GetNameForAttributes(item.Name);
            item.Attributes = attributesProvider.GetAttributesFor(attributeName, "WondrousItemAttributes");

            if (item.Name.Contains("+"))
                item.Magic[Magic.Bonus] = GetBonus(item.Name);

            if (item.Attributes.Any(a => a == AttributeConstants.Charged))
                item.Magic[Magic.Charges] = chargesGenerator.GenerateFor(ItemTypeConstants.WondrousItem, item.Name);

            if (intelligenceGenerator.IsIntelligent(ItemTypeConstants.WondrousItem, item.Attributes, item.Magic))
                item.Magic[Magic.Intelligence] = intelligenceGenerator.GenerateFor(item.Magic);

            var traits = traitsGenerator.GenerateFor(ItemTypeConstants.WondrousItem);
            item.Traits.AddRange(traits);

            if (item.Name == "Horn of Valhalla")
            {
                roll = dice.Percentile();
                var hornType = percentileResultProvider.GetResultFrom("HornOfValhallaTypes", roll);
                item.Name = String.Format("{0} ({1})", item.Name, hornType);
            }
            else if (item.Name == "Iron flask")
            {
                roll = dice.Percentile();
                var contents = percentileResultProvider.GetResultFrom("IronFlaskContents", roll);
                item.Name = String.Format("{0} ({1})", item.Name, contents);
            }
            else if (item.Name == "Robe of useful items")
            {
                var extraItems = GenerateExtraItemsInRobeOfUsefulItems();
                var extraItemsString = String.Join(", ", extraItems);
                item.Name = String.Format("{0} (extra items: {1})", item.Name, extraItemsString);
            }
            else if (item.Name == "Cubic gate")
            {
                var planes = GeneratePlanesForCubicGate();
                var planesString = String.Join(", ", planes);
                item.Name = String.Format("{0} ({1})", item.Name, planesString);
            }

            return item;
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
                var item = percentileResultProvider.GetResultFrom("RobeOfUsefulItemsExtraItems", roll);
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
                var plane = percentileResultProvider.GetResultFrom("Planes", roll);
                if (!planes.Contains(plane))
                    planes.Add(plane);
            }

            return planes;
        }
    }
}