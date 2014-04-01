using EquipmentGen.Generators.Interfaces.Coins;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Coins
{
    [TestFixture]
    public class CoinGeneratorTests : StressTests
    {
        [Inject]
        public ICoinGenerator CoinGenerator { get; set; }

        protected override void StressGenerator()
        {
            var level = GetNewLevel();
            var coin = CoinGenerator.GenerateAtLevel(level);

            Assert.That(coin.Currency, Is.Not.Null);
            Assert.That(coin.Quantity, Is.GreaterThanOrEqualTo(0));
        }
    }
}