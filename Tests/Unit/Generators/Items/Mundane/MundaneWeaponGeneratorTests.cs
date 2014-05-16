using System;
using System.Collections.Generic;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Generators.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;
using Moq;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Mundane
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests
    {
        private IMundaneItemGenerator mundaneWeaponGenerator;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IMundaneItemGenerator> mockAmmunitionGenerator;
        private Mock<ISpecialMaterialGenerator> mockMaterialsGenerator;
        private Mock<IAttributesSelector> mockAttributesSelector;

        [SetUp]
        public void Setup()
        {
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockAmmunitionGenerator = new Mock<IMundaneItemGenerator>();
            mockMaterialsGenerator = new Mock<ISpecialMaterialGenerator>();
            mockAttributesSelector = new Mock<IAttributesSelector>();
            mundaneWeaponGenerator = new MundaneWeaponGenerator(mockPercentileSelector.Object, mockAmmunitionGenerator.Object, mockAttributesSelector.Object);

            mockPercentileSelector.Setup(p => p.SelectFrom("MundaneWeapons")).Returns("weapon type");
            mockPercentileSelector.Setup(p => p.SelectFrom("weapon typeWeapons")).Returns("weapon name");
        }

        [Test]
        public void GenerateWeapon()
        {
            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public void GetWeaponTypeFromPercentileSelector()
        {
            mundaneWeaponGenerator.Generate();
            mockPercentileSelector.Verify(p => p.SelectFrom("MundaneWeapons"), Times.Once);
        }

        [Test]
        public void GetNameFromType()
        {
            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Name, Is.EqualTo("weapon name"));
        }

        [Test]
        public void GetAmmunition()
        {
            var ammo = new Item();
            mockPercentileSelector.Setup(p => p.SelectFrom("weapon typeWeapons")).Returns(AttributeConstants.Ammunition);
            mockAmmunitionGenerator.Setup(p => p.Generate()).Returns(ammo);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon, Is.EqualTo(ammo));
        }

        [Test]
        public void GetAttributesFromSelector()
        {
            var attributes = new[] { "type 1", "type 2" };
            mockAttributesSelector.Setup(p => p.SelectFrom("WeaponAttributes", "weapon name")).Returns(attributes);

            var weapon = mundaneWeaponGenerator.Generate();
            Assert.That(weapon.Attributes, Is.EqualTo(attributes));
        }
    }
}