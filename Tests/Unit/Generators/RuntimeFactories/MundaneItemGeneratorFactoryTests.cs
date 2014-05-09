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
    public class MundaneItemGeneratorFactoryTests
    {
        private IMundaneItemGeneratorFactory factory;

        [SetUp]
        public void Setup()
        {
            var mockPercentileSelector = new Mock<IPercentileSelector>();
            var mockAmmunitionGenerator = new Mock<IMundaneItemGenerator>();
            var mockMaterialsGenerator = new Mock<ISpecialMaterialGenerator>();
            var mockAttributesSelector = new Mock<IAttributesSelector>();
            var mockDice = new Mock<IDice>();

            factory = new MundaneItemGeneratorFactory(mockPercentileSelector.Object, mockAmmunitionGenerator.Object,
                mockMaterialsGenerator.Object, mockAttributesSelector.Object, mockDice.Object);
        }

        [Test]
        public void CreateArmorGenerator()
        {
            var generator = factory.CreateGeneratorOf(ItemTypeConstants.Armor);
            Assert.That(generator, Is.TypeOf<MundaneArmorGenerator>());
        }

        [Test]
        public void CreateWeaponGenerator()
        {
            var generator = factory.CreateGeneratorOf(ItemTypeConstants.Weapon);
            Assert.That(generator, Is.TypeOf<MundaneWeaponGenerator>());
        }

        [Test]
        public void CreateAlchemicalItemGenerator()
        {
            var generator = factory.CreateGeneratorOf(ItemTypeConstants.AlchemicalItem);
            Assert.That(generator, Is.TypeOf<MundaneWeaponGenerator>());
        }

        [Test]
        public void CreateToolGenerator()
        {
            var generator = factory.CreateGeneratorOf(ItemTypeConstants.Tool);
            Assert.That(generator, Is.TypeOf<MundaneWeaponGenerator>());
        }

        [Test]
        public void InvalidTypeThrowsError()
        {
            Assert.That(() => factory.CreateGeneratorOf("invalid type"), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}