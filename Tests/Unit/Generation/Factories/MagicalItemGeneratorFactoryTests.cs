using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
{
    [TestFixture]
    public class MagicalItemGeneratorFactoryTests
    {
        private IMagicalItemGeneratorFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new MagicalItemGeneratorFactory();
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