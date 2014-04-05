using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Magical;
using EquipmentGen.Generators.RuntimeFactories;
using EquipmentGen.Generators.RuntimeFactories.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.RuntimeFactories
{
    [TestFixture]
    public class MagicalGearGeneratorFactoryTests
    {
        private IMagicalGearGeneratorFactory factory;

        [SetUp]
        public void Setup()
        {
            var mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            var mockPercentileSelector = new Mock<IPercentileSelector>();
            var mockAttributesSelector = new Mock<IAttributesSelector>();
            var mockSpecialAbilitiesGenerator = new Mock<ISpecialAbilitiesGenerator>();
            var mockMaterialsGenerator = new Mock<ISpecialMaterialGenerator>();
            var mockMagicItemTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            var mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            var mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();
            var mockDice = new Mock<IDice>();
            var mockCurseGenerator = new Mock<ICurseGenerator>();

            factory = new MagicalGearGeneratorFactory(mockTypeAndAmountPercentileSelector.Object,
                mockPercentileSelector.Object, mockAttributesSelector.Object, mockSpecialAbilitiesGenerator.Object,
                mockMaterialsGenerator.Object, mockMagicItemTraitsGenerator.Object, mockIntelligenceGenerator.Object,
                mockSpecificGearGenerator.Object, mockDice.Object, mockCurseGenerator.Object);
        }

        [Test]
        public void ProduceArmorGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Armor);
            Assert.That(generator, Is.TypeOf<MagicalArmorGenerator>());
        }

        [Test]
        public void ProduceWeaponGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Weapon);
            Assert.That(generator, Is.TypeOf<MagicalWeaponGenerator>());
        }

        [Test]
        public void InvalidTypeThrowsError()
        {
            Assert.That(() => factory.CreateWith("invalid type"), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}