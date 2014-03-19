using System;
using System.Collections.Generic;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Common.Items;
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
    public class RingGeneratorTests
    {
        private IMagicalItemGenerator ringGenerator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IAttributesProvider> mockAttributesProvider;
        private Mock<IMagicalItemTraitsGenerator> mockTraitsGenerator;
        private Mock<IIntelligenceGenerator> mockIntelligenceGenerator;
        private Mock<IChargesGenerator> mockChargesGenerator;
        private Mock<ISpellGenerator> mockSpellGenerator;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockAttributesProvider = new Mock<IAttributesProvider>();
            mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            mockChargesGenerator = new Mock<IChargesGenerator>();
            mockSpellGenerator = new Mock<ISpellGenerator>();

            mockDice = new Mock<IDice>();
            mockDice.Setup(d => d.Percentile(1)).Returns(9266);

            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("ring ability");

            ringGenerator = new RingGenerator(mockPercentileResultProvider.Object, mockAttributesProvider.Object,
                mockTraitsGenerator.Object, mockSpellGenerator.Object, mockIntelligenceGenerator.Object, mockChargesGenerator.Object,
                mockDice.Object);
        }

        [Test]
        public void GenerateRing()
        {
            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of ring ability"));
            Assert.That(ring.Magic[Magic.IsMagical], Is.True);
        }

        [Test]
        public void GetAttributesFromProvider()
        {
            var attributes = new[] { "attribute 1", "attribute 2" };
            mockAttributesProvider.Setup(p => p.GetAttributesFor("ring ability", "RingAttributes")).Returns(attributes);

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
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 92)).Returns("energy resistance");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("Elements", 66)).Returns("element");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of energy resistance (element)"));
        }

        [Test]
        public void GetIntelligenceIfIntelligent()
        {
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(ItemTypeConstants.Ring, It.IsAny<IEnumerable<String>>(),
                It.IsAny<Dictionary<Magic, Object>>())).Returns(true);
            var intelligence = new Intelligence();
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Dictionary<Magic, Object>>()))
                .Returns(intelligence);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic[Magic.Intelligence], Is.EqualTo(intelligence));
        }

        [Test]
        public void DoNotGetIntelligenceIfNotIntelligent()
        {
            mockIntelligenceGenerator.Setup(g => g.IsIntelligent(ItemTypeConstants.Ring, It.IsAny<IEnumerable<String>>(),
                It.IsAny<Dictionary<Magic, Object>>())).Returns(false);
            var intelligence = new Intelligence();
            mockIntelligenceGenerator.Setup(g => g.GenerateFor(It.IsAny<Dictionary<Magic, Object>>()))
                .Returns(intelligence);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic.Keys, Is.Not.Contains(Magic.Intelligence));
        }

        [Test]
        public void GetChargesIfCharged()
        {
            var attributes = new[] { AttributeConstants.Charged };
            mockAttributesProvider.Setup(p => p.GetAttributesFor("ring ability", "RingAttributes")).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Ring, "ring ability")).Returns(9266);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic[Magic.Charges], Is.EqualTo(9266));
        }

        [Test]
        public void DoNotGetChargesIfNotCharged()
        {
            var attributes = new[] { "new attribute" };
            mockAttributesProvider.Setup(p => p.GetAttributesFor("ring", "RingAttributes")).Returns(attributes);
            mockChargesGenerator.Setup(g => g.GenerateFor(ItemTypeConstants.Ring, "ring ability")).Returns(9266);

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Magic.Keys, Is.Not.Contains(Magic.Charges));
        }

        [Test]
        public void MinorSpellStoringHasSpell()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Minor spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(2);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 2)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Minor spell storing (spell)"));
        }

        [Test]
        public void MinorSpellStoringHasAtMost3SpellLevels()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Minor spell storing");
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
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Minor spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 1)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Minor spell storing (spell, spell, spell)"));
        }

        [Test]
        public void SpellStoringHasSpell()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(3);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 3)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Spell storing (spell)"));
        }

        [Test]
        public void SpellStoringHasAtMost5SpellLevels()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Spell storing");
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
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 1)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Spell storing (spell, spell, spell, spell, spell)"));
        }

        [Test]
        public void MajorSpellStoringHasSpell()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Major spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(6);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 6)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Major spell storing (spell)"));
        }

        [Test]
        public void MajorSpellStoringHasAtMost10SpellLevels()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Major spell storing");
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
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Major spell storing");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(1);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 1)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Major spell storing (spell, spell, spell, spell, spell, spell, spell, spell, spell, spell)"));
        }

        [Test]
        public void CounterspellsHasSpell()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Counterspells");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(4);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 4)).Returns("spell");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Counterspells (spell)"));
        }

        [Test]
        public void CounterspellsHasAtMost1Spell()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Counterspells");
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
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Counterspells");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(6);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 6)).Returns("spell lvl. 6");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Counterspells (spell lvl. 6)"));
        }

        [Test]
        public void CounterspellsDoesNotHaveSpellHigherThanSixthLevel()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("Counterspells");
            mockSpellGenerator.Setup(g => g.GenerateType()).Returns("spell type");
            mockSpellGenerator.Setup(g => g.GenerateLevel("power")).Returns(7);
            mockSpellGenerator.Setup(g => g.Generate("spell type", 7)).Returns("spell lvl. 7");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of Counterspells"));
        }

        [Test]
        public void ParseBonus()
        {
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("powerRings", 9266)).Returns("ring ability +90210");

            var ring = ringGenerator.GenerateAtPower("power");
            Assert.That(ring.Name, Is.EqualTo("Ring of ring ability +90210"));
            Assert.That(ring.Magic[Magic.Bonus], Is.EqualTo(90210));
        }
    }
}