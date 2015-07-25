using System;
using D20Dice;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Interfaces.Items.Magical;
using TreasureGen.Generators.Items.Magical;
using Moq;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class ScrollGeneratorTests
    {
        private IMagicalItemGenerator scrollGenerator;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockDice = new Mock<IDice>();
            scrollGenerator = new ScrollGenerator(mockDice.Object, mockSpellGenerator.Object);

            mockDice.Setup(d => d.Roll(1).d3()).Returns(1);
        }

        [Test]
        public void GenerateScroll()
        {
            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            Assert.That(scroll.ItemType, Is.EqualTo(ItemTypeConstants.Scroll));
            Assert.That(scroll.Name, Is.EqualTo(ItemTypeConstants.Scroll));
            Assert.That(scroll.IsMagical, Is.True);
            Assert.That(scroll.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
        }

        [Test]
        public void GetTypeAndLevelFromSpellGenerator()
        {
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Minor)).Returns(9266);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9266)).Returns("spell");

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            Assert.That(scroll.Name, Is.EqualTo(ItemTypeConstants.Scroll));
            Assert.That(scroll.Traits, Contains.Item("spell type"));
            Assert.That(scroll.Contents, Contains.Item("spell (9266)"));
        }

        [Test]
        public void MinorScrollsHave1d3Spells()
        {
            mockDice.Setup(d => d.Roll(1).d3()).Returns(9266);

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            Assert.That(scroll.Contents.Count, Is.EqualTo(9266));
        }

        [Test]
        public void MediumScrollsHave1d4Spells()
        {
            mockDice.Setup(d => d.Roll(1).d4()).Returns(9266);

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Medium);
            Assert.That(scroll.Contents.Count, Is.EqualTo(9266));
        }

        [Test]
        public void MajorScrollsHave1d6Spells()
        {
            mockDice.Setup(d => d.Roll(1).d6()).Returns(9266);

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Major);
            Assert.That(scroll.Contents.Count, Is.EqualTo(9266));
        }

        [Test]
        public void UnknownPowerThrowsError()
        {
            Assert.That(() => scrollGenerator.GenerateAtPower("power"), Throws.ArgumentException);
        }

        [Test]
        public void GenerateSpellTypeOnce()
        {
            mockDice.Setup(d => d.Roll(1).d3()).Returns(9266);

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            mockSpellGenerator.Verify(g => g.GenerateType(), Times.Once);
        }

        [Test]
        public void GenerateLevelAndSpellEachTime()
        {
            mockDice.Setup(d => d.Roll(1).d3()).Returns(9266);

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            mockSpellGenerator.Verify(g => g.GenerateLevel(PowerConstants.Minor), Times.Exactly(9266));
            mockSpellGenerator.Verify(g => g.Generate(It.IsAny<String>(), It.IsAny<Int32>()), Times.Exactly(9266));
        }
    }
}