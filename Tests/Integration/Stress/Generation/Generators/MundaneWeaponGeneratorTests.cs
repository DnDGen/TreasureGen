using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Data.Items;
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
            mundaneWeaponGenerator = mundaneGearGeneratorFactory.CreateWith(ItemsConstants.ItemTypes.Weapon);
            commonality = new[] { ItemsConstants.Gear.Types.Common, ItemsConstants.Gear.Types.Uncommon };
            range = new[] { ItemsConstants.Gear.Types.Melee, ItemsConstants.Gear.Types.Ranged };

            StartTest();
        }

        [TearDown]
        public void TearDown()
        {
            StopTest();
        }

        [Test]
        public void MundaneWeaponGeneratorGeneratesWeapon()
        {
            while (TestShouldKeepRunning())
            {
                var weapon = mundaneWeaponGenerator.Generate();

                Assert.That(weapon, Is.Not.Null);
                Assert.That(weapon.Name, Is.Not.Empty);
                Assert.That(weapon.Traits, Contains.Item(ItemsConstants.Gear.Traits.Masterwork));
                Assert.That(weapon.Abilities, Is.Empty);
                Assert.That(weapon.MagicalBonus, Is.EqualTo(0));
                Assert.That(weapon.Types, Contains.Item(ItemsConstants.ItemTypes.Weapon));

                var intersection = commonality.Intersect(weapon.Types);
                Assert.That(intersection, Is.Not.Empty, "Commonality");

                intersection = range.Intersect(weapon.Types);
                Assert.That(intersection, Is.Not.Empty, "Range");
            }

            AssertIterations();
        }
    }
}