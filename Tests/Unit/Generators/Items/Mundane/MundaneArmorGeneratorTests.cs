using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneArmorGeneratorTests
    {
        private IMundaneItemGenerator mundaneArmorGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mundaneArmorGenerator = new MundaneArmorGenerator(mockPercentileSelector.Object, mockAttributesSelector.Object);

            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneArmors")).Returns("armor type");
        }

        [Test]
        public void ReturnArmor()
        {
            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor, Is.Not.Null);
        }

        [Test]
        public void GetArmorTypeFromPercentileSelector()
        {
            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("armor type"));
        }

        [Test]
        public void SetMasterworkTraitIfTypeIsStuddedLeatherArmor()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneArmors")).Returns(ArmorConstants.StuddedLeatherArmor);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo(ArmorConstants.StuddedLeatherArmor));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetShieldTypeIfResultIsDarkwood()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneArmors")).Returns(TraitConstants.Darkwood);
            mockPercentileSelector.Setup(p => p.SelectFrom("DarkwoodShields")).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Darkwood));
        }

        [Test]
        public void GetShieldTypeIfResultIsMasterworkShield()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneArmors")).Returns(TraitConstants.Masterwork);
            mockPercentileSelector.Setup(p => p.SelectFrom("MasterworkShields")).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom("ArmorAttributes", "armor type")).Returns(attributes);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateSizeFromPercentileSelector()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("ArmorSizes")).Returns("armor size");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("armor size"));
            Assert.That(armor.Traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetAttributesForDarkwoodShields()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneArmors")).Returns(TraitConstants.Darkwood);
            mockPercentileSelector.Setup(p => p.SelectFrom("DarkwoodShields")).Returns("big shield");
            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesSelector.Setup(s => s.SelectFrom("SpecificShieldsAttributes", "big shield")).Returns(attributes);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }
    }
}