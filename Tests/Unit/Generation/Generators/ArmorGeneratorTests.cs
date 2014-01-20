using System;
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
    public class ArmorGeneratorTests
    {
        private IGearGenerator armorGenerator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<ITypeAndAmountPercentileResultProvider> mockTypeAndAmountPercentileResultProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult(It.IsAny<String>())).Returns("armor type");

            mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();

            armorGenerator = new ArmorGenerator(mockPercentileResultProvider.Object, mockTypeAndAmountPercentileResultProvider.Object);
        }

        [Test]
        public void ArmorGeneratorReturnsArmor()
        {
            var armor = armorGenerator.GenerateAtPower("power");
            Assert.That(armor, Is.Not.Null);
        }

        [Test]
        public void ArmorGeneratorGetsArmorTypeFromPercentileResultProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerArmor")).Returns("armor type");
            var armor = armorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("armor type"));
        }

        [Test]
        public void ArmorGeneratorSetsMasterworkTraitIfTypeIsMasterwork()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerArmor")).Returns("masterwork armor");
            var armor = armorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("armor"));
            Assert.That(armor.Traits, Contains.Item(ItemsConstants.Gear.Traits.Masterwork));
        }

        [Test]
        public void ArmorGeneratorGetsShieldTypeIfResultIsDarkwood()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerArmor")).Returns("Darkwood");
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("DarkwoodShields")).Returns("big shield");

            var armor = armorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(ItemsConstants.Gear.Traits.Darkwood));
        }

        [Test]
        public void ArmorGeneratorGetsShieldTypeIfResultIsMasterworkShield()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("powerArmor")).Returns("Masterwork shield");
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MasterworkShields")).Returns("big shield");

            var armor = armorGenerator.GenerateAtPower("power");
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(ItemsConstants.Gear.Traits.Masterwork));
        }

        [Test]
        public void ArmorGeneratorGeneratesSizeFromPercentileResultProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("ArmorSizes")).Returns("small");

            var armor = armorGenerator.GenerateAtPower("power");
            Assert.That(armor.Traits, Contains.Item("small"));
            Assert.That(armor.Traits.Count(), Is.EqualTo(1));
        }
    }
}