using EquipmentGen.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress
{
    [TestFixture]
    public class TreasureGeneratorTests : StressTests
    {
        [Inject]
        public ITreasureGenerator TreasureGenerator { get; set; }

        [Test]
        public void StressedTreasureGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var level = GetNewLevel();
            var treasure = TreasureGenerator.GenerateAtLevel(level);

            Assert.That(treasure.Coin, Is.Not.Null, "coin");
            Assert.That(treasure.Goods, Is.Not.Null, "goods");
            Assert.That(treasure.Items, Is.Not.Null, "items");
        }
    }
}