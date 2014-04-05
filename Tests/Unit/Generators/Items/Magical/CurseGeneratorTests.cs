using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class CurseGeneratorTests
    {
        private ICurseGenerator curseGenerator;
        private Dictionary<Magic, Object> magic;
        private Mock<IDice> mockDice;
        private Mock<IPercentileSelector> mockPercentileSelector;

        [SetUp]
        public void Setup()
        {
            magic = new Dictionary<Magic, Object>();
            magic[Magic.IsMagical] = true;
            mockDice = new Mock<IDice>();
            mockPercentileSelector = new Mock<IPercentileSelector>();

            curseGenerator = new CurseGenerator(mockDice.Object);
        }

        [Test]
        public void NotCursedIfNoMagic()
        {
            magic.Clear();
            var cursed = curseGenerator.HasCurse(magic);
            Assert.That(cursed, Is.False);
        }

        [Test]
        public void NotCursedIfRollAbove5()
        {
            for (var roll = 100; roll > 5; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var cursed = curseGenerator.HasCurse(magic);
                Assert.That(cursed, Is.False);
            }
        }

        [Test]
        public void CursedIfRollBelow5()
        {
            for (var roll = 5; roll > 0; roll--)
            {
                mockDice.Setup(d => d.Percentile(1)).Returns(roll);
                var cursed = curseGenerator.HasCurse(magic);
                Assert.That(cursed, Is.True);
            }
        }

        [Test]
        public void GenerateCurseGetsFromPercentileSelector()
        {
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);
            mockPercentileSelector.Setup(s => s.SelectFrom("Curses", 9266)).Returns("curse");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("curse"));
        }

        [Test]
        public void IfIntermittentFunctioning_1OnD3IsUnreliable()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("Curses", It.IsAny<Int32>())).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.d3(1)).Returns(1);

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Unreliable)"));
        }

        [Test]
        public void IfIntermittentFunctioning_2OnD3IsDependent()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("Curses", It.IsAny<Int32>())).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.d3(1)).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom("CursedDependentSituations", It.IsAny<Int32>())).Returns("situation");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Dependent: situation)"));
        }

        [Test]
        public void IfIntermittentFunctioning_GetDesignatedFoe()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("Curses", It.IsAny<Int32>())).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.d3(1)).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom("CursedDependentSituations", It.IsAny<Int32>())).Returns("situation with DesignatedFoe");
            mockPercentileSelector.Setup(s => s.SelectFrom("DesignatedFoes", It.IsAny<Int32>())).Returns("creature type");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Dependent: situation with creature type)"));
        }

        [Test]
        public void IfIntermittentFunctioning_GetAlignment()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("Curses", It.IsAny<Int32>())).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.d3(1)).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom("CursedDependentSituations", It.IsAny<Int32>())).Returns("situation with Alignment");
            mockPercentileSelector.Setup(s => s.SelectFrom("IntelligenceAlignments", It.IsAny<Int32>())).Returns("neutral");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Dependent: situation with neutral)"));
        }

        [Test]
        public void IfIntermittentFunctioning_GetMale()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("Curses", It.IsAny<Int32>())).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.d3(1)).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom("CursedDependentSituations", It.IsAny<Int32>())).Returns("situation with Gender");
            mockDice.Setup(d => d.d2(1)).Returns(1);

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Dependent: situation with male)"));
        }

        [Test]
        public void IfIntermittentFunctioning_GetFemale()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("Curses", It.IsAny<Int32>())).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.d3(1)).Returns(2);
            mockPercentileSelector.Setup(s => s.SelectFrom("CursedDependentSituations", It.IsAny<Int32>())).Returns("situation with Gender");
            mockDice.Setup(d => d.d2(1)).Returns(2);

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Dependent: situation with female)"));
        }

        [Test]
        public void IfIntermittentFunctioning_3OnD3IsUncontrolled()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("Curses", It.IsAny<Int32>())).Returns("Intermittent Functioning");
            mockDice.Setup(d => d.d3(1)).Returns(3);

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("Intermittent Functioning (Uncontrolled)"));
        }

        [Test]
        public void IfDrawback_GetDrawback()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("Curses", It.IsAny<Int32>())).Returns("Drawback");
            mockPercentileSelector.Setup(s => s.SelectFrom("CurseDrawbacks", It.IsAny<Int32>())).Returns("cursed drawback");

            var curse = curseGenerator.GenerateCurse();
            Assert.That(curse, Is.EqualTo("cursed drawback"));
        }

        [Test]
        public void GetSpecificCursedItem()
        {
            mockPercentileSelector.Setup(s => s.SelectFrom("SpecificCursedItems", It.IsAny<Int32>())).Returns("specific cursed item");

            var cursedItem = curseGenerator.GenerateSpecificCursedItem();
            Assert.That(cursedItem.Name, Is.EqualTo("specific cursed item"));
            Assert.That(cursedItem.Magic[Magic.IsMagical], Is.True);
            Assert.That(cursedItem.Magic[Magic.Curse], Is.EqualTo("This is a specific cursed item"));
        }
    }
}