using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class SpellGeneratorTests
    {
        private ISpellGenerator generator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            generator = new SpellGenerator(mockPercentileResultProvider.Object);
        }

        [Test]
        public void ReturnSpellLevel()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerSpellLevel")).Returns("9266");
            var level = generator.GenerateLevel("power");
            Assert.That(level, Is.EqualTo(9266));
        }

        [Test]
        public void ReturnSpellType()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("SpellType")).Returns("spell type");
            var type = generator.GenerateType();
            Assert.That(type, Is.EqualTo("spell type"));
        }

        [Test]
        public void ReturnSpell()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Level9266spell typeSpells")).Returns("this is my spell");
            var spell = generator.Generate("spell type", 9266);
            Assert.That(spell, Is.EqualTo("this is my spell (spell type)"));
        }
    }
}