using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class TypeConstantsTests
    {
        [Test]
        public void CommonConstant()
        {
            Assert.That(TypeConstants.Common, Is.EqualTo("Common"));
        }

        [Test]
        public void UncommonConstant()
        {
            Assert.That(TypeConstants.Uncommon, Is.EqualTo("Uncommon"));
        }

        [Test]
        public void WoodConstant()
        {
            Assert.That(TypeConstants.Wood, Is.EqualTo("Wood"));
        }

        [Test]
        public void MetalConstant()
        {
            Assert.That(TypeConstants.Metal, Is.EqualTo("Metal"));
        }

        [Test]
        public void DoubleWeaponConstant()
        {
            Assert.That(TypeConstants.DoubleWeapon, Is.EqualTo("Double weapon"));
        }

        [Test]
        public void MeleeConstant()
        {
            Assert.That(TypeConstants.Melee, Is.EqualTo("Melee"));
        }

        [Test]
        public void RangedConstant()
        {
            Assert.That(TypeConstants.Ranged, Is.EqualTo("Ranged"));
        }
        [Test]
        public void AmmunitionConstant()
        {
            Assert.That(TypeConstants.Ammunition, Is.EqualTo("Ammunition"));
        }

        [Test]
        public void ShieldConstant()
        {
            Assert.That(TypeConstants.Shield, Is.EqualTo("Shield"));
        }

        [Test]
        public void NotBludgeoningConstant()
        {
            Assert.That(TypeConstants.NotBludgeoning, Is.EqualTo("Not bludgeoning"));
        }

        [Test]
        public void BludgeoningConstant()
        {
            Assert.That(TypeConstants.Bludgeoning, Is.EqualTo("Bludgeoning"));
        }

        [Test]
        public void ThrownConstant()
        {
            Assert.That(TypeConstants.Thrown, Is.EqualTo("Thrown"));
        }

        [Test]
        public void SlashingConstant()
        {
            Assert.That(TypeConstants.Slashing, Is.EqualTo("Slashing"));
        }

        [Test]
        public void NotTowerConstant()
        {
            Assert.That(TypeConstants.NotTower, Is.EqualTo("Not tower"));
        }
    }
}