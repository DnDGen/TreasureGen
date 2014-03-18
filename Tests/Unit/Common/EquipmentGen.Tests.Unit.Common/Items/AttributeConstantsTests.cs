using EquipmentGen.Core.Data.Items.Constants;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items.Constants
{
    [TestFixture]
    public class AttributeConstantsTests
    {
        [Test]
        public void CommonConstant()
        {
            Assert.That(AttributeConstants.Common, Is.EqualTo("Common"));
        }

        [Test]
        public void UncommonConstant()
        {
            Assert.That(AttributeConstants.Uncommon, Is.EqualTo("Uncommon"));
        }

        [Test]
        public void WoodConstant()
        {
            Assert.That(AttributeConstants.Wood, Is.EqualTo("Wood"));
        }

        [Test]
        public void MetalConstant()
        {
            Assert.That(AttributeConstants.Metal, Is.EqualTo("Metal"));
        }

        [Test]
        public void DoubleWeaponConstant()
        {
            Assert.That(AttributeConstants.DoubleWeapon, Is.EqualTo("Double weapon"));
        }

        [Test]
        public void MeleeConstant()
        {
            Assert.That(AttributeConstants.Melee, Is.EqualTo("Melee"));
        }

        [Test]
        public void RangedConstant()
        {
            Assert.That(AttributeConstants.Ranged, Is.EqualTo("Ranged"));
        }
        [Test]
        public void AmmunitionConstant()
        {
            Assert.That(AttributeConstants.Ammunition, Is.EqualTo("Ammunition"));
        }

        [Test]
        public void ShieldConstant()
        {
            Assert.That(AttributeConstants.Shield, Is.EqualTo("Shield"));
        }

        [Test]
        public void NotBludgeoningConstant()
        {
            Assert.That(AttributeConstants.NotBludgeoning, Is.EqualTo("Not bludgeoning"));
        }

        [Test]
        public void BludgeoningConstant()
        {
            Assert.That(AttributeConstants.Bludgeoning, Is.EqualTo("Bludgeoning"));
        }

        [Test]
        public void ThrownConstant()
        {
            Assert.That(AttributeConstants.Thrown, Is.EqualTo("Thrown"));
        }

        [Test]
        public void SlashingConstant()
        {
            Assert.That(AttributeConstants.Slashing, Is.EqualTo("Slashing"));
        }

        [Test]
        public void NotTowerConstant()
        {
            Assert.That(AttributeConstants.NotTower, Is.EqualTo("Not tower"));
        }

        [Test]
        public void OneTimeUseConstant()
        {
            Assert.That(AttributeConstants.OneTimeUse, Is.EqualTo("One-time use"));
        }

        [Test]
        public void ChargedConstant()
        {
            Assert.That(AttributeConstants.Charged, Is.EqualTo("Charged"));
        }
    }
}