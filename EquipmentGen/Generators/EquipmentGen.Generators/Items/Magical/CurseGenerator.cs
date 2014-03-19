using System;
using System.Collections.Generic;
using EquipmentGen.Common.Items;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.Items.Magical
{
    public class CurseGenerator : ICurseGenerator
    {
        public Boolean HasCurse(Dictionary<Magic, Object> magic)
        {
            throw new NotImplementedException();
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