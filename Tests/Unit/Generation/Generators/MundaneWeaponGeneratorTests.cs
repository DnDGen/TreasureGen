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
        private Mock<ISpecialMaterialGenerator> mockMaterialsProvider;
        private Mock<ITypesProvider> mockTypesProvider;

        [SetUp]
        public void Setup()
        {
            mockPercentileResultProvider = new Mock<IPercentileResultProvider>();
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("MundaneWeapons")).Returns("weapon type");
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("weapon typeWeapons")).Returns("weapon name");

            mockAmmunitionGenerator = new Mock<IAmmunitionGenerator>();
            mockMaterialsProvider = new Mock<ISpecialMaterialGenerator>();
            mockTypesProvider = new Mock<ITypesProvider>();
            mundaneWeaponGenerator = new MundaneWeaponGenerator(mockPercentileResultProvider.Object, mockAmmunitionGenerator.Object,
                mockMaterialsProvider.Object, mockTypesProvider.Object);
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
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void MundaneWeaponGeneratorGetsWeaponTypeFromPercentileResultProvider()
        {
            mundaneWeaponGenerator.Generate();
            mockPercentileResultProvider.Verify(p => p.GetResultFrom("MundaneWeapons"), Times.Once);
        }

        [Test]
        public void MundaneWeaponGeneratorGetsNameFromType()
        {
            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
        }

        [Test]
        public void MundaneWeaponGeneratorGetsAmmunition()
        {
            var ammo = new Ammunition();
            mockAmmunitionGenerator.Setup(p => p.Generate()).Returns(ammo);
            mockPercentileResultProvider.Setup(p => p.GetResultFrom("weapon typeWeapons")).Returns("Ammunition");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon, Is.EqualTo(ammo));
        }

        [Test]
        public void MundaneWeaponGeneratorGetsGearTypesFromProvider()
        {
            var types = new[] { "type 1", "type 2" };
            mockTypesProvider.Setup(p => p.GetTypesFor("weapon name", "WeaponTypes")).Returns(types);

            var armor = mundaneWeaponGenerator.Generate();
            Assert.That(armor.Types, Is.EqualTo(types));
        }

        [Test]
        public void MundaneWeaponGeneratorDoesNotGetSpecialMaterialIfWeaponDoesNotHaveSpecialMaterial()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(false);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var armor = mundaneWeaponGenerator.Generate();
            Assert.That(armor.Traits, Is.Not.Contains("special material"));
        }

        [Test]
        public void MundaneWeaponGeneratorGetsSpecialMaterialFromMaterialProvider()
        {
            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(It.IsAny<IEnumerable<String>>())).Returns(true);
            mockMaterialsProvider.Setup(p => p.GenerateFor(It.IsAny<IEnumerable<String>>())).Returns("special material");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item("special material"));
        }

        [Test]
        public void DoubleWeaponsCanHaveMultipleSpecialMaterials()
        {
            var types = new[] { TypeConstants.DoubleWeapon };
            mockTypesProvider.Setup(p => p.GetTypesFor("weapon name", "WeaponTypes")).Returns(types);

            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(types)).Returns(true);
            mockMaterialsProvider.SetupSequence(p => p.GenerateFor(types)).Returns("special material 1").Returns("special material 2");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item("special material 1"));
            Assert.That(weapon.Traits, Contains.Item("special material 2"));
        }

        [Test]
        public void CannotAddDuplicateSpecialMaterials()
        {
            var types = new[] { TypeConstants.DoubleWeapon };
            mockTypesProvider.Setup(p => p.GetTypesFor("weapon name", "WeaponTypes")).Returns(types);

            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(types)).Returns(true);
            mockMaterialsProvider.Setup(p => p.GenerateFor(types)).Returns("special material");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Is.Unique);
        }

        [Test]
        public void IfSecondHeadDoesNotHaveSpecialMaterial_WholeWeaponOneSpecialMaterial()
        {
            var types = new[] { TypeConstants.DoubleWeapon };
            mockTypesProvider.Setup(p => p.GetTypesFor("weapon name", "WeaponTypes")).Returns(types);

            mockMaterialsProvider.SetupSequence(p => p.HasSpecialMaterial(types)).Returns(true).Returns(false);
            mockMaterialsProvider.SetupSequence(p => p.GenerateFor(types)).Returns("special material 1").Returns("special material 2");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item("special material 1"));
            Assert.That(weapon.Traits, Is.Not.Contains("special material 2"));
        }

        [Test]
        public void NonDoubleWeaponsCannotHaveMultipleSpecialMaterials()
        {
            var types = new[] { "not double weapon" };
            mockTypesProvider.Setup(p => p.GetTypesFor("weapon name", "WeaponTypes")).Returns(types);

            mockMaterialsProvider.Setup(p => p.HasSpecialMaterial(types)).Returns(true);
            mockMaterialsProvider.SetupSequence(p => p.GenerateFor(types)).Returns("special material 1").Returns("special material 2");

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item("special material 1"));
            Assert.That(weapon.Traits, Is.Not.Contains("special material 2"));
        }
    }
}