using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface ICurseGenerator
    {
        Boolean HasCurse(Dictionary<Magic, Object> magic);
        String GenerateCurse();
        Item GenerateSpecificCursedItem();
    }
}