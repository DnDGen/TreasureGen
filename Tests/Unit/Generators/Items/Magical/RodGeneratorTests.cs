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
        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            result = new TypeAndAmountPercentileResult();
            rodGenerator = new RodGenerator(mockTypeAndAmountPercentileSelector.Object);

            result.Amount = "0";
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom("powerRods")).Returns(result);
        }

        [Test]
        public void GenerateRod()
        {
            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.Name, Is.StringStarting("Rod of "));
            Assert.That(rod.ItemType, Is.EqualTo(ItemTypeConstants.Rod));
            Assert.That(rod.IsMagical, Is.True);
        }

        [Test]
        public void MinorPowerThrowsError()
        {
            Assert.That(() => rodGenerator.GenerateAtPower(PowerConstants.Minor), Throws.ArgumentException.With.Message.EqualTo("Cannot generate minor rods"));
        }

        [Test]
        public void GetAbilityFromSelector()
        {
            result.Type = "rod ability";
            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.Name, Is.EqualTo("Rod of rod ability"));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            result.Type = "rod ability";
            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesSelector.Setup(s => s.SelectFrom("RodAttributes", result.Type)).Returns(attributes);

            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            result.Type = "rod ability";
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(p => p.SelectFrom("RingAttributes", result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Rod, result.Type)).Returns(9266);

            var rod = rodGenerator.GenerateAtPower("power");
            Assert.That(rod.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            result.Type = "rod ability";
            var attributes = new[] { "new attribute" };
            mockAttributesSelector.Setup(p => p.SelectFrom("RingAttributes", result.Type)).Returns(attributes);
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
    }
}