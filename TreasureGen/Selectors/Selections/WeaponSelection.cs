using System.Collections.Generic;

namespace TreasureGen.Selectors.Selections
{
    internal class WeaponSelection
    {
        public string DamageType { get; set; }
        public string ThreatRange { get; set; }
        public string CriticalMultiplier { get; set; }
        public Dictionary<string, string> DamageBySize { get; set; }
        public string Ammunition { get; set; }

        public WeaponSelection()
        {
            DamageBySize = new Dictionary<string, string>();
        }
    }
}
