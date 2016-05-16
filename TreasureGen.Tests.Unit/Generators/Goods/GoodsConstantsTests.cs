using NUnit.Framework;
using TreasureGen.Goods;

namespace TreasureGen.Tests.Unit.Generators.Goods
{
    [TestFixture]
    public class GoodsConstantsTests
    {
        [TestCase(GoodsConstants.Gem, "Gem")]
        [TestCase(GoodsConstants.Art, "Art")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}