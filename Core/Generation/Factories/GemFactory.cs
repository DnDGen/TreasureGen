using System;
using D20Dice;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Core.Generation.Factories.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class GemFactory : IGemFactory
    {
        private IDice dice;

        public GemFactory(IDice dice)
        {
            this.dice = dice;
        }

        public Good Create()
        {
            throw new NotImplementedException();
        }
    }
}