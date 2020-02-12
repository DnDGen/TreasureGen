using DnDGen.TreasureGen.Coins;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Coins
{
    [TestFixture]
    public class CoinConstantsTests
    {
        [TestCase(CoinConstants.Gold, "Gold")]
        [TestCase(CoinConstants.Platinum, "Platinum")]
        [TestCase(CoinConstants.Silver, "Silver")]
        [TestCase(CoinConstants.Copper, "Copper")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}