using System;
using D20Dice;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Factories;
using EquipmentGen.Core.Generation.Factories.Interfaces;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Factories
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