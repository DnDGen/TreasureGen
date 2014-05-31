using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class RodGeneratorTests
    {
        private IMagicalItemGenerator rodGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            result = new TypeAndAmountPercentileResult();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            rodGenerator = new RodGenerator(mockTypeAndAmountPercentileSelector.Object, mockAttributesSelector.Object,
                mockChargesGenerator.Object, mockBooleanPercentileSelector.Object);

            result.Amount = "0";
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom("powerRods")).Returns(result);
        }

        [Test]
        public void GenerateRod()
        {
            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.IsMagical, Is.True);
        }

        [Test]
        public void MinorPowerThrowsError()
        {
            Assert.That(() => rodGenerator.GenerateAtPower(PowerConstants.Minor), Throws.ArgumentException.With.Message.EqualTo("Cannot generate minor rods"));
        }

        [Test]
        public void GetNameFromSelector()
        {
            result.Type = "rod of ability";
            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.Name, Is.EqualTo(result.Type));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            result.Type = "rod of ability";
            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesSelector.Setup(s => s.SelectFrom("RodAttributes", result.Type)).Returns(attributes);

            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            result.Type = "rod of ability";
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(p => p.SelectFrom("RodAttributes", result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type)).Returns(9266);

            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            result.Type = "rod ability";
            var attributes = new[] { "new attribute" };
            mockAttributesSelector.Setup(p => p.SelectFrom("RodAttributes", result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type)).Returns(9266);

            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void GetBonus()
        {
            result.Amount = "9266";
            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.Magic.Bonus, Is.EqualTo(9266));
        }

        [Test]
        public void RodOfAbsorptionContainsLevelsIfSelectorSaysSo()
        {
            result.Type = "Rod of absorption";
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(p => p.SelectFrom("RodAttributes", result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type)).Returns(42);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type + " (max)")).Returns(50);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("RodOfAbsorptionContainsSpellLevels")).Returns(true);

            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.Magic.Charges, Is.EqualTo(42));
            Assert.That(rod.Contents, Contains.Item("4 spell levels"));
            Assert.That(rod.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void RodOfAbsorptionDoesNotContainLevelsIfSelectorSaysSo()
        {
            result.Type = "Rod of absorption";
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(p => p.SelectFrom("RodAttributes", result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type)).Returns(42);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type + " (max)")).Returns(50);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom("RodOfAbsorptionContainsSpellLevels")).Returns(false);

            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.Magic.Charges, Is.EqualTo(42));
            Assert.That(rod.Contents, Is.Empty);
        }
    }
}