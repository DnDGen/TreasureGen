using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
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
        private IMundaneGearGenerator mundaneArmorGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ISpecialMaterialGenerator> mockMaterialsSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(9266).Returns(42);

            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneArmors", 9266)).Returns("armor type");
            mockMaterialsSelector = new Mock<ISpecialMaterialGenerator>();
            mockAttributesSelector = new Mock<IAttributesSelector>();

            mundaneArmorGenerator = new MundaneArmorGenerator(mockPercentileSelector.Object, mockMaterialsSelector.Object,
                mockAttributesSelector.Object, mockDice.Object);
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
            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneArmors", 9266)).Returns(ArmorConstants.StuddedLeatherArmor);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo(ArmorConstants.StuddedLeatherArmor));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetShieldTypeIfResultIsDarkwood()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66).Returns(42);
            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneArmors", 92)).Returns(TraitConstants.Darkwood);
            mockPercentileSelector.Setup(p => p.SelectFrom("DarkwoodShields", 66)).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Darkwood));
        }

        [Test]
        public void DarkwoodShieldsCannotGetOtherSpecialMaterials()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66).Returns(42);
            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneArmors", 92)).Returns(TraitConstants.Darkwood);
            mockPercentileSelector.Setup(p => p.SelectFrom("DarkwoodShields", 66)).Returns("big shield");

            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Darkwood));
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void GetShieldTypeIfResultIsMasterworkShield()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66).Returns(42);
            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneArmors", 92)).Returns(TraitConstants.Masterwork);
            mockPercentileSelector.Setup(p => p.SelectFrom("MasterworkShields", 66)).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom("ArmorAttributes", "armor type")).Returns(attributes);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateSizeFromPercentileSelector()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("ArmorSizes", 42)).Returns("small");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("small"));
            Assert.That(armor.Traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void DoNotGetSpecialMaterialIfArmorDoesNotHaveSpecialMaterial()
        {
            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(false);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void GetSpecialMaterialFromMaterialSelector()
        {
            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("special material"));
        }

        [Test]
        public void DragonhideIsNotMetal()
        {
            var types = new[] { AttributeConstants.Metal };
            mockAttributesSelector.Setup(p => p.SelectFrom("ArmorTypes", "armor type")).Returns(types);

            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(types)).Returns(true);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns(TraitConstants.Dragonhide);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.Not.Contains(AttributeConstants.Metal));
        }

        [Test]
        public void DragonhideIsNotWood()
        {
            var types = new[] { AttributeConstants.Wood };
            mockAttributesSelector.Setup(p => p.SelectFrom("ArmorTypes", "armor type")).Returns(types);

            mockMaterialsSelector.Setup(p => p.HasSpecialMaterial(types)).Returns(true);
            mockMaterialsSelector.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns(TraitConstants.Dragonhide);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.Not.Contains(AttributeConstants.Wood));
        }
    }
}