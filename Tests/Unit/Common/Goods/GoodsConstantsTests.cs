using System;
using TreasureGen.Common.Goods;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Common.Goods
{
    [TestFixture]
    public class GoodsConstantsTests
    {
        [TestCase(GoodsConstants.Gem, "Gem")]
        [TestCase(GoodsConstants.Art, "Art")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}