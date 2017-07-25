using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Domain.Generators.Items.Magical;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpellGeneratorTests
    {
        private ISpellGenerator generator;
        private Mock<ITreasurePercentileSelector> mockPercentileSelector;
        private string power;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<ITreasurePercentileSelector>();
            generator = new SpellGenerator(mockPercentileSelector.Object);
            power = "power";
        }

        [Test]
        public void ReturnSpellLevel()
        {
            var tableName = string.Format(TableNameConstants.Percentiles.Formattable.POWERSpellLevels, power);
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