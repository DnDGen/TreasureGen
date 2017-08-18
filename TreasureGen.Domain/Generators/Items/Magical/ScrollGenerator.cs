using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class ScrollGenerator : MagicalItemGenerator
    {
        private readonly Dice dice;
        private readonly ISpellGenerator spellGenerator;

        public ScrollGenerator(Dice dice, ISpellGenerator spellGenerator)
        {
            this.dice = dice;
            this.spellGenerator = spellGenerator;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var scroll = template.Clone();
            scroll.IsMagical = true;
            scroll.Quantity = 1;
            scroll.ItemType = ItemTypeConstants.Scroll;
            scroll.Attributes = new[] { AttributeConstants.OneTimeUse };
            scroll.BaseNames = new[] { ItemTypeConstants.Scroll };

            return scroll.SmartClone();
        }

        public Item GenerateFrom(string power)
        {
            var spellType = spellGenerator.GenerateType();
            var scroll = new Item();
            scroll.Name = ItemTypeConstants.Scroll;
            scroll.BaseNames = new[] { ItemTypeConstants.Scroll };
            scroll.ItemType = ItemTypeConstants.Scroll;
            scroll.IsMagical = true;
            scroll.Attributes = new[] { AttributeConstants.OneTimeUse };
            scroll.Traits.Add(spellType);

            var quantity = GetQuantity(power);
            while (quantity-- > 0)
            {
                var level = spellGenerator.GenerateLevel(power);
                var spell = spellGenerator.Generate(spellType, level);
                var spellWithLevel = string.Format("{0} ({1})", spell, level);
                scroll.Contents.Add(spellWithLevel);
            }

            return scroll;
        }

        public Item GenerateFrom(string power, IEnumerable<string> subset)
        {
            if (!subset.Contains(ItemTypeConstants.Scroll))
                throw new ArgumentException("Cannot generate a non-scroll item");

            var scroll = GenerateFrom(power);
            return scroll;
        }

        private int GetQuantity(string power)
        {
            switch (power)
            {
                case PowerConstants.Minor: return dice.Roll().d3().AsSum();
                case PowerConstants.Medium: return dice.Roll().d4().AsSum();
                case PowerConstants.Major: return dice.Roll().d6().AsSum();
                default: throw new ArgumentException();
            }
        }
    }
}