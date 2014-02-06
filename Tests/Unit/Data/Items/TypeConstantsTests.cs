using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class TypeConstantsTests
    {
        [Test]
        public void CommonMeleeWeaponTypeGearConstant()
        {
            Assert.That(TypeConstants.Common, Is.EqualTo("Common"));
        }

        [Test]
        public void UncommonWeaponTypeGearConstant()
        {
            Assert.That(TypeConstants.Uncommon, Is.EqualTo("Uncommon"));
        }

        [Test]
        public void WoodTypeGearConstant()
        {
            Assert.That(TypeConstants.Wood, Is.EqualTo("Wood"));
        }

        [Test]
        public void MetalTypeGearConstant()
        {
            Assert.That(TypeConstants.Metal, Is.EqualTo("Metal"));
        }

        [Test]
        public void DoubleWeaponTypeGearConstant()
        {
            Assert.That(TypeConstants.DoubleWeapon, Is.EqualTo("Double weapon"));
        }

        [Test]
        public void MeleeTypeGearConstant()
        {
            Assert.That(TypeConstants.Melee, Is.EqualTo("Melee"));
        }

        [Test]
        public void RangedTypeGearConstant()
        {
            Assert.That(TypeConstants.Ranged, Is.EqualTo("Ranged"));
        }
        [Test]
        public void AmmunitionGearTypeConstant()
        {
            Assert.That(TypeConstants.Ammunition, Is.EqualTo("Ammunition"));
        }

        [Test]
        public void ShieldGearTypeConstant()
        {
            Assert.That(TypeConstants.Shield, Is.EqualTo("Shield"));
        }

        [Test]
        public void NotBludgeoningGearTypeConstant()
        {
            Assert.That(TypeConstants.NotBludgeoning, Is.EqualTo("Not bludgeoning"));
        }

        [Test]
        public void BludgeoningGearTypeConstant()
        {
            Assert.That(TypeConstants.Bludgeoning, Is.EqualTo("Bludgeoning"));
        }

        [Test]
        public void ThrownGearTypeConstant()
        {
            Assert.That(TypeConstants.Thrown, Is.EqualTo("Thrown"));
        }

        [Test]
        public void SlashingGearTypeConstant()
        {
            Assert.That(TypeConstants.Slashing, Is.EqualTo("Slashing"));
        }
    }
}