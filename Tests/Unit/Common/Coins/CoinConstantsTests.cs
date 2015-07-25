using System;
using TreasureGen.Common.Coins;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Common.Coins
{
    [TestFixture]
    public class CoinConstantsTests
    {
        [TestCase(CoinConstants.Gold, "Gold")]
        [TestCase(CoinConstants.Platinum, "Platinum")]
        [TestCase(CoinConstants.Silver, "Silver")]
        [TestCase(CoinConstants.Copper, "Copper")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}