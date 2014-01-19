using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories.Interfaces;

namespace EquipmentGen.Core.Generation.Factories
{
    public class WeaponFactory : IGearFactory
    {
        public Gear CreateAtLevel(Int32 level)
        {
            throw new NotImplementedException();
        }

        public Gear CreateWith(String power)
        {
            throw new NotImplementedException();
        }
    }
}