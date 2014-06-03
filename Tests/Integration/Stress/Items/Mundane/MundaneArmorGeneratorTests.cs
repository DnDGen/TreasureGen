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
    public class MundaneArmorGeneratorTests : StressTests
    {
        [Inject, Named(ItemTypeConstants.Armor)]
        public IMundaneItemGenerator MundaneArmorGenerator { get; set; }

        private IEnumerable<String> materials;

        [SetUp]
        public void Setup()
        {
            materials = TraitConstants.GetSpecialMaterials();
        }

        [Test]
        public void StressedMundaneArmorGenerator()
        {
            StressGenerator();
        }

        protected override void MakeAssertions()
        {
            var armor = MundaneArmorGenerator.Generate();

            Assert.That(armor.Name, Is.Not.Empty);
            Assert.That(armor.Traits, Is.Not.Null);
            Assert.That(armor.ItemType, Is.EqualTo(ItemTypeConstants.Armor), armor.Name);
            Assert.That(armor.Attributes, Is.Not.Null);
            Assert.That(armor.Quantity, Is.EqualTo(1));
            Assert.That(armor.IsMagical, Is.False);
            Assert.That(armor.Contents, Is.Empty);
        }

        [Test]
        public void SpecialMaterialsHappen()
        {
            var armor = new Item();

            do armor = MundaneArmorGenerator.Generate();
            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && !armor.Traits.Intersect(materials).Any());

            var weaponMaterials = armor.Traits.Intersect(materials);
            Assert.That(weaponMaterials, Is.Not.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void NoDecorationsHappen()
        {
            var armor = new Item();

            do armor = MundaneArmorGenerator.Generate();
            while (Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && armor.Traits.Intersect(materials).Any());

            var weaponMaterials = armor.Traits.Intersect(materials);
            Assert.That(weaponMaterials, Is.Empty);
            Assert.Pass("Milliseconds: {0}", Stopwatch.ElapsedMilliseconds);
        }
    }
}