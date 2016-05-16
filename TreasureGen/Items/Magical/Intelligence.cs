using System.Collections.Generic;
using System.Linq;

namespace TreasureGen.Items.Magical
{
    public class Intelligence
    {
        public int IntelligenceStat { get; set; }
        public int WisdomStat { get; set; }
        public int CharismaStat { get; set; }
        public List<string> Powers { get; set; }
        public string SpecialPurpose { get; set; }
        public string DedicatedPower { get; set; }
        public int Ego { get; set; }
        public IEnumerable<string> Communication { get; set; }
        public List<string> Languages { get; set; }
        public string Senses { get; set; }
        public string Alignment { get; set; }
        public string Personality { get; set; }

        public Intelligence()
        {
            Powers = new List<string>();
            SpecialPurpose = string.Empty;
            DedicatedPower = string.Empty;
            Communication = Enumerable.Empty<string>();
            Senses = string.Empty;
            Alignment = string.Empty;
            Languages = new List<string>();
            Personality = string.Empty;
        }
    }
}