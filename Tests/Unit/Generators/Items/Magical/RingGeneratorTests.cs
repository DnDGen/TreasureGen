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
    public class RingGeneratorTests
    {
        private IMagicalItemGenerator ringGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IAttributesSelector> mockAttributesSelector;
        private Mock<IMagicalItemTraitsGenerator> mockTraitsGenerator;
        private Mock<IIntelligenceGenerator> mockIntelligenceGenerator;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private Mock<IDice> mockDice;
        private Mock<ICurseGenerator> mockCurseGenerator;

        [SetUp]
        public void Setup()
        {
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockSpellGenerator = new Mock<ISpellGenerator>();
            mockCurseGenerator = new Mock<ICurseGenerator>();

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);

            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("ring ability");

            ringGenerator = new RingGenerator(mockPercentileSelector.Object, mockAttributesSelector.Object,
                mockTraitsGenerator.Object, mockSpellGenerator.Object, mockIntelligenceGenerator.Object, mockChargesGenerator.Object,
                mockDice.Object, mockCurseGenerator.Object);
        }

        [Test]
        public void GenerateRing()
        {
            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of ring ability"));
            Assert.That(ring.IsMagical, Is.True);
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom("RingAttributes", "ring ability")).Returns(attributes);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Attributes, Is.EqualTo(attributes));
        }

        [Test]
        public void GetTraitsFromGenerator()
        {
            var traits = new[] { "trait 1", "trait 2" };
            mockTraitsGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Ring)).Returns(traits);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Traits, Is.EqualTo(traits));
        }

        [Test]
        public void EnergyResistanceDeterminesType()
        {
            mockDice.SetupSequence(d => d.Percentile(1)).Returns(92).Returns(66);
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 92)).Returns("energy resistance");
            mockPercentileSelector.Setup(p => p.SelectFrom("Elements", 66)).Returns("element");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of energy resistance (element)"));
        }

        [Test]
        public void GetIntelligenceIfIntelligent()
        {
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(ItemTypeConstants.Ring, It.IsAny<IEnumerable<String>>(),
                It.IsAny<Boolean>())).Returns(true);
            var intelligence = new Intelligence();
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Magic>())).Returns(intelligence);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic.Intelligence, Is.EqualTo(intelligence));
        }

        [Test]
        public void DoNotGetIntelligenceIfNotIntelligent()
        {
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(ItemTypeConstants.Ring, It.IsAny<IEnumerable<String>>(),
                It.IsAny<Boolean>())).Returns(false);
            var intelligence = new Intelligence();
            intelligence.Ego = 9266;
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Magic>()))
                .Returns(intelligence);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic.Intelligence, Is.Not.EqualTo(intelligence));
            Assert.That(ring.Magic.Intelligence.Ego, Is.EqualTo(0));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesSelector.Setup(p => p.SelectFrom("RingAttributes", "ring ability")).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Ring, "ring ability")).Returns(9266);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic.Charges, Is.EqualTo(9266));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            var attributes = new[] { "new attribute" };
            mockAttributesSelector.Setup(p => p.SelectFrom("RingAttributes", "ring")).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Ring, "ring ability")).Returns(9266);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic.Charges, Is.EqualTo(0));
        }

        [Test]
        public void MinorSpellStoringHasSpell()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Minor spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(2);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 2)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Minor spell storing"));
            Assert.That(ring.Contents, Contains.Item("spell"));
            Assert.That(ring.Contents.Count, Is.EqualTo(1));
        }

        [Test]
        public void MinorSpellStoringHasAtMost3SpellLevels()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Minor spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.SetupSequence(g => g.Generate("spell type", 1)).Returns("spell 1").Returns("spell 2").Returns("spell 3").Returns("spell 4");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Minor spell storing (spell 1, spell 2, spell 3)"));
            mockSpellGenerator.Verify(g => g.GenerateType(), Times.Exactly(3));
            mockSpellGenerator.Verify(g => g.GenerateLevel("power"), Times.Exactly(3));
        }

        [Test]
        public void MinorSpellStoringAllowsDuplicateSpells()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Minor spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 1)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Minor spell storing (spell, spell, spell)"));
        }

        [Test]
        public void SpellStoringHasSpell()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(3);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 3)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Spell storing (spell)"));
        }

        [Test]
        public void SpellStoringHasAtMost5SpellLevels()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.SetupSequence(g => g.Generate("spell type", 1)).Returns("spell 1").Returns("spell 2")
                .Returns("spell 3").Returns("spell 4").Returns("spell 5").Returns("spell 6");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Spell storing (spell 1, spell 2, spell 3, spell 4, spell 5)"));
            mockSpellGenerator.Verify(g => g.GenerateType(), Times.Exactly(5));
            mockSpellGenerator.Verify(g => g.GenerateLevel("power"), Times.Exactly(5));
        }

        [Test]
        public void SpellStoringAllowsDuplicateSpells()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 1)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Spell storing (spell, spell, spell, spell, spell)"));
        }

        [Test]
        public void MajorSpellStoringHasSpell()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Major spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(6);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 6)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Major spell storing (spell)"));
        }

        [Test]
        public void MajorSpellStoringHasAtMost10SpellLevels()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Major spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.SetupSequence(g => g.Generate("spell type", 1)).Returns("spell 1").Returns("spell 2")
                .Returns("spell 3").Returns("spell 4").Returns("spell 5").Returns("spell 6").Returns("spell 7").Returns("spell 8")
                .Returns("spell 9").Returns("spell 10").Returns("spell 11");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Major spell storing (spell 1, spell 2, spell 3, spell 4, spell 5, spell 6, spell 7, spell 8, spell 9, spell 10)"));
            mockSpellGenerator.Verify(g => g.GenerateType(), Times.Exactly(10));
            mockSpellGenerator.Verify(g => g.GenerateLevel("power"), Times.Exactly(10));
        }

        [Test]
        public void MajorSpellStoringAllowsDuplicateSpells()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Major spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 1)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Major spell storing (spell, spell, spell, spell, spell, spell, spell, spell, spell, spell)"));
        }

        [Test]
        public void CounterspellsHasSpell()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Counterspells");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(4);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 4)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Counterspells (spell)"));
        }

        [Test]
        public void CounterspellsHasAtMost1Spell()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Counterspells");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.SetupSequence(g => g.Generate("spell type", 1)).Returns("spell 1").Returns("spell 2");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Counterspells (spell 1)"));
            mockSpellGenerator.Verify(g => g.GenerateType(), Times.Exactly(1));
            mockSpellGenerator.Verify(g => g.GenerateLevel("power"), Times.Exactly(1));
        }

        [Test]
        public void CounterspellsHasSpellOfAtMostSixthLevel()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Counterspells");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(6);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 6)).Returns("spell lvl. 6");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Counterspells (spell lvl. 6)"));
        }

        [Test]
        public void CounterspellsDoesNotHaveSpellHigherThanSixthLevel()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("Counterspells");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(7);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 7)).Returns("spell lvl. 7");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Counterspells"));
        }

        [Test]
        public void ParseBonus()
        {
            mockPercentileSelector.Setup(p => p.SelectFrom("powerRings", 9266)).Returns("ring ability +90210");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of ring ability +90210"));
            Assert.That(ring.Magic.Bonus, Is.EqualTo(90210));
        }

        [Test]
        public void DoNotGetCurseIfNotCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(false);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic.Curse, Is.Empty);
        }

        [Test]
        public void GetCurseIfCursed()
        {
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("cursed");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic.Curse, Is.EqualTo("cursed"));
        }

        [Test]
        public void GetSpecificCursedItems()
        {
            var cursedItem = new Item();
            mockCurseGenerator.Setup(g => g.HasCurse(It.IsAny<Boolean>())).Returns(true);
            mockCurseGenerator.Setup(g => g.GenerateCurse()).Returns("SpecificCursedItem");
            mockCurseGenerator.Setup(g => g.GenerateSpecificCursedItem()).Returns(cursedItem);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring, Is.EqualTo(cursedItem));
        }
    }
}