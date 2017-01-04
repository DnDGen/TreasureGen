using RollGen;
using System;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class ScrollGenerator : MagicalItemGenerator
    {
        private Dice dice;
        private ISpellGenerator spellGenerator;

        public ScrollGenerator(Dice dice, ISpellGenerator spellGenerator)
        {
            this.dice = dice;
            this.spellGenerator = spellGenerator;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            template.ItemType = ItemTypeConstants.Scroll;
            template.Attributes = new[] { AttributeConstants.OneTimeUse };

            var scroll = template.Copy();
            scroll.IsMagical = true;
            scroll.Quantity = 1;

            return scroll;
        }

        public Item GenerateAtPower(string power)
        {
            var spellType = spellGenerator.GenerateType();
            var scroll = new Item();
            scroll.Name = ItemTypeConstants.Scroll;
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