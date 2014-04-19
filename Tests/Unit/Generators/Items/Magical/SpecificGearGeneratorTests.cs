using System;
using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpecificGearGeneratorTests
    {
        private ISpecificGearGenerator generator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IDice> mockDice;
        private Mock<IAttributesSelector> mockAttributesSelector;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<IDice>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAttributesSelector = new Mock<IAttributesSelector>();

            generator = new SpecificGearGenerator();
        }

        [Test]
        public void ReturnGear()
        {
            var gear = generator.GenerateFrom("power", "specific gear type");
            Assert.That(gear, Is.Not.Null);
        }

        [Test]
        public void GetGearNameFromTypeTable()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileSelector.Setup(s => s.SelectFrom("powerspecific gear types", 9266)).Returns("specific gear");

            var gear = generator.GenerateFrom("power", "specific gear type");
            Assert.That(gear.Name, Is.EqualTo("specific gear"));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<String>(), It.IsAny<Int32>())).Returns("specific gear");
            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesSelector.Setup(s => s.SelectFrom("specific gear typeAttributes", "specific gear")).Returns(attributes);

            var gear = generator.GenerateFrom("power", "specific gear type");
            Assert.That(gear.Attributes, Is.EqualTo(attributes));
        }
    }
}