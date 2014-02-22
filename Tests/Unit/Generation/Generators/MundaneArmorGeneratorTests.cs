using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class MundaneArmorGeneratorTests
    {
        private IMundaneGearGenerator mundaneArmorGenerator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<ISpecialMaterialGenerator> mockMaterialsProvider;
        private Mock<IAttributesProvider> mockAttributesProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneArmor")).Returns("armor type");
            mockMaterialsProvider = new Mock<ISpecialMaterialGenerator>();
            mockAttributesProvider = new Mock<IAttributesProvider>();

            mundaneArmorGenerator = new MundaneArmorGenerator(mockPercentileResultProvider.Object, mockMaterialsProvider.Object,
                mockAttributesProvider.Object);
        }

        [Test]
        public void MundaneArmorGeneratorReturnsArmor()
        {
            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor, Is.Not.Null);
        }

        [Test]
        public void MundaneArmorGeneratorGetsArmorTypeFromPercentileResultProvider()
        {
            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("armor type"));
        }

        [Test]
        public void MundaneArmorGeneratorSetsMasterworkTraitIfTypeIsStuddedLeatherArmor()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneArmor")).Returns(ArmorConstants.StuddedLeatherArmor);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo(ArmorConstants.StuddedLeatherArmor));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void MundaneArmorGeneratorGetsShieldTypeIfResultIsDarkwood()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneArmor")).Returns(TraitConstants.Darkwood);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("DarkwoodShields")).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Darkwood));
        }

        [Test]
        public void DarkwoodShieldsCannotGetOtherSpecialMaterials()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneArmor")).Returns(TraitConstants.Darkwood);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("DarkwoodShields")).Returns("big shield");

            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Darkwood));
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void MundaneArmorGeneratorGetsShieldTypeIfResultIsMasterworkShield()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneArmor")).Returns(TraitConstants.Masterwork);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MasterworkShields")).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void MundaneArmorGeneratorGetsGearTypesFromProvider()
        {
            var types = new[] { "type 1", "type 2" };
            mockAttributesProvider.Setup(p => p.GetAttributesFor("armor type", "ArmorAttributes")).Returns(types);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.EqualTo(types));
        }

        [Test]
        public void MundaneArmorGeneratorGeneratesSizeFromPercentileResultProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("ArmorSizes")).Returns("small");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("small"));
            Assert.That(armor.Traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void MundaneArmorGeneratorDoesNotGetSpecialMaterialIfArmorDoesNotHaveSpecialMaterial()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(false);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void MundaneArmorGeneratorGetsSpecialMaterialFromMaterialProvider()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("special material"));
        }

        [Test]
        public void DragonhideIsNotMetal()
        {
            var types = new[] { AttributeConstants.Metal };
            mockAttributesProvider.Setup(p => p.GetAttributesFor("armor type", "ArmorTypes")).Returns(types);

            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(types)).Returns(true);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns(TraitConstants.Dragonhide);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.Not.Contains(AttributeConstants.Metal));
        }

        [Test]
        public void DragonhideIsNotWood()
        {
            var types = new[] { AttributeConstants.Wood };
            mockAttributesProvider.Setup(p => p.GetAttributesFor("armor type", "ArmorTypes")).Returns(types);

            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(types)).Returns(true);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns(TraitConstants.Dragonhide);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.Not.Contains(AttributeConstants.Wood));
        }
    }
}