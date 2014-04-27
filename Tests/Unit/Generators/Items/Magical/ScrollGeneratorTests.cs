using System;
using D20Dice;
using EquipmentGen.Common.Items;
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
        private Mock<IDice> mockDice;
        private Mock<ICurseGenerator> mockCurseGenerator;

        [SetUp]
        public void Setup()
        {
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.d3(1)).Returns(1);
            mockCurseGenerator = new Mock<ICurseGenerator>();

            scrollGenerator = new ScrollGenerator(mockDice.Object, mockSpellGenerator.Object, mockCurseGenerator.Object);
        }

        [Test]
        public void ReturnScroll()
        {
            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            Assert.That(scroll, Is.Not.Null);
        }

        [Test]
        public void GetTypeAndLevelFromSpellGenerator()
        {
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel(PowerConstants.Minor)).Returns(9266);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 9266)).Returns("spell");

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            Assert.That(scroll.Name, Is.EqualTo("spell type scroll"));
            Assert.That(scroll.Contents, Contains.Item("spell (9266)"));
        }

        [Test]
        public void MinorScrollsHave1d3Spells()
        {
            mockDice.Setup(d => d.d3(1)).Returns(9266);

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            Assert.That(scroll.Contents.Count, Is.EqualTo(9266));
        }

        [Test]
        public void MediumScrollsHave1d4Spells()
        {
            mockDice.Setup(d => d.d4(1)).Returns(9266);

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Medium);
            Assert.That(scroll.Contents.Count, Is.EqualTo(9266));
        }

        [Test]
        public void MajorScrollsHave1d6Spells()
        {
            mockDice.Setup(d => d.d6(1)).Returns(9266);

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
            mockDice.Setup(d => d.d3(1)).Returns(9266);

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            mockSpellGenerator.Verify(g => g.GenerateType(), Times.Once);
        }

        [Test]
        public void GenerateLevelAndSpellEachTime()
        {
            mockDice.Setup(d => d.d3(1)).Returns(9266);

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            mockSpellGenerator.Verify(g => g.GenerateLevel(PowerConstants.Minor), Times.Exactly(9266));
            mockSpellGenerator.Verify(g => g.Generate(It.IsAny<String>(), It.IsAny<Int32>()), Times.Exactly(9266));
        }

        [Test]
        public void ScrollsAreMagical()
        {
            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            Assert.That(scroll.IsMagical, Is.True);
        }

        [Test]
        public void ScrollsAreOneTimeUseItems()
        {
            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            Assert.That(scroll.Attributes, Contains.Item(AttributeConstants.OneTimeUse));
        }

        [Test]
        public void DoNotGetCurseIfNotCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            Assert.That(scroll.Magic.Curse, Is.Empty);
        }

        [Test]
        public void GetCurseIfCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            Assert.That(scroll.Magic.Curse, Is.EqualTo("cursed"));
        }

        [Test]
        public void GetSpecificCursedItems()
        {
            var cursedItem = new Item();
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("SpecificCursedItem");
            mockCurseGenerator.Setup(g => g.GenerateSpecificCursedItem()).Returns(cursedItem);

            var scroll = scrollGenerator.GenerateAtPower(PowerConstants.Minor);
            Assert.That(scroll, Is.EqualTo(cursedItem));
        }
    }
}