using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.Items.Magical
{
    public class ScrollGenerator : IMagicalItemGenerator
    {
        private IDice dice;
        private ISpellGenerator spellGenerator;

        public ScrollGenerator(IDice dice, ISpellGenerator spellGenerator)
        {
            this.dice = dice;
            this.spellGenerator = spellGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var spellType = spellGenerator.GenerateType();
            var scroll = new Item();
            scroll.Name = String.Format("{0} scroll", spellType);
            scroll.IsMagical = true;
            scroll.Attributes = new[] { AttributeConstants.OneTimeUse };
            scroll.ItemType = ItemTypeConstants.Scroll;

            var quantity = GetQuantity(power);
            while (quantity-- > 0)
            {
                var level = spellGenerator.GenerateLevel(power);
                var spell = spellGenerator.Generate(spellType, level);
                var spellWithLevel = String.Format("{0} ({1})", spell, level);
                scroll.Contents.Add(spellWithLevel);
            }

            return scroll;
        }

        private Int32 GetQuantity(String power)
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