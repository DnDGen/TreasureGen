using System;
using EquipmentGen.Core.Data.Items;

namespace EquipmentGen.Core.Generation.Generators.Interfaces
{
    public interface ICurseGenerator
    {
        Boolean HasCurse();
        String GenerateCurseTrait();
        BasicItem GenerateSpecificCursedItem();
    }
}