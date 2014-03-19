using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Generators.RuntimeFactories;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.RuntimeFactories
{
    [TestFixture]
    public class MundaneGearGeneratorFactoryTests
    {
        private IMundaneGearGeneratorFactory factory;

        [SetUp]
        public void Setup()
        {
            var mockPercentileSelector = new Mock<IPercentileSelector>();
            var mockAmmunitionGenerator = new Mock<IAmmunitionGenerator>();
            var mockMaterialsGenerator = new Mock<ISpecialMaterialGenerator>();
            var mockAttributesSelector = new Mock<IAttributesSelector>();
            var mockDice = new Mock<IDice>();

            factory = new MundaneGearGeneratorFactory(mockPercentileSelector.Object, mockAmmunitionGenerator.Object,
                mockMaterialsGenerator.Object, mockAttributesSelector.Object, mockDice.Object);
        }

        [Test]
        public void ProduceArmorGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Armor);
            Assert.That(generator, Is.TypeOf<MundaneArmorGenerator>());
        }

        [Test]
        public void ProduceWeaponGenerator()
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