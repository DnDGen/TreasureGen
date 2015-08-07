using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items;
using TreasureGen.Generators.Items.Magical;

namespace TreasureGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class IntelligenceGeneratorTests : StressTests
    {
        [Inject]
        public IIntelligenceGenerator IntelligenceGenerator { get; set; }
        [Inject]
        public ISpecialAbilitiesGenerator AbilitiesGenerator { get; set; }
        [Inject]
        public IItemsGenerator ItemsGenerator { get; set; }

        private IEnumerable<String> alignments;

        [SetUp]
        public void Setup()
        {
            alignments = IntelligenceAlignmentConstants.GetAllAlignments();
        }

        [TestCase("Intelligence generator")]
        public override void Stress(String thingToStress)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var intelligence = GenerateIntelligence();

            Assert.That(alignments, Contains.Item(intelligence.Alignment));
            Assert.That(intelligence.CharismaStat, Is.InRange<Int32>(10, 19));
            Assert.That(intelligence.Communication, Is.Not.Empty);
            Assert.That(intelligence.DedicatedPower, Is.Not.Null);
            Assert.That(intelligence.Ego, Is.GreaterThan(0));
            Assert.That(intelligence.IntelligenceStat, Is.InRange<Int32>(10, 19));
            Assert.That(intelligence.Powers, Is.Not.Empty);
            Assert.That(intelligence.Senses, Is.Not.Empty);
            Assert.That(intelligence.SpecialPurpose, Is.Not.Null);
            Assert.That(intelligence.WisdomStat, Is.InRange<Int32>(10, 19));
            Assert.That(intelligence.Personality, Is.Not.Null);
        }

        private Intelligence GenerateIntelligence()
        {
            Item intelligentItem = null;

            do
            {
                var level = GetNewLevel();
                var items = ItemsGenerator.GenerateAtLevel(level);

                foreach (var item in items)
                    if (IntelligenceGenerator.IsIntelligent(item.ItemType, item.Attributes, item.IsMagical))
                        intelligentItem = item;
            } while (intelligentItem == null);

            return IntelligenceGenerator.GenerateFor(intelligentItem);
        }

        [Test]
        public void SpecialPurposeHappens()
        {
            Intelligence intelligence;

            do intelligence = GenerateIntelligence();
            while (TestShouldKeepRunning() && String.IsNullOrEmpty(intelligence.SpecialPurpose));

            Assert.That(intelligence.SpecialPurpose, Is.Not.Empty);
            Assert.That(intelligence.DedicatedPower, Is.Not.Empty);
        }

        [Test]
        public void SpecialPurposeDoesNotHappen()
        {
            Intelligence intelligence;

            do intelligence = GenerateIntelligence();
            while (TestShouldKeepRunning() && !String.IsNullOrEmpty(intelligence.SpecialPurpose));

            Assert.That(intelligence.SpecialPurpose, Is.Empty);
            Assert.That(intelligence.DedicatedPower, Is.Empty);
        }

        [Test]
        public void LanguagesHappen()
        {
            Intelligence intelligence;

            do intelligence = GenerateIntelligence();
            while (TestShouldKeepRunning() && !intelligence.Languages.Any());

            Assert.That(intelligence.Languages, Contains.Item("Common"));
        }

        [Test]
        public void LanguagesDoNotHappen()
        {
            Intelligence intelligence;

            do intelligence = GenerateIntelligence();
            while (TestShouldKeepRunning() && intelligence.Languages.Any());

            Assert.That(intelligence.Languages, Is.Empty);
        }

        [Test]
        public void KnowledgeCategoriesAreFilled()
        {
            Intelligence intelligence;

            do intelligence = GenerateIntelligence();
            while (TestShouldKeepRunning() && intelligence.Powers.Any(p => p.Contains("Knowledge")) == false);

            var knowledgePowers = intelligence.Powers.Where(p => p.Contains("Knowledge"));
            foreach (var knowledgePower in knowledgePowers)
            {
                Assert.That(knowledgePower, Is.Not.Contains("KNOWLEDGECATEGORIES"));
                Assert.That(knowledgePower, Is.Not.Contains("KNOWLEDGECATEGORY"));
                Assert.That(knowledgePower, Is.Not.Contains("KNOWLEDGE"));
            }
        }
    }
}