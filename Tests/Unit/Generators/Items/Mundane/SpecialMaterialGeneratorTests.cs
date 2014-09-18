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

        private List<String> mithralAttributes;
        private List<String> adamantineAttributes;
        private List<String> otherMaterialAttributes;
        private List<String> traits;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mithralAttributes = new List<String>() { "type 1", "type 2" };
            adamantineAttributes = new List<String>() { "type 3", "type 2" };
            otherMaterialAttributes = new List<String>() { "type 3", "type 2", "other attribute" };
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            traits = new List<String>();

            mockAttributesSelector.Setup(s => s.SelectFrom("SpecialMaterials", It.IsAny<String>())).Returns(otherMaterialAttributes);
            mockAttributesSelector.Setup(p => p.SelectFrom("SpecialMaterials", TraitConstants.Mithral)).Returns(mithralAttributes);
            mockAttributesSelector.Setup(p => p.SelectFrom("SpecialMaterials", TraitConstants.Adamantine)).Returns(adamantineAttributes);

            specialMaterialsGenerator = new SpecialMaterialGenerator(mockDice.Object, mockAttributesSelector.Object, mockBooleanPercentileSelector.Object);
        }

        [Test]
        public void CacheMaterialsAndAttributeRequirementsOnConstruction()
        {
            foreach (var material in TraitConstants.GetSpecialMaterials())
                mockAttributesSelector.Verify(p => p.SelectFrom("SpecialMaterials", material), Times.Once);

            mockAttributesSelector.ResetCalls();
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);

            specialMaterialsGenerator.CanHaveSpecialMaterial(ItemTypeConstants.Armor, mithralAttributes, traits);
            specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, mithralAttributes, traits);

            mockAttributesSelector.Verify(s => s.SelectFrom(It.IsAny<String>(), It.IsAny<String>()), Times.Never);
        }

        [Test]
        public void ArmorHasSpecialMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            var hasSpecialMaterial = specialMaterialsGenerator.CanHaveSpecialMaterial(ItemTypeConstants.Armor, mithralAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void WeaponHasSpecialMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            var hasSpecialMaterial = specialMaterialsGenerator.CanHaveSpecialMaterial(ItemTypeConstants.Weapon, mithralAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void NotWeaponOrArmor_DoesNotHaveSpecialMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            var hasSpecialMaterial = specialMaterialsGenerator.CanHaveSpecialMaterial("item type", mithralAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void GetTrueFromBooleanSelector()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            var hasSpecialMaterial = specialMaterialsGenerator.CanHaveSpecialMaterial(ItemTypeConstants.Armor, mithralAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void GetFalseFromBooleanSelector()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(false);
            var hasSpecialMaterial = specialMaterialsGenerator.CanHaveSpecialMaterial(ItemTypeConstants.Armor, mithralAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void HasSpecialMaterialReturnsFalseIfGivenAttributesDoNotMatchAnySpecialMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            var newAttributes = new[] { "other type", "type 2" };
            var hasSpecialMaterial = specialMaterialsGenerator.CanHaveSpecialMaterial(ItemTypeConstants.Armor, newAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void DoesNotHaveSpecialMaterialIfAlreadyHasASpecialMaterial()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            traits.Add(TraitConstants.ColdIron);

            var hasSpecialMaterial = specialMaterialsGenerator.CanHaveSpecialMaterial(ItemTypeConstants.Armor, mithralAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void IgnoreNonMaterialTraits()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            traits.Add("not a material trait");

            var hasSpecialMaterial = specialMaterialsGenerator.CanHaveSpecialMaterial(ItemTypeConstants.Armor, mithralAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void HaveSpecialMaterialIfDoubleWeaponAndAlreadyHasOneSpecialMaterial()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            traits.Add(TraitConstants.ColdIron);
            mithralAttributes.Add(AttributeConstants.DoubleWeapon);
            var inputAttributes = mithralAttributes.Union(adamantineAttributes);

            var hasSpecialMaterial = specialMaterialsGenerator.CanHaveSpecialMaterial(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.True);
        }

        [Test]
        public void DoesNotHaveSpecialMaterialIfDoubleWeaponAndAlreadyHasTwoSpecialMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            traits.Add(TraitConstants.ColdIron);
            traits.Add(TraitConstants.Darkwood);
            mithralAttributes.Add(AttributeConstants.DoubleWeapon);

            var hasSpecialMaterial = specialMaterialsGenerator.CanHaveSpecialMaterial(ItemTypeConstants.Armor, mithralAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void DoesNotHaveSpecialMaterialIfDoubleWeaponAndAlreadyHasAllAvailableMaterials()
        {
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("HasSpecialMaterial")).Returns(true);
            traits.Add(TraitConstants.Mithral);
            mithralAttributes.Add(AttributeConstants.DoubleWeapon);

            var hasSpecialMaterial = specialMaterialsGenerator.CanHaveSpecialMaterial(ItemTypeConstants.Armor, mithralAttributes, traits);
            Assert.That(hasSpecialMaterial, Is.False);
        }

        [Test]
        public void GenerateForItemTypeThrowsExceptionIfNotAllowedItemType()
        {
            Assert.That(() => specialMaterialsGenerator.GenerateFor("item type", mithralAttributes, traits), Throws.ArgumentException);
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
            traits.Add(TraitConstants.Mithral);
            Assert.That(() => specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, mithralAttributes, traits), Throws.ArgumentException);
        }

        [Test]
        public void GenerateForAttributesGetsMaterialThatMatchesAttributes()
        {
            var material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, mithralAttributes, traits);
            Assert.That(material, Is.EqualTo(TraitConstants.Mithral));

            material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, adamantineAttributes, traits);
            Assert.That(material, Is.EqualTo(TraitConstants.Adamantine));
        }

        [Test]
        public void ExtraAttributesDoNotMatter()
        {
            var inputAttributes = mithralAttributes.Union(new[] { "other type" });
            var material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(material, Is.EqualTo(TraitConstants.Mithral));
        }

        [Test]
        public void DoNotAllowMaterialsAlreadyListedInTraits()
        {
            traits.Add(TraitConstants.Mithral);
            mithralAttributes.Add(AttributeConstants.DoubleWeapon);
            var inputAttributes = mithralAttributes.Union(adamantineAttributes);

            var material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(material, Is.EqualTo(TraitConstants.Adamantine));
        }

        [Test]
        public void NonMaterialTraitsDoNotMatter()
        {
            mockDice.Setup(d => d.Roll(It.IsAny<Int32>()).d(It.IsAny<Int32>())).Returns(1);
            traits.Add("not a material trait");
            var inputAttributes = mithralAttributes.Union(adamantineAttributes);

            var material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(material, Is.EqualTo(TraitConstants.Adamantine));
        }

        [Test]
        public void IfMultipleMatchingMaterials_RollsToDetermineWhichOne()
        {
            var inputAttributes = mithralAttributes.Union(adamantineAttributes);
            mockDice.Setup(d => d.Roll(1).d(2)).Returns(1);

            var material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(material, Is.EqualTo(TraitConstants.Adamantine));

            mockDice.Setup(d => d.Roll(1).d(2)).Returns(2);

            material = specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Armor, inputAttributes, traits);
            Assert.That(material, Is.EqualTo(TraitConstants.Mithral));
        }

        [Test]
        public void IfDoubleWeaponAndHasTwoMaterials_ThrowException()
        {
            traits.Add(TraitConstants.ColdIron);
            traits.Add(TraitConstants.Darkwood);
            mithralAttributes.Add(AttributeConstants.DoubleWeapon);
            var inputAttributes = mithralAttributes.Union(adamantineAttributes).Union(otherMaterialAttributes);

            Assert.That(() => specialMaterialsGenerator.GenerateFor(ItemTypeConstants.Weapon, inputAttributes, traits), Throws.ArgumentException.With.Message.EqualTo("Cold iron,Darkwood"));
        }
    }
}