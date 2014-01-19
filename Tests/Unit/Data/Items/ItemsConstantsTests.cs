using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class ItemsConstantsTests
    {
        [Test]
        public void MundaneConstant()
        {
            Assert.That(ItemsConstants.Power.Mundane, Is.EqualTo("Mundane"));
        }

        [Test]
        public void MinorConstant()
        {
            Assert.That(ItemsConstants.Power.Minor, Is.EqualTo("Minor"));
        }

        [Test]
        public void MediumConstant()
        {
            Assert.That(ItemsConstants.Power.Medium, Is.EqualTo("Medium"));
        }

        [Test]
        public void MajorConstant()
        {
            Assert.That(ItemsConstants.Power.Major, Is.EqualTo("Major"));
        }

        [Test]
        public void AlchemicalItemConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.AlchemicalItem, Is.EqualTo("Alchemical Item"));
        }

        [Test]
        public void ArmorConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Armor, Is.EqualTo("Armor"));
        }

        [Test]
        public void WeaponConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Weapon, Is.EqualTo("Weapon"));
        }

        [Test]
        public void ToolConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Tool, Is.EqualTo("Tool"));
        }
    }
}