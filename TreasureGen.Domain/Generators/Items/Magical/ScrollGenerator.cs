﻿using RollGen;
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

        public Item GenerateAtPower(string power)
        {
            var spellType = spellGenerator.GenerateType();
            var scroll = new Item();
            scroll.Name = ItemTypeConstants.Scroll;
            scroll.IsMagical = true;
            scroll.Attributes = new[] { AttributeConstants.OneTimeUse };
            scroll.ItemType = ItemTypeConstants.Scroll;
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
                case PowerConstants.Minor: return dice.Roll().d3();
                case PowerConstants.Medium: return dice.Roll().d4();
                case PowerConstants.Major: return dice.Roll().d6();
                default: throw new ArgumentException();
            }
        }
    }
}