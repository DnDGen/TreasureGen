using System;
using TreasureGen.Generators.Interfaces.Items.Magical;
using TreasureGen.Generators.Items.Magical;
using TreasureGen.Selectors.Interfaces;
using TreasureGen.Tables.Interfaces;
using Moq;
using NUnit.Framework;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpellGeneratorTests
    {
        private ISpellGenerator generator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private String power;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            generator = new SpellGenerator(mockPercentileSelector.Object);
            power = "power";
        }

        [Test]
        public void ReturnSpellLevel()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.POWERSpellLevels, power);
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("9266");
            var level = generator.GenerateLevel(power);
            Assert.That(level, Is.EqualTo(9266));
        }

        [Test]
        public void ReturnSpellType()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom(TableNameConstants.Percentiles.Set.SpellTypes)).Returns("spell type");
            var type = generator.GenerateType();
            Assert.That(type, Is.EqualTo("spell type"));
        }

        [Test]
        public void ReturnSpell()
        {
            var tableName = String.Format(TableNameConstants.Percentiles.Formattable.LevelXSPELLTYPESpells, 9266, "spell type");
            mockPercentileSelector.Setup(p => p.SelectFrom(tableName)).Returns("this is my spell");
            var spell = generator.Generate("spell type", 9266);
            Assert.That(spell, Is.EqualTo("this is my spell"));
        }
    }
}