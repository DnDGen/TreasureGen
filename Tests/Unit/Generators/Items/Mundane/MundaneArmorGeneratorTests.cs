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
        private Mock<ISpecialMaterialGenerator> mockMaterialsSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockMaterialsSelector = new Mock<ISpecialMaterialGenerator>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mundaneArmorGenerator = new MundaneArmorGenerator(mockPercentileSelector.Object, mockMaterialsSelector.Object, mockAttributesSelector.Object);

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
        public void DarkwoodShieldsCannotGetOtherSpecialMaterials()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneArmors")).Returns(TraitConstants.Darkwood);
            mockPercentileSelector.Setup(p => p.SelectFrom("DarkwoodShields")).Returns("big shield");

            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Darkwood));
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
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
        public void DoNotGetSpecialMaterialIfArmorDoesNotHaveSpecialMaterial()
        {
            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns(false);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void GetSpecialMaterialFromMaterialSelector()
        {
            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("special material"));
        }

        [Test]
        public void DragonhideIsNotMetal()
        {
            var types = new[] { AttributeConstants.Metal };
            mockAttributesSelector.Setup(p => p.SelectFrom("ArmorTypes", "armor type")).Returns(types);

            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(ItemTypeConstants.Armor, types)).Returns(true);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns(TraitConstants.Dragonhide);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.Not.Contains(AttributeConstants.Metal));
        }

        [Test]
        public void DragonhideIsNotWood()
        {
            var types = new[] { AttributeConstants.Wood };
            mockAttributesSelector.Setup(p => p.SelectFrom("ArmorTypes", "armor type")).Returns(types);

            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(ItemTypeConstants.Armor, types)).Returns(true);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<String>(), It.IsAny<IEnumerable<String>>())).Returns(TraitConstants.Dragonhide);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.Not.Contains(AttributeConstants.Wood));
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