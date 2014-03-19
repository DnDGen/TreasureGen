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
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Tests.Unit.Generators.RuntimeFactories
{
    [TestFixture]
    public class MundaneGearGeneratorFactoryTests
    {
        private IMundaneGearGeneratorFactory factory;

        [SetUp]
        public void Setup()
        {
            var mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            var mockAmmunitionGenerator = new Mock<IAmmunitionGenerator>();
            var mockMaterialsProvider = new Mock<ISpecialMaterialGenerator>();
            var mockAttributesProvider = new Mock<IAttributesProvider>();
            var mockDice = new Mock<IDice>();

            factory = new MundaneGearGeneratorFactory(mockPercentileResultProvider.Object, mockAmmunitionGenerator.Object,
                mockMaterialsProvider.Object, mockAttributesProvider.Object, mockDice.Object);
        }

        [Test]
        public void MundaneGearGeneratorFactoryProducesArmorGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Armor);
            Assert.That(generator, Is.TypeOf<MundaneArmorGenerator>());
        }

        [Test]
        public void MundaneGearGeneratorFactoryProducesWeaponGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Weapon);
            Assert.That(generator, Is.TypeOf<MundaneWeaponGenerator>());
        }

        [Test]
        public void InvalidTypeThrowsError()
        {
            Assert.That(() => factory.CreateWith("invalid type"), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}