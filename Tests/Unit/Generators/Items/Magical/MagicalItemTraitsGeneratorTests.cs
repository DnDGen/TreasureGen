using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalItemTraitsGeneratorTests
    {
        private IMagicalItemTraitsGenerator generator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private List<String> attributes;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            generator = new MagicalItemTraitsGenerator(mockPercentileSelector.Object);
            attributes = new List<String>();
        }

        [Test]
        public void ReturnTraits()
        {
            var traits = generator.GenerateFor("item type", attributes);
            Assert.That(traits, Is.Not.Null);
        }

        [Test]
        public void GetTraitsFromPercentileSelector()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("item typeTraits")).Returns("trait");
            var traits = generator.GenerateFor("item type", attributes);
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void IMeleefWeapon_GetMeleeTraits()
        {
            attributes.Add(AttributeConstants.Melee);
            mockPercentileSelector.Setup(p => p.SelectFrom("MeleeWeaponTraits")).Returns("trait");

            var traits = generator.GenerateFor(ItemTypeConstants.Weapon, attributes);
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void IfRangedWeapon_GetRangedTraits()
        {
            attributes.Add(AttributeConstants.Ranged);
            mockPercentileSelector.Setup(p => p.SelectFrom("RangedWeaponTraits")).Returns("trait");

            var traits = generator.GenerateFor(ItemTypeConstants.Weapon, attributes);
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void IfMeleeAndRangedWeapon_GetMeleeTraits()
        {
            attributes.Add(AttributeConstants.Melee);
            attributes.Add(AttributeConstants.Ranged);
            mockPercentileSelector.Setup(p => p.SelectFrom("MeleeWeaponTraits")).Returns("trait");

            var traits = generator.GenerateFor(ItemTypeConstants.Weapon, attributes);
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void IfWeaponNotMeleeNorRanged_ThrowException()
        {
            Assert.That(() => generator.GenerateFor(ItemTypeConstants.Weapon, attributes), Throws.ArgumentException);
        }

        [Test]
        public void SplitsCommaDelimitedTraits()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("item typeTraits")).Returns("trait,other trait");
            var traits = generator.GenerateFor("item type", attributes);
            Assert.That(traits, Contains.Item("trait"));
            Assert.That(traits, Contains.Item("other trait"));
            Assert.That(traits.Count(), Is.EqualTo(2));
        }

        [Test]
        public void DoNotAddEmptyTrait()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("item typeTraits")).Returns(String.Empty);
            var traits = generator.GenerateFor("item type", attributes);
            Assert.That(traits, Is.Empty);
        }
    }
}