using System;
using System.Collections.Generic;
using EquipmentGen.Common.Items;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Generators.Interfaces.Items.Magical
{
    public interface ICurseGenerator
    {
        Boolean HasCurse(Dictionary<Magic, Object> magic);
        String GenerateCurse();
        Item GenerateSpecificCursedItem();
    }
}