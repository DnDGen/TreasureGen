using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.Items.Magical
{
    public class CurseGenerator : ICurseGenerator
    {
        private IDice dice;

        public CurseGenerator(IDice dice)
        {
            this.dice = dice;
        }

        public Boolean HasCurse(Dictionary<Magic, Object> magic)
        {
            if (!magic.Any())
                return false;

            var roll = dice.Percentile();
            return roll <= 5;
        }

        public String GenerateCurse()
        {
            throw new NotImplementedException();
        }

        public Item GenerateSpecificCursedItem()
        {
            throw new NotImplementedException();
        }
    }
}