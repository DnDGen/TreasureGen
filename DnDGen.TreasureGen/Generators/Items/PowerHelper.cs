using DnDGen.TreasureGen.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Generators.Items
{
    internal static class PowerHelper
    {
        public static string AdjustPower(string requestedPower, IEnumerable<string> availablePowers)
        {
            if (!availablePowers.Any())
                throw new ArgumentException($"No available powers from which to adjust the requested power: {requestedPower}");

            if (availablePowers.Contains(requestedPower))
                return requestedPower;

            var allPowers = new List<string>
            {
                PowerConstants.Mundane,
                PowerConstants.Minor,
                PowerConstants.Medium,
                PowerConstants.Major,
            };

            var index = allPowers.IndexOf(requestedPower);
            if (index > availablePowers.Count() - 1)
                return availablePowers.Last();

            return availablePowers.First();
        }
    }
}
