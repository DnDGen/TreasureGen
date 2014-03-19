using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.RuntimeFactories;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Generators;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Tests.Unit.Generators.RuntimeFactories
{
    [TestFixture]
    public class MagicalItemGeneratorFactoryTests
    {
        private IMagicalItemGeneratorFactory factory;

        [SetUp]
        public void Setup()
        {
            var mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            var mockTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            var mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            var mockAttributesProvider = new Mock<IAttributesProvider>();
            var mockChargesGenerator = new Mock<IChargesGenerator>();
            var mockDice = new Mock<IDice>();
            var mockSpellGenerator = new Mock<ISpellGenerator>();

            factory = new MagicalItemGeneratorFactory(mockPercentileResultProvider.Object, mockTraitsGenerator.Object,
                mockIntelligenceGenerator.Object, mockAttributesProvider.Object, mockChargesGenerator.Object,
                mockDice.Object, mockSpellGenerator.Object);
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesPotionGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Potion);
            Assert.That(generator, Is.TypeOf<PotionGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesRingGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Ring);
            Assert.That(generator, Is.TypeOf<RingGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesRodGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Rod);
            Assert.That(generator, Is.TypeOf<RodGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesScrollGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Scroll);
            Assert.That(generator, Is.TypeOf<ScrollGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesStaffGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Staff);
            Assert.That(generator, Is.TypeOf<StaffGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesWandGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Wand);
            Assert.That(generator, Is.TypeOf<WandGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesWondrousItemGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.WondrousItem);
            Assert.That(generator, Is.TypeOf<WondrousItemGenerator>());
        }

        [Test]
        public void InvalidTypeThrowsException()
        {
            Assert.That(() => factory.CreateWith("invalid type"), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}