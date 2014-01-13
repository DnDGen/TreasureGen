using System;
using D20Dice;
using EquipmentGen.Core.Data.Goods;
using EquipmentGen.Core.Generation.Factories.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class ArtFactory : IArtFactory
    {
        private IDice dice;

        public ArtFactory(IDice dice)
        {
            this.dice = dice;
        }

        public Good Create()
        {
            throw new NotImplementedException();
        }
    }
}