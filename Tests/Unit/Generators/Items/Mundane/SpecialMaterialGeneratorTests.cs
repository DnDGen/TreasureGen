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

        private List<String> materials;
        private List<String> material1Types;
        private List<String> material2Types;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();

            materials = new List<String>() { "material 1", "material 2" };
            material1Types = new List<String>() { "type 1", "type 2" };
            material2Types = new List<String>() { "type 3", "type 2" };

            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockAttributesSelector.Setup(p => p.SelectFrom("SpecialMaterials", "SpecialMaterials")).Returns(materials);
            mockAttributesSelector.Setup(p => p.SelectFrom(materials[0], "SpecialMaterials")).Returns(material1Types);
            mockAttributesSelector.Setup(p => p.SelectFrom(materials[1], "SpecialMaterials")).Returns(material2Types);

            specialMaterialsGenerator = new SpecialMaterialGenerator(mockDice.Object, mockAttributesSelector.Object);
        }

        [Test]
        public void CacheMaterialsAndTypesOnConstruction()
        {
            mockAttributesSelector.Verify(p => p.SelectFrom("SpecialMaterials", "SpecialMaterials"), Times.Once);
            foreach (var material in materials)
                mockAttributesSelector.Verify(p => p.SelectFrom(material, "SpecialMaterials"), Times.Once);
        }

        [Test]
        public void HasSpecialMaterialReturnsFalseIfPercentileLessThan96()
        {
            for (var roll = 0; roll < 96; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(material1Types);
                Assert.That(hasSpecialMaterial, Is.False);
            }
        }

        [Test]
        public void HasSpecialMaterialReturnsTrueIfPercentileGreaterThan95AndTypesMatch()
        {
            var inputTypes = material1Types.Union(new[] { "other type" });

            for (var roll = 96; roll <= 100; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(inputTypes);
                Assert.That(hasSpecialMaterial, Is.True);
            }
        }

        [Test]
        public void HasSpecialMaterialReturnsFalseIfGivenTypesDoNotMatchAnySpecialMaterials()
        {
            var newTypes = new[] { "other type", "type 2" };

            for (var roll = 0; roll < 96; roll++)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(newTypes);
                Assert.That(hasSpecialMaterial, Is.False);
            }
        }

        [Test]
        public void GenerateForTypesThrowsErrorIfNoTypesMatch()
        {
            var newTypes = new[] { "other type", "type 2" };
            Assert.That(() => specialMaterialsGenerator.GenerateFor(newTypes), Throws.ArgumentException);
        }

        [Test]
        public void GenerateForTypesGetsMaterialThatMatchesTypes()
        {
            var material = specialMaterialsGenerator.GenerateFor(material1Types);
            Assert.That(material, Is.EqualTo(materials[0]));

            material = specialMaterialsGenerator.GenerateFor(material2Types);
            Assert.That(material, Is.EqualTo(materials[1]));
        }

        [Test]
        public void ExtraTypesDoNotMatter()
        {
            var inputTypes = material1Types.Union(new[] { "other type" });
            var material = specialMaterialsGenerator.GenerateFor(inputTypes);
            Assert.That(material, Is.EqualTo(materials[0]));
        }

        [Test]
        public void IfMultipleMatchingMaterials_RollsToDetermineWhichOne()
        {
            var inputTypes = material1Types.Union(material2Types);
            mockDice.Setup(d => d.Roll("1d2-1")).Returns(0);

            var material = specialMaterialsGenerator.GenerateFor(inputTypes);
            Assert.That(material, Is.EqualTo(materials[0]));

            mockDice.Setup(d => d.Roll("1d2-1")).Returns(1);

            material = specialMaterialsGenerator.GenerateFor(inputTypes);
            Assert.That(material, Is.EqualTo(materials[1]));
        }
    }
}