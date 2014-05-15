using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Items.Magical;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class MagicalWeaponGeneratorTests
    {
        private IMagicalItemGenerator weaponGenerator;

        [SetUp]
        public void Setup()
        {
            weaponGenerator = new MagicalWeaponGenerator();
        }

        [Test]
        public void GenerateWeapon()
        {
            var weapon = weaponGenerator.GenerateAtPower("power");
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.AtLeast(1));
        }
    }
}