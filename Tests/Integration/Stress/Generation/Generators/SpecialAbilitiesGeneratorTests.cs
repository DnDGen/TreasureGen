using System.Linq;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class SpecialAbilitiesGeneratorTests : StressTest
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
        public void StressedSpecialAbilitiesGeneratorMultiple()
        {
            while (TestShouldKeepRunning())
            {
                var types = GetNewTypes(true);
                var power = GetNewPower(false);
                var bonus = Random.Next(5) + 1;
                var quantity = Random.Next(10) + 1;
                var abilities = SpecialAbilitiesGenerator.GenerateFor(types, power, bonus, quantity);

                Assert.That(abilities.Count(), Is.AtLeast(1));

                var sum = abilities.Sum(a => a.BonusEquivalent);
                Assert.That(sum + bonus, Is.AtMost(10));

                var distinct = abilities.Select(a => a.CoreName).Distinct();
                Assert.That(abilities.Count(), Is.EqualTo(distinct.Count()));

                foreach (var ability in abilities)
                {
                    Assert.That(ability.Name, Is.Not.Empty);
                    Assert.That(ability.BonusEquivalent, Is.AtLeast(1));
                    Assert.That(ability.Strength, Is.Not.Negative);
                    Assert.That(ability.AttributeRequirements, Is.Not.Null);
                    Assert.That(ability.CoreName, Is.Not.Empty);
                }
            }

            AssertIterations();
        }

        [Test]
        public void StressedSpecialAbilitiesGeneratorSingular()
        {
            while (TestShouldKeepRunning())
            {
                var types = GetNewTypes(true);
                var power = GetNewPower(false);
                var ability = SpecialAbilitiesGenerator.GenerateFor(types, power);

                Assert.That(ability.Name, Is.Not.Empty);
                Assert.That(ability.BonusEquivalent, Is.AtLeast(1));
                Assert.That(ability.Strength, Is.Not.Negative);
                Assert.That(ability.AttributeRequirements, Is.Not.Null);
                Assert.That(ability.CoreName, Is.Not.Empty);
            }

            AssertIterations();
        }
    }
}