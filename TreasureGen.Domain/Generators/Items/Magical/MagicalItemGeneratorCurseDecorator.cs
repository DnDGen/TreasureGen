using System.Collections.Generic;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
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

        public Item GenerateFrom(string power, IEnumerable<string> subset, params string[] traits)
        {
            var item = innerGenerator.GenerateFrom(power, subset, traits);

            if (!curseGenerator.HasCurse(item.IsMagical))
                return item;

            var curse = curseGenerator.GenerateCurse();
            if (curse == TableNameConstants.Percentiles.Set.SpecificCursedItems)
            {
                var specificCursedItem = curseGenerator.GenerateFrom(subset, traits);
                if (specificCursedItem == null)
                    return item;

                return specificCursedItem;
            }

            item.Magic.Curse = curse;

            return item;
        }
    }
}