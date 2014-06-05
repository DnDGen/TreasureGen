using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public abstract class MagicalItemGeneratorStressTests : StressTests
    {
        [Inject]
        public InterestCalculator InterestCalculator { get; set; }
        [Inject]
        public InterestFormatter InterestFormatter { get; set; }

        protected IEnumerable<String> materials;

        private Item mostInterestingItem;
        private Int32 mostInterestingScore;

        [SetUp]
        public void MundaneItemGeneratorStressSetup()
        {
            materials = TraitConstants.GetSpecialMaterials();
            mostInterestingScore = 0;
        }

        [TearDown]
        public void TearDown()
        {
            if (mostInterestingItem != null)
            {
                var output = InterestFormatter.MakeOutput(mostInterestingItem);
                Assert.Pass(output);
            }
        }

        protected override void MakeAssertions()
        {
            var item = GenerateItem();

            if (item.ItemType == ItemTypeConstants.SpecificCursedItem)
                return;

            MakeAssertionsAgainst(item);

            var score = InterestCalculator.CalculateInterest(item);
            if (score > mostInterestingScore)
            {
                mostInterestingScore = score;
                mostInterestingItem = item;
            }
        }

        protected abstract Item GenerateItem();
        protected abstract void MakeAssertionsAgainst(Item item);

        protected void AssertIntelligenceHappens()
        {
            var item = new Item();

            while (TestShouldKeepRunning() && item.Magic.Intelligence.Ego == 0)
                item = GenerateItem();

            Assert.That(item.Magic.Intelligence.Ego, Is.GreaterThan(0), type);
            AssertIterations();
        }

        [Test]
        public void CursesHappen()
        {
            var item = new Item();

            while (TestShouldKeepRunning() && (String.IsNullOrEmpty(item.Magic.Curse) || item.ItemType == ItemTypeConstants.SpecificCursedItem))
                item = GenerateItem();

            Assert.That(item.ItemType, Is.Not.EqualTo(ItemTypeConstants.SpecificCursedItem), type);
            Assert.That(item.Magic.Curse, Is.Not.Empty, type);
            AssertIterations();
        }

        [Test]
        public void SpecificCursesHappen()
        {
            var item = new Item();

            while (TestShouldKeepRunning() && item.ItemType != ItemTypeConstants.SpecificCursedItem)
                item = GenerateItem();

            Assert.That(item.ItemType, Is.EqualTo(ItemTypeConstants.SpecificCursedItem), type);
            AssertIterations();
        }

        protected void AssertTraitsHappen()
        {
            var item = new Item();

            do item = GenerateItem();
            while (TestShouldKeepRunning() && !item.Traits.Except(materials).Any());

            var traits = item.Traits.Except(materials);
            Assert.That(traits, Is.Not.Empty, type);
            AssertIterations();
        }

        protected void AssertSpecialMaterialsHappen()
        {
            var item = new Item();

            do item = GenerateItem();
            while (TestShouldKeepRunning() && !item.Traits.Intersect(materials).Any());

            var itemMaterials = item.Traits.Intersect(materials);
            Assert.That(itemMaterials, Is.Not.Empty, type);
            AssertIterations();
        }

        [Test]
        public void NoDecorationsHappen()
        {
            var item = new Item();

            do item = GenerateItem();
            while (TestShouldKeepRunning() && (item.Traits.Any() || item.Magic.Curse.Any() || item.Magic.Intelligence.Ego > 0));

            Assert.That(item.Traits, Is.Empty, type);
            Assert.That(item.Magic.Curse, Is.Empty, type);
            Assert.That(item.Magic.Intelligence.Ego, Is.EqualTo(0), type);
            AssertIterations();
        }
    }
}