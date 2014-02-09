using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Generation.Generators
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests : StressTest
    {
        [Inject]
        public IMundaneGearGeneratorFactory mundaneGearGeneratorFactory { get; set; }

        private IMundaneGearGenerator mundaneWeaponGenerator;

        private IEnumerable<String> commonality;
        private IEnumerable<String> range;

        [SetUp]
        public void Setup()
        {
            mundaneWeaponGenerator = mundaneGearGeneratorFactory.CreateWith(ItemTypeConstants.Weapon);
            commonality = new[] { TypeConstants.Common, TypeConstants.Uncommon };
            range = new[] { TypeConstants.Melee, TypeConstants.Ranged };

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void StressedMundaneWeaponGenerator()
        {
            while (TestShouldKeepRunning())
            {
                var weapon = mundaneWeaponGenerator.Generate();

                Assert.That(weapon.Name, Is.Not.Empty);
                Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
                Assert.That(weapon.Abilities, Is.Empty);
                Assert.That(weapon.MagicalBonus, Is.EqualTo(0));
                Assert.That(weapon.Types, Contains.Item(ItemTypeConstants.Weapon));
                Assert.That(weapon.Charges, Is.EqualTo(0));
                Assert.That(weapon.ChargesRenewable, Is.False);
                Assert.That(weapon.Intelligence.IsIntelligent, Is.False);
                Assert.That(weapon.Intelligence.Alignment, Is.Empty);
                Assert.That(weapon.Intelligence.CharismaStat, Is.EqualTo(0));
                Assert.That(weapon.Intelligence.Communication, Is.Empty);
                Assert.That(weapon.Intelligence.Ego, Is.EqualTo(0));
                Assert.That(weapon.Intelligence.IntelligenceStat, Is.EqualTo(0));
                Assert.That(weapon.Intelligence.Powers, Is.Empty);
                Assert.That(weapon.Intelligence.DedicatedPower, Is.Empty);
                Assert.That(weapon.Intelligence.Senses, Is.Empty);
                Assert.That(weapon.Intelligence.SpecialPurpose, Is.Empty);
                Assert.That(weapon.Intelligence.WisdomStat, Is.EqualTo(0));

                var intersection = commonality.Intersect(weapon.Types);
                Assert.That(intersection, Is.Not.Empty, "Commonality");

                intersection = range.Intersect(weapon.Types);
                Assert.That(intersection, Is.Not.Empty, "Range");
            }

            AssertIterations();
        }
    }
}