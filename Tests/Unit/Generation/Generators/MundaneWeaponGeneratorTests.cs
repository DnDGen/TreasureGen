using System;
using System.Collections.Generic;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests
    {
        private IMundaneGearGenerator mundaneWeaponGenerator;
        private Mock<IPercentileResultProvider> mockPercentileResultProvider;
        private Mock<IAmmunitionGenerator> mockAmmunitionGenerator;
        private Mock<IMaterialsProvider> mockMaterialsProvider;
        private Mock<IGearTypesProvider> mockGearTypesProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockAmmunitionGenerator = new Mock<IAmmunitionGenerator>();
            mockMaterialsProvider = new Mock<IMaterialsProvider>();
            mockGearTypesProvider = new Mock<IGearTypesProvider>();
            mundaneWeaponGenerator = new MundaneWeaponGenerator(mockPercentileResultProvider.Object, mockAmmunitionGenerator.Object,
                mockMaterialsProvider.Object, mockGearTypesProvider.Object);
        }

        [Test]
        public void MundaneWeaponGeneratorGeneratesWeapon()
        {
            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon, Is.Not.Null);
        }

        [Test]
        public void MundaneWeaponGeneratorGeneratesMasterworkWeapons()
        {
            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item(ItemsConstants.Gear.Traits.Masterwork));
        }

        [Test]
        public void MundaneWeaponGeneratorGetsWeaponTypeFromPercentileResultProvider()
        {
            mundaneWeaponGenerator.Generate();
            mockPercentileResultProvider.Verify(p => p.GetPercentileResult("MundaneWeapons"), Times.Once);
        }

        [Test]
        public void MundaneWeaponGeneratorGetsNameFromType()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneWeapons")).Returns("weapon type");
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("weapon typeWeapons")).Returns("weapon name");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
        }

        [Test]
        public void MundaneWeaponGeneratorGetsAmmunition()
        {
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("MundaneWeapons")).Returns("weapon type");
            mockPercentileResultProvider.Setup(p => p.GetPercentileResult("weapon typeWeapons")).Returns("Ammunition");
            var ammo = new Ammunition();
            mockAmmunitionGenerator.Setup(p => p.Generate()).Returns(ammo);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon, Is.EqualTo(ammo));
        }

        [Test]
        public void MundaneWeaponGeneratorGetsGearTypesFromProvider()
        {
            var types = new[] { "type 1", "type 2" };
            mockGearTypesProvider.Setup(p => p.GetGearTypesFor("weapon type")).Returns(types);

            var armor = mundaneWeaponGenerator.Generate();
            Assert.That(armor.Types, Is.EqualTo(types));
        }

        [Test]
        public void MundaneWeaponGeneratorDoesNotGetSpecialMaterialIfWeaponDoesNotHaveSpecialMaterial()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial()).Returns(false);
            mockMaterialsProvider.Setup(p => p.GetSpecialMaterialFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneWeaponGenerator.Generate();
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void MundaneWeaponGeneratorGetsSpecialMaterialFromMaterialProvider()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial()).Returns(true);
            mockMaterialsProvider.Setup(p => p.GetSpecialMaterialFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item("special material"));
        }
    }
}