using D20Dice;
using EquipmentGen.Generators;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpellGeneratorTests
    {
        private ISpellGenerator generator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(42);
            generator = new SpellGenerator(mockPercentileResultProvider.Object, mockDice.Object);
        }

        [Test]
        public void ReturnSpellLevel()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerSpellLevels", 42)).Returns("9266");
            var level = generator.GenerateLevel("power");
            Assert.That(level, Is.EqualTo(9266));
        }

        [Test]
        public void ReturnSpellType()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("SpellTypes", 42)).Returns("spell type");
            var type = generator.GenerateType();
            Assert.That(type, Is.EqualTo("spell type"));
        }

        [Test]
        public void ReturnSpell()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Level9266spell typeSpells", 42)).Returns("this is my spell");
            var spell = generator.Generate("spell type", 9266);
            Assert.That(spell, Is.EqualTo("this is my spell (spell type)"));
        }
    }
}