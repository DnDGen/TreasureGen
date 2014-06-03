using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Weapon)]
        public IMundaneItemGenerator MundaneWeaponGenerator { get; set; }

        private IEnumerable<String> materials;

        [SetUp]
        public void Setup()
        {
            materials = TraitConstants.GetSpecialMaterials();
        }

        [Test]
        public void StressedMundaneWeaponGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var weapon = MundaneWeaponGenerator.Generate();

            Assert.That(weapon.Name, Is.Not.Empty);
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.GreaterThan(0));
            Assert.That(weapon.IsMagical, Is.False);
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Common).Or.Contains(AttributeConstants.Uncommon));
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Melee).Or.Contains(AttributeConstants.Ranged));
            Assert.That(weapon.Contents, Is.Empty);
        }

        [Test]
        public void SpecialMaterialsHappen()
        {
            var weapon = new Item();

            do weapon = MundaneWeaponGenerator.Generate();
            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && !weapon.Traits.Intersect(materials).Any());

            var weaponMaterials = weapon.Traits.Intersect(materials);
            Assert.That(weaponMaterials, Is.Not.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void NoDecorationsHappen()
        {
            var weapon = new Item();

            do weapon = MundaneWeaponGenerator.Generate();
            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && weapon.Traits.Intersect(materials).Any());

            var weaponMaterials = weapon.Traits.Intersect(materials);
            Assert.That(weaponMaterials, Is.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }
    }
}