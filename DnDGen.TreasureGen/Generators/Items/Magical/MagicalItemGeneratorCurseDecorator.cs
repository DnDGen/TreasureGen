using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tables;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class MagicalItemGeneratorCurseDecorator : MagicalItemGenerator
    {
        private readonly MagicalItemGenerator innerGenerator;
        private readonly ICurseGenerator curseGenerator;

        public MagicalItemGeneratorCurseDecorator(MagicalItemGenerator innerGenerator, ICurseGenerator curseGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.curseGenerator = curseGenerator;
        }

        public Item GenerateFrom(string power)
        {
            var item = innerGenerator.GenerateFrom(power);

            if (curseGenerator.HasCurse(item.IsMagical))
            {
                var curse = curseGenerator.GenerateCurse();
                if (curse == TableNameConstants.Percentiles.Set.SpecificCursedItems)
                    return curseGenerator.Generate();

                item.Magic.Curse = curse;
            }

            return item;
        }

        public Item GenerateFrom(string power, string itemName)
        {
            var item = innerGenerator.GenerateFrom(power, itemName);

            if (curseGenerator.HasCurse(item.IsMagical))
            {
                do item.Magic.Curse = curseGenerator.GenerateCurse();
                while (item.Magic.Curse == TableNameConstants.Percentiles.Set.SpecificCursedItems);
            }

            return item;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            if (curseGenerator.IsSpecificCursedItem(template))
                return curseGenerator.GenerateFrom(template);

            var item = innerGenerator.GenerateFrom(template, allowRandomDecoration);

            if (allowRandomDecoration && curseGenerator.HasCurse(item.IsMagical))
            {
                do item.Magic.Curse = curseGenerator.GenerateCurse();
                while (item.Magic.Curse == TableNameConstants.Percentiles.Set.SpecificCursedItems);
            }

            return item;
        }
    }
}