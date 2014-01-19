using EquipmentGen.Core.Generation.Generators;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Generators
{
    [TestFixture]
    public class ArmorGeneratorTests
    {
        private IGearGenerator armorGenerator;

        [SetUp]
        public void Setup()
        {
            armorGenerator = new ArmorGenerator();
        }

        [Test]
        public void ArmorGeneratorAtPowerReturnsArmor()
        {
            var armor = armorGenerator.GenerateAtPower("power");
            Assert.That(armor, Is.Not.Null);
        }

        [Test]
        public void ArmorGeneratorAtLevelReturnsArmor()
        {
            var armor = armorGenerator.GenerateAtLevel(1);
            Assert.That(armor, Is.Not.Null);
        }
    }
}