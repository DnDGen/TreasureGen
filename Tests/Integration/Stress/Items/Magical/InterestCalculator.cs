using System;
using System.Linq;
using EquipmentGen.Common.Items;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    public class InterestCalculator
    {
        public Int32 CalculateInterest(Item item)
        {
            var total = 0;

            total += item.Contents.Count;
            total += item.Magic.Bonus;

            var charged = item.Magic.Charges > 0;
            total += Convert.ToInt32(charged);
            total += Convert.ToInt32(item.Magic.Curse.Any());
            total += item.Magic.Intelligence.Ego;
            total += item.Magic.SpecialAbilities.Count();
            total += item.Traits.Count;

            return total;
        }
    }
}