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
        private ICurseGenerator curseGenerator;

        public ScrollGenerator(IDice dice, ISpellGenerator spellGenerator, ICurseGenerator curseGenerator)
        {
            this.dice = dice;
            this.spellGenerator = spellGenerator;
            this.curseGenerator = curseGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var spellType = spellGenerator.GenerateType();
            var scroll = new Item();
            scroll.Name = String.Format("{0} scroll", spellType);
            scroll.Magic[Magic.IsMagical] = true;

            var quantity = GetQuantity(power);
            while (quantity-- > 0)
            {
                var level = spellGenerator.GenerateLevel(power);
                var spell = spellGenerator.Generate(spellType, level);
                var spellWithLevel = String.Format("{0} ({1})", spell, level);
                scroll.Traits.Add(spellWithLevel);
            }

            if (curseGenerator.HasCurse(scroll.Magic))
            {
                var curse = curseGenerator.GenerateCurse();
                if (curse == "SpecificCursedItem")
                    return curseGenerator.GenerateSpecificCursedItem();

                scroll.Magic.Add(Magic.Curse, curse);
            }

            return scroll;
        }

        private Int32 GetQuantity(String power)
        {
            switch (power)
            {
                case PowerConstants.Minor: return dice.d3();
                case PowerConstants.Medium: return dice.d4();
                case PowerConstants.Major: return dice.d6();
                default: throw new ArgumentException();
            }
        }
    }
}