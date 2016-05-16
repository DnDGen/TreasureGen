using System.Collections.Generic;
using System.Linq;

namespace TreasureGen.Items.Magical
{
    public class SpecialAbility
    {
        public string Name { get; set; }
        public string BaseName { get; set; }
        public int Power { get; set; }
        public IEnumerable<string> AttributeRequirements { get; set; }
        public int BonusEquivalent { get; set; }

        public SpecialAbility()
        {
            AttributeRequirements = Enumerable.Empty<string>();
            Name = string.Empty;
            BaseName = string.Empty;
        }
    }
}