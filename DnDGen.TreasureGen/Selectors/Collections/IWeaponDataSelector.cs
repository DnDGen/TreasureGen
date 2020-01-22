using DnDGen.TreasureGen.Selectors.Selections;

namespace DnDGen.TreasureGen.Selectors.Collections
{
    internal interface IWeaponDataSelector
    {
        WeaponSelection Select(string name);
    }
}
