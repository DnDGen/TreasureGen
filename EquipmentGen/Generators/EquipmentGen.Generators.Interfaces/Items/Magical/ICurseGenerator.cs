using System;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Generators.Interfaces.Items.Magical
{
    public interface ICurseGenerator
    {
        Boolean HasCurse(Boolean isMagical);
        String GenerateCurse();
        Item GenerateSpecificCursedItem();
    }
}