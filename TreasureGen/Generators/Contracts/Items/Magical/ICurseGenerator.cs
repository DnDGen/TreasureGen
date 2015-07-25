using System;
using TreasureGen.Common.Items;

namespace TreasureGen.Generators.Items.Magical
{
    public interface ICurseGenerator
    {
        Boolean HasCurse(Boolean isMagical);
        String GenerateCurse();
        Item GenerateSpecificCursedItem();
    }
}