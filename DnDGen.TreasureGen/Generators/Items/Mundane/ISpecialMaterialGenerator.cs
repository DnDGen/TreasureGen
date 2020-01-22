using System.Collections.Generic;

namespace DnDGen.TreasureGen.Items.Mundane
{
    internal interface ISpecialMaterialGenerator
    {
        bool CanHaveSpecialMaterial(string itemType, IEnumerable<string> attributes, IEnumerable<string> traits);
        string GenerateFor(string itemType, IEnumerable<string> attributes, IEnumerable<string> traits);
    }
}