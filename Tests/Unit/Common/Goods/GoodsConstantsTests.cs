using System;
using EquipmentGen.Common.Goods;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Common.Goods
{
    [TestFixture]
    public class GoodsConstantsTests
    {
        [TestCase(GoodsConstants.Gem, "Gem")]
        [TestCase(GoodsConstants.Art, "Art")]
        public void GoodsConstantIsCorrect(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}