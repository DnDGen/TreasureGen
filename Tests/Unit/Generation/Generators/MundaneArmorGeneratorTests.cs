using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Core.Data.Items;
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
        private Mock<IMaterialsProvider> mockMaterialsProvider;
        private Mock<IGearTypesProvider> mockGearTypesProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneArmor")).Returns("armor type");
            mockMaterialsProvider = new Mock<IMaterialsProvider>();
            mockGearTypesProvider = new Mock<IGearTypesProvider>();

            mundaneArmorGenerator = new MundaneArmorGenerator(mockPercentileResultProvider.Object, mockMaterialsProvider.Object,
                mockGearTypesProvider.Object);
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
        public void MundaneArmorGeneratorSetsMasterworkTraitIfTypeIsMasterwork()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneArmor")).Returns("Masterwork armor");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("armor"));
            Assert.That(armor.Traits, Contains.Item(ItemsConstants.Gear.Traits.Masterwork));
        }

        [Test]
        public void MundaneArmorGeneratorGetsShieldTypeIfResultIsDarkwood()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneArmor")).Returns("DarkwoodShields");
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("DarkwoodShields")).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(ItemsConstants.Gear.Traits.Darkwood));
        }

        [Test]
        public void MundaneArmorGeneratorGetsShieldTypeIfResultIsMasterworkShield()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneArmor")).Returns("MasterworkShields");
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MasterworkShields")).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(ItemsConstants.Gear.Traits.Masterwork));
        }

        [Test]
        public void MundaneArmorGeneratorGetsGearTypesFromProvider()
        {
            var types = new[] { "type 1", "type 2" };
            mockGearTypesProvider.Setup(p => p.GetGearTypesFor("armor type")).Returns(types);

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Types, Is.EqualTo(types));
        }

        [Test]
        public void MundaneArmorGeneratorGeneratesSizeFromPercentileResultProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("ArmorSizes")).Returns("small");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("small"));
            Assert.That(armor.Traits.Count(), Is.EqualTo(1));
        }

        [Test]
        public void MundaneArmorGeneratorDoesNotGetSpecialMaterialIfArmorDoesNotHaveSpecialMaterial()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial()).Returns(false);
            mockMaterialsProvider.Setup(p => p.GetSpecialMaterialFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void MundaneArmorGeneratorGetsSpecialMaterialFromMaterialProvider()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial()).Returns(true);
            mockMaterialsProvider.Setup(p => p.GetSpecialMaterialFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("special material"));
        }
    }
}