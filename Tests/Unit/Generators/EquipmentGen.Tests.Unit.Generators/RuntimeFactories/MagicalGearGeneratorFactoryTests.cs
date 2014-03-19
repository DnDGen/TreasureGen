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
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Tests.Unit.Generators.RuntimeFactories
{
    [TestFixture]
    public class MagicalGearGeneratorFactoryTests
    {
        private IMagicalGearGeneratorFactory factory;

        [SetUp]
        public void Setup()
        {
            var mockTypeAndAmountPercentileResultProvider = new Mock<ITypeAndAmountPercentileResultProvider>();
            var mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            var mockTypesProvider = new Mock<IAttributesProvider>();
            var mockGearSpecialAbilitiesProvider = new Mock<ISpecialAbilitiesGenerator>();
            var mockMaterialsProvider = new Mock<ISpecialMaterialGenerator>();
            var mockMagicItemTraitsGenerator = new Mock<IMagicalItemTraitsGenerator>();
            var mockIntelligenceGenerator = new Mock<IIntelligenceGenerator>();
            var mockSpecificGearGenerator = new Mock<ISpecificGearGenerator>();
            var mockDice = new Mock<IDice>();

            factory = new MagicalGearGeneratorFactory(mockTypeAndAmountPercentileResultProvider.Object,
                mockPercentileResultProvider.Object, mockTypesProvider.Object, mockGearSpecialAbilitiesProvider.Object,
                mockMaterialsProvider.Object, mockMagicItemTraitsGenerator.Object, mockIntelligenceGenerator.Object,
                mockSpecificGearGenerator.Object, mockDice.Object);
        }

        [Test]
        public void MagicalGearGeneratorFactoryProducesArmorGenerator()
        {
            var generator = factory.CreateWith(ItemTypeConstants.Armor);
            Assert.That(generator, Is.TypeOf<MagicalArmorGenerator>());
        }

        [Test]
        public void MagicalGearGeneratorFactoryProducesWeaponGenerator()
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