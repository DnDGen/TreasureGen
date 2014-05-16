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
    public class SpecialMaterialGeneratorTests
    {
        private ISpecialMaterialGenerator specialMaterialsGenerator;
        private Mock<IDice> mockDice;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;

        private List<String> materials;
        private List<String> material1Attributes;
        private List<String> material2Attributes;
        private List<String> traits;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            materials = new List<String>() { "material 1", "material 2" };
            material1Attributes = new List<String>() { "type 1", "type 2" };
            material2Attributes = new List<String>() { "type 3", "type 2" };
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            traits = new List<String>();

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

            mockAttributesSelector.ResetCalls();
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);

            specialMaterialsGenerator.HasSpecialMaterial(ItemTypeConstants.Armor, material1Attributes, traits);
            specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, material1Attributes, traits);

            mockAttributesSelector.Verify(s => s.SelectFrom(It.IsAny<String>(), It.IsAny<String>()), Times.Never);
        }

        [Test]
        public void ArmorHasSpecialMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(ItemTypeConstants.Armor, material1Attributes, traits);
            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void WeaponHasSpecialMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(ItemTypeConstants.Weapon, material1Attributes, traits);
            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void NotWeaponOrArmor_DoesNotHaveSpecialMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial("item type", material1Attributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void GetTrueFromBooleanSelector()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(ItemTypeConstants.Armor, material1Attributes, traits);
            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void GetFalseFromBooleanSelector()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(false);
            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(ItemTypeConstants.Armor, material1Attributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void HasSpecialMaterialReturnsFalseIfGivenAttributesDoNotMatchAnySpecialMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            var newAttributes = new[] { "other type", "type 2" };
            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(ItemTypeConstants.Armor, newAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void DoesNotHaveSpecialMaterialIfAlreadyHasASpecialMaterial()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            traits.Add(materials[0]);

            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(ItemTypeConstants.Armor, material1Attributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void IgnoreNonMaterialTraits()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            traits.Add("not a material trait");

            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(ItemTypeConstants.Armor, material1Attributes, traits);
            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void HaveSpecialMaterialIfDoubleWeaponAndAlreadyHasOneSpecialMaterial()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            traits.Add(materials[0]);
            material1Attributes.Add(AttributeConstants.DoubleWeapon);
            var inputAttributes = material1Attributes.Union(material2Attributes);

            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void DoesNotHaveSpecialMaterialIfDoubleWeaponAndAlreadyHasTwoSpecialMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            traits.Add(materials[0]);
            traits.Add(materials[1]);
            material1Attributes.Add(AttributeConstants.DoubleWeapon);

            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(ItemTypeConstants.Armor, material1Attributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void DoesNotHaveSpecialMaterialIfDoubleWeaponAndAlreadyHasAllAvailableMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            traits.Add(materials[0]);
            material1Attributes.Add(AttributeConstants.DoubleWeapon);

            var hasSpecialMaterial = specialMaterialsGenerator.HasSpecialMaterial(ItemTypeConstants.Armor, material1Attributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void GenerateForItemTypeThrowsExceptionIfNotAllowedItemType()
        {
            Assert.That(() => specialMaterialsGenerator.GenerateFor("item type", material1Attributes, traits), Throws.ArgumentException);
        }

        [Test]
        public void GenerateForAttributesThrowsExceptionIfNoMaterialsMatch()
        {
            var newAttributes = new[] { "other type", "type 2" };
            Assert.That(() => specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, newAttributes, traits), Throws.ArgumentException);
        }

        [Test]
        public void GenerateForTraitsThrowsExceptionIfNoMatchingMaterialsLeft()
        {
            traits.Add(materials[0]);
            Assert.That(() => specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, material1Attributes, traits), Throws.ArgumentException);
        }

        [Test]
        public void GenerateForAttributesGetsMaterialThatMatchesAttributes()
        {
            var material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, material1Attributes, traits);
            Assert.That(material, Is.EqualTo(materials[0]));

            material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, material2Attributes, traits);
            Assert.That(material, Is.EqualTo(materials[1]));
        }

        [Test]
        public void ExtraAttributesDoNotMatter()
        {
            var inputAttributes = material1Attributes.Union(new[] { "other type" });
            var material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(material, Is.EqualTo(materials[0]));
        }

        [Test]
        public void DoNotAllowMaterialsAlreadyListedInTraits()
        {
            traits.Add(materials[0]);
            material1Attributes.Add(AttributeConstants.DoubleWeapon);
            var inputAttributes = material1Attributes.Union(material2Attributes);

            var material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(material, Is.EqualTo(materials[1]));
        }

        [Test]
        public void NonMaterialTraitsDoNotMatter()
        {
            traits.Add("not a material trait");
            var inputAttributes = material1Attributes.Union(material2Attributes);

            var material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(material, Is.EqualTo(materials[0]));
        }

        [Test]
        public void IfMultipleMatchingMaterials_RollsToDetermineWhichOne()
        {
            var inputAttributes = material1Attributes.Union(material2Attributes);
            mockDice.Setup(d => d.Roll("1d2-1")).Returns(0);

            var material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(material, Is.EqualTo(materials[0]));

            mockDice.Setup(d => d.Roll("1d2-1")).Returns(1);

            material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(material, Is.EqualTo(materials[1]));
        }
    }
}