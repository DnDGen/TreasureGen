using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.Decorators
{
    public class MagicalItemGeneratorIntelligenceDecorator : IMagicalItemGenerator
    {
        private IMagicalItemGenerator innerGenerator;
        private IIntelligenceGenerator intelligenceGenerator;

        public MagicalItemGeneratorIntelligenceDecorator(IMagicalItemGenerator innerGenerator, IIntelligenceGenerator intelligenceGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var item = innerGenerator.GenerateAtPower(power);

            if (intelligenceGenerator.IsIntelligent(item.ItemType, item.Attributes, item.IsMagical))
                item.Magic.Intelligence = intelligenceGenerator.GenerateFor(item);

            return item;
        }
    }
}