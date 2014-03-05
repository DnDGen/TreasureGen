using System;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class WondrousItemGenerator : IMagicalItemGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IMagicalItemTraitsGenerator traitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private IAttributesProvider attributesProvider;
        private IChargesGenerator chargesGenerator;

        public WondrousItemGenerator(IPercentileResultProvider percentileResultProvider,
            IMagicalItemTraitsGenerator traitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            IAttributesProvider attributesProvider, IChargesGenerator chargesGenerator)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.traitsGenerator = traitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.attributesProvider = attributesProvider;
            this.chargesGenerator = chargesGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var tablename = String.Format("{0}WondrousItems", power);
            var result = percentileResultProvider.GetResultFrom(tablename);

            var item = new Item();
            item.Name = result;
            item.Magic[Magic.IsMagical] = true;

            var attributeName = GetNameForAttributes(item.Name);
            item.Attributes = attributesProvider.GetAttributesFor(attributeName, "WondrousItemAttributes");

            if (item.Name.Contains("+"))
                item.Magic[Magic.Bonus] = GetBonus(item.Name);

            if (item.Attributes.Any(a => a == AttributeConstants.Charged))
                item.Magic[Magic.Charges] = chargesGenerator.GenerateChargesFor(ItemTypeConstants.WondrousItem, item.Name);

            if (intelligenceGenerator.IsIntelligent(ItemTypeConstants.WondrousItem, item.Attributes, item.Magic))
                item.Magic[Magic.Intelligence] = intelligenceGenerator.GenerateFor(ItemTypeConstants.WondrousItem, item.Magic);

            var traits = traitsGenerator.GenerateFor(ItemTypeConstants.WondrousItem);
            item.Traits.AddRange(traits);

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
    }
}