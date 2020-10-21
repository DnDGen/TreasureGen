using DnDGen.TreasureGen.Items;
using System.Collections.Generic;

namespace DnDGen.TreasureGen.Selectors.Selections
{
    internal class WeaponSelection
    {
        public const char DamageDivider = '#';
        public const char DamageSplitDivider = ',';

        public string ThreatRange { get; set; }
        public Dictionary<string, List<Damage>> DamagesBySize { get; set; }
        public Dictionary<string, List<Damage>> CriticalDamagesBySize { get; set; }
        public string Ammunition { get; set; }

        public WeaponSelection()
        {
            DamagesBySize = new Dictionary<string, List<Damage>>();
            CriticalDamagesBySize = new Dictionary<string, List<Damage>>();
        }
    }
}
