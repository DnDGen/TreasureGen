﻿using System;
using System.Linq;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class SpecialAbilitiesGeneratorTests : StressTests
    {
        [Inject]
        public ISpecialAbilitiesGenerator SpecialAbilitiesGenerator { get; set; }

        [SetUp]
        public void Setup()
        {
            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void StressedSpecialAbilitiesGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var types = GetNewAttributes(true);
                var power = GetNewPower(false);
                var bonus = Random.Next(5) + 1;
                var quantity = Random.Next(10) + 1;

                Console.WriteLine("Attributes: {0}", String.Join(",", types));
                Console.WriteLine("Power: {0}", power);
                Console.WriteLine("Bonus: {0}", bonus);
                Console.WriteLine("Quantity: {0}", quantity);

                var abilities = SpecialAbilitiesGenerator.GenerateWith(types, power, bonus, quantity);

                Assert.That(abilities.Count(), Is.AtLeast(1));

                var sum = abilities.Sum(a => a.BonusEquivalent);
                Assert.That(sum + bonus, Is.AtMost(10));

                var distinct = abilities.Select(a => a.CoreName).Distinct();
                Assert.That(abilities.Count(), Is.EqualTo(distinct.Count()));

                foreach (var ability in abilities)
                {
                    Assert.That(ability.Name, Is.Not.Empty);
                    Assert.That(ability.BonusEquivalent, Is.InRange<Int32>(0, 5));
                    Assert.That(ability.Strength, Is.Not.Negative);
                    Assert.That(ability.AttributeRequirements, Is.Not.Null);
                    Assert.That(ability.CoreName, Is.Not.Empty);
                }
            }

            AssertIterations();
        }
    }
}