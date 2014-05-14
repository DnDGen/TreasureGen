using D20Dice;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpellGeneratorTests
    {
        private ISpellGenerator generator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(42);
            generator = new SpellGenerator(mockPercentileSelector.Object, mockDice.Object);
        }

        [Test]
        public void ReturnSpellLevel()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerSpellLevels")).Returns("9266");
            var level = generator.GenerateLevel("power");
            Assert.That(level, Is.EqualTo(9266));
        }

        [Test]
        public void ReturnSpellType()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("SpellTypes")).Returns("spell type");
            var type = generator.GenerateType();
            Assert.That(type, Is.EqualTo("spell type"));
        }

        [Test]
        public void ReturnSpell()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("Level9266spell typeSpells")).Returns("this is my spell");
            var spell = generator.Generate("spell type", 9266);
            Assert.That(spell, Is.EqualTo("this is my spell"));
        }
    }
}