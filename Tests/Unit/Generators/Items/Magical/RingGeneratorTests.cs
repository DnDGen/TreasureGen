using System;
using System.Collections.Generic;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Selectors.Interfaces.Objects;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class RingGeneratorTests
    {
        private IMagicalItemGenerator ringGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IMagicalItemTraitsGenerator> mockTraitsGenerator;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private TypeAndAmountPercentileResult result;

        [SetUp]
        public void Setup()
        {
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            result = new TypeAndAmountPercentileResult();
            ringGenerator = new RingGenerator(mockPercentileSelector.Object, mockAttributesSelector.Object, mockSpellGenerator.Object, mockChargesGenerator.Object, mockTypeAndAmountPercentileSelector.Object);

            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom(It.IsAny<String>())).Returns(result);
            result.Amount = 0;
        }

        [Test]
        public void GenerateRing()
        {
            var newResult = new TypeAndAmountPercentileResult();
            newResult.Type = "ring ability";
            newResult.Amount = 0;

            mockTypeAndAmountPercentileSelector.Setup(p => p.SelectFrom("powerRings")).Returns(newResult);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of ring ability"));
            Assert.That(ring.IsMagical, Is.True);
            Assert.That(ring.ItemType, Is.EqualTo(ItemTypeConstants.Ring));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            result.Type = "ring ability";
            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom("RingAttributes", result.Type)).Returns(attributes);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void EnergyIsGenerated()
        {
            result.Type = "ENERGY resistance";
            mockPercentileSelector.Setup(p => p.SelectFrom("Elements")).Returns("element");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of element resistance"));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            result.Type = "ring ability";
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(p => p.SelectFrom("RingAttributes", result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Ring, result.Type)).Returns(9266);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            result.Type = "ring ability";
            var attributes = new[] { "new attribute" };
            mockAttributesSelector.Setup(p => p.SelectFrom("RingAttributes", result.Type)).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Ring, result.Type)).Returns(9266);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void MinorSpellStoringHasSpell()
        {
            result.Type = "Minor spell storing";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(2);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 2)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Minor spell storing"));
            Assert.That(ring.Contents, Contains.Item("spell (spell type, 2)"));
            Assert.That(ring.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void MinorSpellStoringHasAtMost3SpellLevels()
        {
            result.Type = "Minor spell storing";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.SetupSequence(g => g.Generate("spell type", 1)).Returns("spell 1").Returns("spell 2").Returns("spell 3").Returns("spell 4");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Minor spell storing"));
            Assert.That(ring.Contents, Contains.Item("spell 1 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 2 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 3 (spell type, 1)"));
            Assert.That(ring.Contents.Count, Is.EqualTo(3));
            mockSpellGenerator.Verify(g => g.GenerateType(), Times.Exactly(3));
            mockSpellGenerator.Verify(g => g.GenerateLevel("power"), Times.AtLeast(3));
        }

        [Test]
        public void MinorSpellStoringAllowsDuplicateSpells()
        {
            result.Type = "Minor spell storing";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 1)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Minor spell storing"));
            Assert.That(ring.Contents, Contains.Item("spell (spell type, 1)"));
            Assert.That(ring.Contents.Count, Is.EqualTo(3));
            Assert.That(ring.Contents.Distinct().Count(), Is.EqualTo(1));
        }

        [Test]
        public void SpellStoringHasSpell()
        {
            result.Type = "Spell storing";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(3);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 3)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Spell storing"));
            Assert.That(ring.Contents, Contains.Item("spell (spell type, 3)"));
            Assert.That(ring.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void SpellStoringHasAtMost5SpellLevels()
        {
            result.Type = "Spell storing";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.SetupSequence(g => g.Generate("spell type", 1)).Returns("spell 1").Returns("spell 2")
                .Returns("spell 3").Returns("spell 4").Returns("spell 5").Returns("spell 6");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Spell storing"));
            Assert.That(ring.Contents, Contains.Item("spell 1 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 2 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 3 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 4 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 5 (spell type, 1)"));
            Assert.That(ring.Contents.Count, Is.EqualTo(5));
            mockSpellGenerator.Verify(g => g.GenerateType(), Times.Exactly(5));
            mockSpellGenerator.Verify(g => g.GenerateLevel("power"), Times.AtLeast(5));
        }

        [Test]
        public void SpellStoringAllowsDuplicateSpells()
        {
            result.Type = "Spell storing";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 1)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Spell storing"));
            Assert.That(ring.Contents, Contains.Item("spell (spell type, 1)"));
            Assert.That(ring.Contents.Count, Is.EqualTo(5));
            Assert.That(ring.Contents.Distinct().Count(), Is.EqualTo(1));
        }

        [Test]
        public void MajorSpellStoringHasSpell()
        {
            result.Type = "Major spell storing";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(6);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 6)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Major spell storing"));
            Assert.That(ring.Contents, Contains.Item("spell (spell type, 6)"));
            Assert.That(ring.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void MajorSpellStoringHasAtMost10SpellLevels()
        {
            result.Type = "Major spell storing";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.SetupSequence(g => g.Generate("spell type", 1)).Returns("spell 1").Returns("spell 2")
                .Returns("spell 3").Returns("spell 4").Returns("spell 5").Returns("spell 6").Returns("spell 7").Returns("spell 8")
                .Returns("spell 9").Returns("spell 10").Returns("spell 11");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Major spell storing"));
            Assert.That(ring.Contents, Contains.Item("spell 1 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 2 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 3 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 4 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 5 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 6 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 7 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 8 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 9 (spell type, 1)"));
            Assert.That(ring.Contents, Contains.Item("spell 10 (spell type, 1)"));
            Assert.That(ring.Contents.Count, Is.EqualTo(10));
            mockSpellGenerator.Verify(g => g.GenerateType(), Times.Exactly(10));
            mockSpellGenerator.Verify(g => g.GenerateLevel("power"), Times.AtLeast(10));
        }

        [Test]
        public void MajorSpellStoringAllowsDuplicateSpells()
        {
            result.Type = "Major spell storing";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 1)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Major spell storing"));
            Assert.That(ring.Contents, Contains.Item("spell (spell type, 1)"));
            Assert.That(ring.Contents.Count, Is.EqualTo(10));
            Assert.That(ring.Contents.Distinct().Count(), Is.EqualTo(1));
        }

        [Test]
        public void CounterspellsHasSpell()
        {
            result.Type = "Counterspells";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(4);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 4)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Counterspells"));
            Assert.That(ring.Contents, Contains.Item("spell"));
            Assert.That(ring.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void CounterspellsHasAtMost1Spell()
        {
            result.Type = "Counterspells";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.SetupSequence(g => g.Generate("spell type", 1)).Returns("spell 1").Returns("spell 2");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Counterspells"));
            Assert.That(ring.Contents, Contains.Item("spell 1"));
            Assert.That(ring.Contents.Count, Is.EqualTo(1));
            mockSpellGenerator.Verify(g => g.GenerateType(), Times.Exactly(1));
            mockSpellGenerator.Verify(g => g.GenerateLevel("power"), Times.Exactly(1));
        }

        [Test]
        public void CounterspellsHasSpellOfAtMostSixthLevel()
        {
            result.Type = "Counterspells";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(6);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 6)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Counterspells"));
            Assert.That(ring.Contents, Contains.Item("spell"));
            Assert.That(ring.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void CounterspellsHasNoSpellHigherThanSixthLevel()
        {
            result.Type = "Counterspells";
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(7);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 7)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Counterspells"));
            Assert.That(ring.Contents, Is.Empty);
        }

        [Test]
        public void GetBonus()
        {
            result.Type = "ring ability";
            result.Amount = 9266;

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of ring ability"));
            Assert.That(ring.Magic.Bonus, Is.EqualTo(9266));
        }
    }
}