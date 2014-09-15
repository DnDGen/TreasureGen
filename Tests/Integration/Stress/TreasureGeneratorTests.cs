using System;
using EquipmentGen.Common;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Tests.Integration.Stress.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress
{
    [TestFixture]
    public class TreasureGeneratorTests : StressTests
    {
        [Inject]
        public ITreasureGenerator TreasureGenerator { get; set; }
        [Inject]
        public InterestCalculator InterestCalculator { get; set; }
        [Inject]
        public InterestFormatter InterestFormatter { get; set; }

        private Treasure mostInterestingTreasure;
        private Int32 mostInterestingScore;

        [SetUp]
        public void Setup()
        {
            mostInterestingScore = 0;
        }

        [TearDown]
        public void TearDown()
        {
            if (mostInterestingTreasure != null)
            {
                var output = InterestFormatter.MakeOutput(mostInterestingTreasure);
                Assert.Pass(output);
            }
        }

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

            var score = 0;
            foreach (var item in treasure.Items)
                score += InterestCalculator.CalculateInterest(item);

            if (score > mostInterestingScore)
            {
                mostInterestingScore = score;
                mostInterestingTreasure = treasure;
            }
        }
    }
}