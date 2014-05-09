using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class SpecialMaterialGeneratorTests
    {
        private ISpecialMaterialGenerator specialMaterialsGenerator;
        private Mock<IDice> mockDice;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;

        private List<String> materials;
        private List<String> material1Attributes;
        private List<String> material2Attributes;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            materials = new List<String>() { "material 1", "material 2" };
            material1Attributes = new List<String>() { "type 1", "type 2" };
            material2Attributes = new List<String>() { "type 3", "type 2" };
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();

            mockAttributesSelector.Setup(p => p.SelectFrom("SpecialMaterials", "SpecialMaterials")).Returns(materials);
            mockAttributesSelector.Setup(p => p.SelectFrom("SpecialMaterials", materials[0])).Returns(material1Attributes);
            mockAttributesSelector.Setup(p => p.SelectFrom("SpecialMaterials", materials[1])).Returns(material2Attributes);

            specialMaterialsGenerator = new SpecialMaterialGenerator(mockDice.Object, mockAttributesSelector.Object, mockBooleanPercentileSelector.Object);
        }

        [Test]
        public void CacheMaterialsAndAttributeRequirementsOnConstruction()
        {
            mockAttributesSelector.Verify(p => p.SelectFrom("SpecialMaterials", "SpecialMaterials"), Times.Once);
            foreach (var material in materials)
                mockAttributesSelector.Verify(p => p.SelectFrom("SpecialMaterials", material), Times.Once);
        }

        [Test]
        public void GetTrueFromBooleanSelector()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial", It.IsAny<Int32>())).Returns(true);
            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial("item type", material1Attributes);
            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void GetFalseFromBooleanSelector()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial", It.IsAny<Int32>())).Returns(false);
            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial("item type", material1Attributes);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void HasSpecialMaterialReturnsFalseIfGivenAttributesDoNotMatchAnySpecialMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial", It.IsAny<Int32>())).Returns(true);
            var newAttributes = new[] { "other type", "type 2" };
            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial("item type", newAttributes);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void GenerateForAttributesThrowsErrorIfNoTypesMatch()
        {
            var newAttributes = new[] { "other type", "type 2" };
            Assert.That(() => specialMaterialsGenerator.GenerateFor("item type", newAttributes), Throws.ArgumentException);
        }

        [Test]
        public void GenerateForTypesGetsMaterialThatMatchesTypes()
        {
            var material = specialMaterialsGenerator.GenerateFor("item type", material1Attributes);
            Assert.That(material, Is.EqualTo(materials[0]));

            material = specialMaterialsGenerator.GenerateFor("item type", material2Attributes);
            Assert.That(material, Is.EqualTo(materials[1]));
        }

        [Test]
        public void ExtraTypesDoNotMatter()
        {
            var inputTypes = material1Attributes.Union(new[] { "other type" });
            var material = specialMaterialsGenerator.GenerateFor("item type", inputTypes);
            Assert.That(material, Is.EqualTo(materials[0]));
        }

        [Test]
        public void IfMultipleMatchingMaterials_RollsToDetermineWhichOne()
        {
            var inputTypes = material1Attributes.Union(material2Attributes);
            mockDice.Setup(d => d.Roll("1d2-1")).Returns(0);

            var material = specialMaterialsGenerator.GenerateFor("item type", inputTypes);
            Assert.That(material, Is.EqualTo(materials[0]));

            mockDice.Setup(d => d.Roll("1d2-1")).Returns(1);

            material = specialMaterialsGenerator.GenerateFor("item type", inputTypes);
            Assert.That(material, Is.EqualTo(materials[1]));
        }
    }
}