using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.Decorators
{
    public class MagicalItemGeneratorCurseDecorator : IMagicalItemGenerator
    {
        private IMagicalItemGenerator innerGenerator;
        private ICurseGenerator curseGenerator;

        public MagicalItemGeneratorCurseDecorator(IMagicalItemGenerator innerGenerator, ICurseGenerator curseGenerator)
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
                if (curse == "SpecificCursedItem")
                    return curseGenerator.GenerateSpecificCursedItem();

                item.Magic.Curse = curse;
            }

            return item;
        }
    }
}