using System.Collections.Generic;
using System.Linq;

namespace TreasureGen.Items.Magical
{
    public class Magic
    {
        public int Bonus { get; set; }
        public int Charges { get; set; }
        public IEnumerable<SpecialAbility> SpecialAbilities { get; set; }
        public string Curse { get; set; }
        public Intelligence Intelligence { get; set; }

        public Magic()
        {
            SpecialAbilities = Enumerable.Empty<SpecialAbility>();
            Curse = string.Empty;
            Intelligence = new Intelligence();
        }
    }
}