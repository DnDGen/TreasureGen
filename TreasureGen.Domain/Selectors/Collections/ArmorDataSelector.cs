using DnDGen.Core.Selectors.Collections;
using System;
using System.Linq;
using TreasureGen.Domain.Selectors.Selections;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Domain.Selectors.Collections
{
    internal class ArmorDataSelector : IArmorDataSelector
    {
        private readonly ICollectionSelector innerSelector;

        public ArmorDataSelector(ICollectionSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public ArmorSelection Select(string name)
        {
            var data = innerSelector.SelectFrom(TableNameConstants.Collections.Set.ArmorData, name).ToArray();

            var selection = new ArmorSelection();
            selection.ArmorBonus = Convert.ToInt32(data[DataIndexConstants.Armor.ArmorBonus]);
            selection.ArmorCheckPenalty = Convert.ToInt32(data[DataIndexConstants.Armor.ArmorCheckPenalty]);
            selection.MaxDexterityBonus = Convert.ToInt32(data[DataIndexConstants.Armor.MaxDexterityBonus]);

            return selection;
        }
    }
}
