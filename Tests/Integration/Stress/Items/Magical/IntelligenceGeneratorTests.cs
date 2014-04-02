using System;
using System.Collections.Generic;
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

        [Test]
        public void StressedIntelligenceGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var attributes = GetNewAttributes(true);
            var power = GetNewPower(false);
            var magic = new Dictionary<Magic, Object>();
            var bonus = Random.Next(5) + 1;
            var quantity = Random.Next(10) + 1;

            magic[Magic.Bonus] = bonus;
            magic[Magic.Abilities] = AbilitiesGenerator.GenerateWith(attributes, power, bonus, quantity);

            var intelligence = IntelligenceGenerator.GenerateFor(magic);

            Assert.That(intelligence.Alignment, Contains.Item("Lawful").Or.Contains("Neutral").Or.Contains("Chaotic"));
            Assert.That(intelligence.Alignment, Contains.Item("Good").Or.Contains("Neutral").Or.Contains("Evil"));
            Assert.That(intelligence.CharismaStat, Is.InRange<Int32>(10, 18));
            Assert.That(intelligence.Communication, Is.Not.Empty);
            Assert.That(intelligence.DedicatedPower, Is.Not.Null);
            Assert.That(intelligence.Ego, Is.GreaterThan(0));
            Assert.That(intelligence.IntelligenceStat, Is.InRange<Int32>(10, 18));
            Assert.That(intelligence.Powers, Is.Not.Empty);
            Assert.That(intelligence.Senses, Is.Not.Empty);
            Assert.That(intelligence.SpecialPurpose, Is.Not.Null);
            Assert.That(intelligence.WisdomStat, Is.InRange<Int32>(10, 18));
        }
    }
}