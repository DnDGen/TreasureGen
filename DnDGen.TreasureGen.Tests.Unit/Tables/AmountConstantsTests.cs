using DnDGen.TreasureGen.Tables;
using NUnit.Framework;
using System;

namespace DnDGen.TreasureGen.Tests.Unit.Tables
{
    [TestFixture]
    public class AmountConstantsTests
    {
        [TestCase(AmountConstants.Range1, "1")]
        [TestCase(AmountConstants.Range1d3, "1d3")]
        [TestCase(AmountConstants.Range1d4, "1d4")]
        [TestCase(AmountConstants.Range1d4x10, "1d4*10")]
        [TestCase(AmountConstants.Range1d4x100, "1d4*100")]
        [TestCase(AmountConstants.Range1d4x1000, "1d4*1000")]
        [TestCase(AmountConstants.Range1d4x10000, "1d4*10000")]
        [TestCase(AmountConstants.Range1d6, "1d6")]
        [TestCase(AmountConstants.Range1d6x100, "1d6*100")]
        [TestCase(AmountConstants.Range1d6x1000, "1d6*1000")]
        [TestCase(AmountConstants.Range1d6x10000, "1d6*10000")]
        [TestCase(AmountConstants.Range1d8, "1d8")]
        [TestCase(AmountConstants.Range1d8x10, "1d8*10")]
        [TestCase(AmountConstants.Range1d8x100, "1d8*100")]
        [TestCase(AmountConstants.Range1d8x1000, "1d8*1000")]
        [TestCase(AmountConstants.Range1d10, "1d10")]
        [TestCase(AmountConstants.Range1d10x10, "1d10*10")]
        [TestCase(AmountConstants.Range1d10x100, "1d10*100")]
        [TestCase(AmountConstants.Range1d10x1000, "1d10*1000")]
        [TestCase(AmountConstants.Range1d10x10000, "1d10*10000")]
        [TestCase(AmountConstants.Range1d12, "1d12")]
        [TestCase(AmountConstants.Range1d12x10, "1d12*10")]
        [TestCase(AmountConstants.Range1d12x100, "1d12*100")]
        [TestCase(AmountConstants.Range1d12x1000, "1d12*1000")]
        [TestCase(AmountConstants.Range1d12x10000, "1d12*10000")]
        [TestCase(AmountConstants.Range2d4x10, "2d4*10")]
        [TestCase(AmountConstants.Range2d4x100, "2d4*100")]
        [TestCase(AmountConstants.Range2d4x1000, "2d4*1000")]
        [TestCase(AmountConstants.Range2d6, "2d6")]
        [TestCase(AmountConstants.Range2d6x100, "2d6*100")]
        [TestCase(AmountConstants.Range2d6x1000, "2d6*1000")]
        [TestCase(AmountConstants.Range2d6x10000, "2d6*10000")]
        [TestCase(AmountConstants.Range2d8, "2d8")]
        [TestCase(AmountConstants.Range2d8x10, "2d8*10")]
        [TestCase(AmountConstants.Range2d8x100, "2d8*100")]
        [TestCase(AmountConstants.Range2d8x1000, "2d8*1000")]
        [TestCase(AmountConstants.Range2d10, "2d10")]
        [TestCase(AmountConstants.Range2d10x100, "2d10*100")]
        [TestCase(AmountConstants.Range2d10x1000, "2d10*1000")]
        [TestCase(AmountConstants.Range2d12x10, "2d12*10")]
        [TestCase(AmountConstants.Range3d4x10, "3d4*10")]
        [TestCase(AmountConstants.Range3d4x100, "3d4*100")]
        [TestCase(AmountConstants.Range3d4x1000, "3d4*1000")]
        [TestCase(AmountConstants.Range3d6x10, "3d6*10")]
        [TestCase(AmountConstants.Range3d6x100, "3d6*100")]
        [TestCase(AmountConstants.Range3d6x1000, "3d6*1000")]
        [TestCase(AmountConstants.Range3d8, "3d8")]
        [TestCase(AmountConstants.Range3d8x1000, "3d8*1000")]
        [TestCase(AmountConstants.Range3d10, "3d10")]
        [TestCase(AmountConstants.Range3d10x100, "3d10*100")]
        [TestCase(AmountConstants.Range3d10x1000, "3d10*1000")]
        [TestCase(AmountConstants.Range3d12, "3d12")]
        [TestCase(AmountConstants.Range3d12x1000, "3d12*1000")]
        [TestCase(AmountConstants.Range4d4, "4d4")]
        [TestCase(AmountConstants.Range4d4x10, "4d4*10")]
        [TestCase(AmountConstants.Range4d4x100, "4d4*100")]
        [TestCase(AmountConstants.Range4d6, "4d6")]
        [TestCase(AmountConstants.Range4d6x100, "4d6*100")]
        [TestCase(AmountConstants.Range4d8, "4d8")]
        [TestCase(AmountConstants.Range4d8x100, "4d8*100")]
        [TestCase(AmountConstants.Range4d8x1000, "4d8*1000")]
        [TestCase(AmountConstants.Range4d10, "4d10")]
        [TestCase(AmountConstants.Range4d10x10, "4d10*10")]
        [TestCase(AmountConstants.Range4d10x100, "4d10*100")]
        [TestCase(AmountConstants.Range4d12x1000, "4d12*1000")]
        [TestCase(AmountConstants.Range5d4x100, "5d4*100")]
        [TestCase(AmountConstants.Range5d6x10, "5d6*10")]
        [TestCase(AmountConstants.Range5d6x100, "5d6*100")]
        [TestCase(AmountConstants.Range6d4x100, "6d4*100")]
        [TestCase(AmountConstants.Range6d6, "6d6")]
        [TestCase(AmountConstants.Range7d6, "7d6")]
        public void RangeConstant(string constant, string originalRoll)
        {
            var sections = originalRoll.Split('d', '*');
            var originalQuantity = Convert.ToInt32(sections[0]);
            var originalDie = 1;
            var multiplier = 1;

            if (sections.Length > 1)
                originalDie = Convert.ToInt32(sections[1]);

            if (sections.Length > 2)
                multiplier = Convert.ToInt32(sections[2]);

            var minimum = originalQuantity * multiplier;
            var maximum = minimum * originalDie;

            var continuousDie = originalDie * multiplier - multiplier + 1;
            var addition = originalQuantity * (multiplier - 1);
            var continuousRoll = $"{originalQuantity}";

            if (continuousDie > 1)
                continuousRoll += $"d{continuousDie}";

            if (addition < 0)
                continuousRoll += addition.ToString();
            else if (addition > 0)
                continuousRoll += $"+{addition}";

            Assert.That(originalQuantity + addition, Is.EqualTo(minimum));
            Assert.That(originalQuantity * continuousDie + addition, Is.EqualTo(maximum));
            Assert.That(constant, Is.EqualTo(continuousRoll));
        }
    }
}
