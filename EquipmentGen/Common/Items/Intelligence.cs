using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentGen.Common.Items
{
    public class Intelligence
    {
        public Int32 IntelligenceStat { get; set; }
        public Int32 WisdomStat { get; set; }
        public Int32 CharismaStat { get; set; }
        public List<String> Powers { get; set; }
        public String SpecialPurpose { get; set; }
        public String DedicatedPower { get; set; }
        public Int32 Ego { get; set; }
        public IEnumerable<String> Communication { get; set; }
        public List<String> Languages { get; set; }
        public String Senses { get; set; }
        public String Alignment { get; set; }
        public String Personality { get; set; }

        public Intelligence()
        {
            Powers = new List<String>();
            SpecialPurpose = String.Empty;
            DedicatedPower = String.Empty;
            Communication = Enumerable.Empty<String>();
            Senses = String.Empty;
            Alignment = String.Empty;
            Languages = new List<String>();
            Personality = String.Empty;
        }
    }
}