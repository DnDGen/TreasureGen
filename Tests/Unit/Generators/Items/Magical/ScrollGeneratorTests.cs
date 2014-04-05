using System;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class ScrollGeneratorTests
    {
        private IMagicalItemGenerator scrollGenerator;
        private Mock<ISpellGenerator> mockSpellGenerator;

        [SetUp]
        public void Setup()
        {
            mockSpellGenerator = new Mock<ISpellGenerator>();
            scrollGenerator = new ScrollGenerator();
        }

        [Test]
        public void ReturnScroll()
        {
            var scroll = scrollGenerator.GenerateAtPower("power");
            Assert.That(scroll, Is.Not.Null);
        }

        [Test]
        public void GetTypeFromSpellGenerator()
        {
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");

            scrollGenerator.GenerateAtPower("power");
            mockSpellGenerator.Verify(g => g.Generate("spell type", It.IsAny<Int32>()), Times.Once);
        }
    }
}