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
            var generator = factory.CreateWith(ItemsConstants.ItemTypes.Potion);
            Assert.That(generator, Is.TypeOf<PotionGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesRingGenerator()
        {
            var generator = factory.CreateWith(ItemsConstants.ItemTypes.Ring);
            Assert.That(generator, Is.TypeOf<RingGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesRodGenerator()
        {
            var generator = factory.CreateWith(ItemsConstants.ItemTypes.Rod);
            Assert.That(generator, Is.TypeOf<RodGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesScrollGenerator()
        {
            var generator = factory.CreateWith(ItemsConstants.ItemTypes.Scroll);
            Assert.That(generator, Is.TypeOf<ScrollGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesStaffGenerator()
        {
            var generator = factory.CreateWith(ItemsConstants.ItemTypes.Staff);
            Assert.That(generator, Is.TypeOf<StaffGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesWandGenerator()
        {
            var generator = factory.CreateWith(ItemsConstants.ItemTypes.Wand);
            Assert.That(generator, Is.TypeOf<WandGenerator>());
        }

        [Test]
        public void MagicalItemGeneratorFactoryCreatesWondrousItemGenerator()
        {
            var generator = factory.CreateWith(ItemsConstants.ItemTypes.WondrousItem);
            Assert.That(generator, Is.TypeOf<WondrousItemGenerator>());
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidTypeThrowsException()
        {
            factory.CreateWith("invalid type");
        }
    }
}