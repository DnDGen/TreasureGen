using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Decorators
{
    public class MagicalItemGeneratorCurseDecorator : MagicalItemGenerator
    {
        private MagicalItemGenerator innerGenerator;
        private ICurseGenerator curseGenerator;

        public MagicalItemGeneratorCurseDecorator(MagicalItemGenerator innerGenerator, ICurseGenerator curseGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.curseGenerator = curseGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var item = innerGenerator.GenerateAtPower(power);

            if (curseGenerator.HasCurse(item.IsMagical))
            {
                var curse = curseGenerator.GenerateCurse();
                if (curse == TableNameConstants.Percentiles.Set.SpecificCursedItems)
                    return curseGenerator.GenerateSpecificCursedItem();

                item.Magic.Curse = curse;
            }

            return item;
        }
    }
}