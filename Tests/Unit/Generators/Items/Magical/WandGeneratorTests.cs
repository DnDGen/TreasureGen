using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class WandGeneratorTests
    {
        private IMagicalItemGenerator wandGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IChargesGenerator> mockChargesGenerator;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            wandGenerator = new WandGenerator(mockPercentileSelector.Object, mockChargesGenerator.Object);
        }

        [Test]
        public void GenerateWand()
        {
            var wand = wandGenerator.GenerateAtPower("power");

            Assert.That(wand.Name, Is.StringStarting("Wand of "));
            Assert.That(wand.ItemType, Is.EqualTo(ItemTypeConstants.Wand));
            Assert.That(wand.IsMagical, Is.True);
        }

        [Test]
        public void GetWandSpellFromSelector()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("powerWands")).Returns("wand spell");
            var wand = wandGenerator.GenerateAtPower("power");
            Assert.That(wand.Name, Is.EqualTo("Wand of wand spell"));
        }

        [Test]
        public void GetChargesFromGenerator()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("powerWands")).Returns("wand spell");
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Wand, "wand spell")).Returns(9266);

            var wand = wandGenerator.GenerateAtPower("power");
            Assert.That(wand.Magic.Charges, Is.EqualTo(9266));
        }
    }
}