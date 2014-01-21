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

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneArmor")).Returns("armor type");

            mundaneArmorGenerator = new MundaneArmorGenerator(mockPercentileResultProvider.Object);
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
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneArmor")).Returns("Darkwood");
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("DarkwoodShields")).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(ItemsConstants.Gear.Traits.Darkwood));
        }

        [Test]
        public void MundaneArmorGeneratorGetsShieldTypeIfResultIsMasterworkShield()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneArmor")).Returns("Masterwork shield");
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MasterworkShields")).Returns("big shield");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Name, Is.EqualTo("big shield"));
            Assert.That(armor.Traits, Contains.Item(ItemsConstants.Gear.Traits.Masterwork));
        }

        [Test]
        public void MundaneArmorGeneratorGeneratesSizeFromPercentileResultProvider()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("ArmorSizes")).Returns("small");

            var armor = mundaneArmorGenerator.Generate();
            Assert.That(armor.Traits, Contains.Item("small"));
            Assert.That(armor.Traits.Count(), Is.EqualTo(1));
        }
    }
}