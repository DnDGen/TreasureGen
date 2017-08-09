using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
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

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var item = innerGenerator.Generate(template, allowRandomDecoration);

            if (allowRandomDecoration && intelligenceGenerator.IsIntelligent(item.ItemType, item.Attributes, item.IsMagical))
                item.Magic.Intelligence = intelligenceGenerator.GenerateFor(item);

            return item;
        }

        public Item GenerateAtPower(string power)
        {
            var item = innerGenerator.GenerateAtPower(power);

            if (intelligenceGenerator.IsIntelligent(item.ItemType, item.Attributes, item.IsMagical))
                item.Magic.Intelligence = intelligenceGenerator.GenerateFor(item);

            return item;
        }

        public Item GenerateFromSubset(string power, IEnumerable<string> subset)
        {
            var item = innerGenerator.GenerateFromSubset(power, subset);

            if (intelligenceGenerator.IsIntelligent(item.ItemType, item.Attributes, item.IsMagical))
                item.Magic.Intelligence = intelligenceGenerator.GenerateFor(item);

            return item;
        }
    }
}