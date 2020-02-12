using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class MagicalItemGeneratorIntelligenceDecorator : MagicalItemGenerator
    {
        private readonly MagicalItemGenerator innerGenerator;
        private readonly IIntelligenceGenerator intelligenceGenerator;

        public MagicalItemGeneratorIntelligenceDecorator(MagicalItemGenerator innerGenerator, IIntelligenceGenerator intelligenceGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var item = innerGenerator.GenerateFrom(template, allowRandomDecoration);
            var canBeIntelligent = intelligenceGenerator.CanBeIntelligent(item.Attributes, item.IsMagical);
            var isIntelligent = intelligenceGenerator.IsIntelligent(item.ItemType, item.Attributes, item.IsMagical);

            if (allowRandomDecoration && isIntelligent)
            {
                item.Magic.Intelligence = intelligenceGenerator.GenerateFor(item);
            }
            else if (!canBeIntelligent)
            {
                item.Magic.Intelligence = new Intelligence();
            }

            return item;
        }

        public Item GenerateFrom(string power)
        {
            var item = innerGenerator.GenerateFrom(power);

            if (intelligenceGenerator.IsIntelligent(item.ItemType, item.Attributes, item.IsMagical))
                item.Magic.Intelligence = intelligenceGenerator.GenerateFor(item);

            return item;
        }

        public Item GenerateFrom(string power, string itemName)
        {
            var item = innerGenerator.GenerateFrom(power, itemName);

            if (intelligenceGenerator.IsIntelligent(item.ItemType, item.Attributes, item.IsMagical))
                item.Magic.Intelligence = intelligenceGenerator.GenerateFor(item);

            return item;
        }

        public bool IsItemOfPower(string itemName, string power)
        {
            return innerGenerator.IsItemOfPower(itemName, power);
        }
    }
}