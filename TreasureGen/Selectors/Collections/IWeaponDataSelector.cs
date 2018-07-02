using TreasureGen.Selectors.Selections;

namespace TreasureGen.Selectors.Collections
{
    internal interface IWeaponDataSelector
    {
        WeaponSelection Select(string name);
    }
}
