using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Magical
{
    [TestFixture]
    public class IntelligenceGeneratorTests : StressTests
    {
        [Inject]
        public IIntelligenceGenerator IntelligenceGenerator { get; set; }
        [Inject]
        public ISpecialAbilitiesGenerator AbilitiesGenerator { get; set; }

        private IEnumerable<String> alignments;
        private IEnumerable<String> armorNames;
        private IEnumerable<String> weaponNames;

        [SetUp]
        public void Setup()
        {
            alignments = new[]
                {
                    "Lawful good",
                    "Neutral good",
                    "Chaotic good",
                    "Lawful neutral",
                    "True neutral",
                    "Chaotic neutral",
                    "Lawful evil",
                    "Neutral evil",
                    "Chaotic evil",
                };

            armorNames = ArmorConstants.GetAllArmors();
            weaponNames = WeaponConstants.GetAllWeapons();
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
            var itemType = GetNewGearItemType();
            var attributes = GetNewAttributesForGear(itemType, false);
            var power = GetNewPower(false);
            var quantity = Random.Next(10) + 1;

            var item = new Item();

            if (itemType == ItemTypeConstants.Armor)
                item.Name = GetNameFrom(armorNames);
            else
                item.Name = GetNameFrom(weaponNames);

            item.Magic.Bonus = Random.Next(5) + 1;
            item.Magic.SpecialAbilities = AbilitiesGenerator.GenerateFor(itemType, attributes, power, item.Magic.Bonus, quantity);

            return IntelligenceGenerator.GenerateFor(item);
        }

        private String GetNameFrom(IEnumerable<String> names)
        {
            var index = Random.Next(names.Count());
            return names.ElementAt(index);
        }

        [Test]
        public void SpecialPurposeHappens()
        {
            Intelligence intelligence;

            do intelligence = GenerateIntelligence();
            while (TestShouldKeepRunning() && String.IsNullOrEmpty(intelligence.SpecialPurpose));

            Assert.That(intelligence.SpecialPurpose, Is.Not.Empty);
            Assert.That(intelligence.DedicatedPower, Is.Not.Empty);
            AssertIterations();
        }

        [Test]
        public void SpecialPurposeDoesNotHappen()
        {
            Intelligence intelligence;

            do intelligence = GenerateIntelligence();
            while (TestShouldKeepRunning() && !String.IsNullOrEmpty(intelligence.SpecialPurpose));

            Assert.That(intelligence.SpecialPurpose, Is.Empty);
            Assert.That(intelligence.DedicatedPower, Is.Empty);
            AssertIterations();
        }

        [Test]
        public void LanguagesHappen()
        {
            Intelligence intelligence;

            do intelligence = GenerateIntelligence();
            while (TestShouldKeepRunning() && !intelligence.Languages.Any());

            Assert.That(intelligence.Languages, Contains.Item("Common"));
            AssertIterations();
        }

        [Test]
        public void LanguagesDoNotHappen()
        {
            Intelligence intelligence;

            do intelligence = GenerateIntelligence();
            while (TestShouldKeepRunning() && intelligence.Languages.Any());

            Assert.That(intelligence.Languages, Is.Empty);
            AssertIterations();
        }
    }
}