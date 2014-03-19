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
        private Mock<IPercentileSelector> mockPercentileResultProvider;
        private Mock<ISpecialMaterialGenerator> mockMaterialsProvider;
        private Mock<IAttributesSelector> mockAttributesProvider;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(9266).Returns(42);

            mockPercentileResultProvider = new Mock<IPercentileSelector>();
            mockPercentileResultProvider.Setup(p => p.SelectFrom("MundaneArmors", 9266)).Returns("armor type");
            mockMaterialsProvider = new Mock<ISpecialMaterialGenerator>();
            mockAttributesProvider = new Mock<IAttributesSelector>();

            mundaneArmorGenerator = new MundaneArmorGenerator(mockPercentileResultProvider.Object, mockMaterialsProvider.Object,
                mockAttributesProvider.Object, mockDice.Object);
        }

        [Test]
        public void ReturnArmor()
        {
            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor, Is.Not.Null);
        }

        [Test]
        public void GetArmorTypeFromPercentileResultProvider()
        {
            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("armor type"));
        }

        [Test]
        public void SetMasterworkTraitIfTypeIsStuddedLeatherArmor()
        {
            mockPercentileResultProvider.Setup(p => p.SelectFrom("MundaneArmors", 9266)).Returns(ArmorConstants.StuddedLeatherArmor);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo(ArmorConstants.StuddedLeatherArmor));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetShieldTypeIfResultIsDarkwood()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66).Returns(42);
            mockPercentileResultProvider.Setup(p => p.SelectFrom("MundaneArmors", 92)).Returns(TraitConstants.Darkwood);
            mockPercentileResultProvider.Setup(p => p.SelectFrom("DarkwoodShields", 66)).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Darkwood));
        }

        [Test]
        public void DarkwoodShieldsCannotGetOtherSpecialMaterials()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66).Returns(42);
            mockPercentileResultProvider.Setup(p => p.SelectFrom("MundaneArmors", 92)).Returns(TraitConstants.Darkwood);
            mockPercentileResultProvider.Setup(p => p.SelectFrom("DarkwoodShields", 66)).Returns("big shield");

            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Darkwood));
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void GetShieldTypeIfResultIsMasterworkShield()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66).Returns(42);
            mockPercentileResultProvider.Setup(p => p.SelectFrom("MundaneArmors", 92)).Returns(TraitConstants.Masterwork);
            mockPercentileResultProvider.Setup(p => p.SelectFrom("MasterworkShields", 66)).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetAttributesFromProvider()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesProvider.Setup(p => p.SelectFrom("armor type", "ArmorAttributes")).Returns(attributes);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GenerateSizeFromPercentileResultProvider()
        {
            mockPercentileResultProvider.Setup(p => p.SelectFrom("ArmorSizes", 42)).Returns("small");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("small"));
            Assert.That(armor.Traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void DoNotGetSpecialMaterialIfArmorDoesNotHaveSpecialMaterial()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(false);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void GetSpecialMaterialFromMaterialProvider()
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
            mockAttributesProvider.Setup(p => p.SelectFrom("armor type", "ArmorTypes")).Returns(types);

            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(types)).Returns(true);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns(TraitConstants.Dragonhide);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.Not.Contains(AttributeConstants.Metal));
        }

        [Test]
        public void DragonhideIsNotWood()
        {
            var types = new[] { AttributeConstants.Wood };
            mockAttributesProvider.Setup(p => p.SelectFrom("armor type", "ArmorTypes")).Returns(types);

            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(types)).Returns(true);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns(TraitConstants.Dragonhide);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Attributes, Is.Not.Contains(AttributeConstants.Wood));
        }
    }
}