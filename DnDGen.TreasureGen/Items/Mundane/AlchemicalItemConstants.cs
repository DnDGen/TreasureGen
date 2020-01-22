using System.Collections.Generic;

namespace DnDGen.TreasureGen.Items.Mundane
{
    public static class AlchemicalItemConstants
    {
        public const string AlchemistsFire = "Alchemist's fire";
        public const string Acid = "Acid";
        public const string Smokestick = "Smokestick";
        public const string HolyWater = "Holy water";
        public const string Antitoxin = "Antitoxin";
        public const string EverburningTorch = "Everburning torch";
        public const string TanglefootBag = "Tanglefoot bag";
        public const string Thunderstone = "Thunderstone";

        public static IEnumerable<string> GetAllAlchemicalItems()
        {
            return new[]
            {
                AlchemistsFire,
                Acid,
                Smokestick,
                HolyWater,
                Antitoxin,
                EverburningTorch,
                TanglefootBag,
                Thunderstone
            };
        }
    }
}
