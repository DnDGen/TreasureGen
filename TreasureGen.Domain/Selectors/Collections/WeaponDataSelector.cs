using System.Linq;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;

namespace TreasureGen.Domain.Selectors.Collections
{
    internal class WeaponDataSelector : IWeaponDataSelector
    {
        private readonly ICollectionsSelector innerSelector;

        public WeaponDataSelector(ICollectionsSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public WeaponSelection Select(string name)
        {
            var data = innerSelector.SelectFrom(TableNameConstants.Collections.Set.WeaponData, name).ToArray();
            var damages = innerSelector.SelectFrom(TableNameConstants.Collections.Set.WeaponDamages, name).ToArray();

            var selection = new WeaponSelection();
            selection.CriticalMultiplier = data[DataIndexConstants.Weapon.CriticalMultiplier];
            selection.DamageType = data[DataIndexConstants.Weapon.DamageType];
            selection.ThreatRange = data[DataIndexConstants.Weapon.ThreatRange];

            var sizes = TraitConstants.Sizes.All().ToArray();

            for (var i = 0; i < sizes.Length; i++)
            {
                selection.DamageBySize[sizes[i]] = damages[i];
            }

            return selection;
        }
    }
}
