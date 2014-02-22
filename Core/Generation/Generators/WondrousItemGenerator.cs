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
            item.Attributes = attributesProvider.GetAttributesFor(item.Name, "WondrousItemAttributes");

            if (item.Name.Contains("+"))
                item.Magic[Magic.Bonus] = GetBonus(item.Name);

            if (item.Attributes.Any(a => a == AttributeConstants.Charged))
                item.Magic[Magic.Charges] = chargesGenerator.GenerateChargesFor(ItemTypeConstants.WondrousItem, item.Name);

            if (intelligenceGenerator.IsIntelligent(ItemTypeConstants.WondrousItem, item.Attributes))
                item.Magic[Magic.Intelligence] = intelligenceGenerator.GenerateFor(ItemTypeConstants.WondrousItem);

            var traits = traitsGenerator.GenerateFor(ItemTypeConstants.WondrousItem);
            item.Traits.AddRange(traits);

            return item;
        }

        private Int32 GetBonus(String name)
        {
            var bonus = name.Split('+').Last();
            return Convert.ToInt32(bonus);
        }
    }
}