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

            if (curseGenerator.HasCurse(item))
            {
                var canBeSpecific = curseGenerator.ItemTypeCanBeSpecificCursedItem(item.ItemType);

                do item.Magic.Curse = curseGenerator.GenerateCurse();
                while (item.Magic.Curse == TableNameConstants.Percentiles.Set.SpecificCursedItems && !canBeSpecific);

                if (item.Magic.Curse == TableNameConstants.Percentiles.Set.SpecificCursedItems && canBeSpecific)
                {
                    return curseGenerator.GenerateSpecificCursedItem(item.ItemType);
                }
            }

            return item;
        }

        public Item GenerateFrom(string power, string itemName)
        {
            if (curseGenerator.IsSpecificCursedItem(itemName))
                return curseGenerator.Generate(itemName);

            var item = innerGenerator.GenerateFrom(power, itemName);

            if (curseGenerator.HasCurse(item))
            {
                var canBeSpecific = curseGenerator.CanBeSpecificCursedItem(itemName);

                do item.Magic.Curse = curseGenerator.GenerateCurse();
                while (item.Magic.Curse == TableNameConstants.Percentiles.Set.SpecificCursedItems && !canBeSpecific);

                if (item.Magic.Curse == TableNameConstants.Percentiles.Set.SpecificCursedItems && canBeSpecific)
                {
                    var cursedItem = curseGenerator.Generate(itemName);
                    return cursedItem;
                }
            }

            return item;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            if (curseGenerator.IsSpecificCursedItem(template))
                return curseGenerator.GenerateFrom(template);

            var item = innerGenerator.GenerateFrom(template, allowRandomDecoration);

            if (allowRandomDecoration && curseGenerator.HasCurse(item))
            {
                do item.Magic.Curse = curseGenerator.GenerateCurse();
                while (item.Magic.Curse == TableNameConstants.Percentiles.Set.SpecificCursedItems);
            }

            return item;
        }

        public bool IsItemOfPower(string itemName, string power)
        {
            if (curseGenerator.IsSpecificCursedItem(itemName))
                return true;

            return innerGenerator.IsItemOfPower(itemName, power);
        }
    }
}