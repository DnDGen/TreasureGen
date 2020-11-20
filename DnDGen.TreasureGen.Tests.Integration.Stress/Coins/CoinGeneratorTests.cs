using DnDGen.TreasureGen.Coins;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Coins
{
    [TestFixture]
    public class CoinGeneratorTests : StressTests
    {
        private ICoinGenerator coinGenerator;

        [SetUp]
        public void Setup()
        {
            coinGenerator = GetNewInstanceOf<ICoinGenerator>();
        }

        [Test]
        public void StressCoins()
        {
            stressor.Stress(GenerateAndAssertCoins);
        }

        private void GenerateAndAssertCoins()
        {
            var level = GetNewLevel();
            var coin = coinGenerator.GenerateAtLevel(level);

            if (string.IsNullOrEmpty(coin.Currency))
            {
                Assert.That(coin.Currency, Is.Empty);
                Assert.That(coin.Quantity, Is.Zero);
            }
            else
            {
                Assert.That(coin.Currency, Is.EqualTo(CoinConstants.Copper)
                    .Or.EqualTo(CoinConstants.Gold)
                    .Or.EqualTo(CoinConstants.Platinum)
                    .Or.EqualTo(CoinConstants.Silver));
                Assert.That(coin.Quantity, Is.Positive);
            }
        }
    }
}