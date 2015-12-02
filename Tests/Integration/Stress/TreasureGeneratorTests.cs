using Ninject;
using NUnit.Framework;
using System;
using TreasureGen.Generators;

namespace TreasureGen.Tests.Integration.Stress
{
    [TestFixture]
    public class TreasureGeneratorTests : StressTests
    {
        [Inject]
        public ITreasureGenerator TreasureGenerator { get; set; }

        [TestCase("Treasure generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var level = GetNewLevel();
            var treasure = TreasureGenerator.GenerateAtLevel(level);

            Assert.That(treasure.Coin.Currency, Is.Not.Null, "currency");
            Assert.That(treasure.Coin.Quantity, Is.AtLeast(0));
            Assert.That(treasure.Goods, Is.Not.Null, "goods");
            Assert.That(treasure.Items, Is.Not.Null, "items");
        }
    }
}