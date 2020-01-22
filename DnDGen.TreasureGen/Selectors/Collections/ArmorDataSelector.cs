using DnDGen.Infrastructure.Selectors.Collections;
using System;
using System.Linq;
using DnDGen.TreasureGen.Selectors.Selections;
using DnDGen.TreasureGen.Tables;

namespace DnDGen.TreasureGen.Selectors.Collections
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
